using XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109;

namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
#region not unit-tested
    public class HttpService : IHttpService
    {
        public HttpService( HttpServiceParametersDTO parameters ) : this( parameters, null ) { }

        public HttpService( HttpServiceParametersDTO parameters, OptionalHttpServiceParametersDTO optional )
        {
            this._parameters = parameters;
            this._optionalParameters = optional;
        }


        private LoginBase CreateLogin()
        {
            LoginBase login = null;

            var uri = this._parameters.Uri;
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


        public bool /*IService.*/IsLoginValid()
        {
            bool isLoginValid = true;

            LoginBase login = CreateLogin();
            try { login.Do(); }
            catch { isLoginValid = false; }

            return isLoginValid;
        }


        private OptionalHttpServiceParametersDTO _optionalParameters;

        private HttpServiceParametersDTO _parameters;
    }
#endregion
}
