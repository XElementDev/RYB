using System.Collections.Generic;
using System.Threading.Tasks;
using XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109;
using XElement.RedYellowBlue.FritzBoxAPI.HttpApi.SessionId.v20121217;

namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
#region not unit-tested
    //  --> TODO: Check for sufficient rights, aka capabilities.
    public class HttpService : IHttpService
    {
        public HttpService( HttpServiceParametersDTO parameters ) : this( parameters, null ) { }

        public HttpService( HttpServiceParametersDTO parameters, OptionalHttpServiceParametersDTO optional )
        {
            this._parameters = parameters;
            this._optionalParameters = optional;
        }


        private Aha CreateAha()
        {
            var login = this.CreateLogin();
            login.Do();
            var aha = new Aha( this._parameters.BoxUrl, login.Sid );
            return aha;
        }


        private LoginBase CreateLogin()
        {
            LoginBase login = null;

            var uri = this._parameters.BoxUrl;
            var password = this._optionalParameters?.Password;
            var username = this._optionalParameters?.Username;

            if ( username != null )
                login = new UserBasedLogin( uri, username, password );
            else if ( password != null )
                login = new PasswordBasedLogin( uri, password );
            else
                login = new AnonymousLogin( uri );

            return login;
        }


        public IEnumerable<IDevice> GetDevices()
        {
            var devices = new List<IDevice>();

            var aha = this.CreateAha();
            var deviceListDTO = aha.GetDeviceListInfos();
            foreach ( var deviceDTO in deviceListDTO.Devices )
            {
                var device = new Device( deviceDTO, this );
                devices.Add( device );
            }

            return devices;
        }


        public bool /*IService.*/IsLoginValid()
        {
            bool isLoginValid = true;

            LoginBase login = CreateLogin();
            try { login.Do(); }
            catch { isLoginValid = false; }

            return isLoginValid;
        }

        public Task<bool> /*IService.*/IsLoginValidAsync()
        {
            var task = new Task<bool>( this.IsLoginValid );
            task.Start();
            return task;
        }


        public void /*IService.*/SetSwitch( bool targetState, string ain )
        {
            var aha = this.CreateAha();
            if ( targetState == false )
            {
                aha.SetSwitchOff( ain );
            }
            else
            {
                aha.SetSwitchOn( ain );
            }
        }


        private OptionalHttpServiceParametersDTO _optionalParameters;

        private HttpServiceParametersDTO _parameters;
    }
#endregion
}
