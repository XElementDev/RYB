using System;
using System.Xml.Serialization;
using XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109.ConcreteLayer;

namespace XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109
{
#region not unit-tested
    public class Aha
    {
        public Aha( Uri boxUrl, string sid )
        {
            this._boxUrl = boxUrl;
            this._sid = sid;
        }


        private AhaRequest CreateAhaRequest( AhaCmd cmd )
        {
            var ahaRequest = new AhaRequest( this._boxUrl, cmd, this._sid );
            return ahaRequest;
        }


        public DeviceListDTO GetDeviceListInfos()
        {
            DeviceListDTO result = null;

            var ahaRequest = this.CreateAhaRequest( AhaCmd.getdevicelistinfos );
            var response = ahaRequest.Create().GetResponseAsync().Result;
            using ( var stream = response.GetResponseStream() )
            {
                var serializer = new XmlSerializer( typeof( DeviceListDTO ) );
                result = serializer.Deserialize( stream ) as DeviceListDTO;
            }

            return result;
        }


        //private void ParseResponse( WebResponse response )
        //{
        //    var httpResponse = response as HttpWebResponse;
        //    if ( httpResponse.StatusCode != HttpStatusCode.OK )
        //    {
        //        throw new Exception( "Request not successful." );
        //    }
        //}


        private void SetSwitch( string ain, bool targetState )
        {
            var cmd = targetState == false ? AhaCmd.setswitchoff : AhaCmd.setswitchon;
            var ahaRequest = this.CreateAhaRequest( cmd );
            ahaRequest.Ain = ain;
            var response = ahaRequest.Create().GetResponseAsync().Result;
            //this.ParseResponse( response );
        }


        public void SetSwitchOff( string ain )
        {
            this.SetSwitch( ain, false );
        }


        public void SetSwitchOn( string ain )
        {
            this.SetSwitch( ain, true );
        }


        private Uri _boxUrl;

        private string _sid;
    }
#endregion
}
