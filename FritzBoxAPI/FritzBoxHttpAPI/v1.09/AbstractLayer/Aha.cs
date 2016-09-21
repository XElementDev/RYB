using System.Xml.Serialization;
using XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109.ConcreteLayer;

namespace XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109
{
#region not unit-tested
    public class Aha
    {
        public Aha( string boxUrl, string sid )
        {
            this._boxUrl = boxUrl;
            this._sid = sid;
        }


        public DeviceListDTO GetDeviceListInfos()
        {
            DeviceListDTO result = null;

            var ahaRequest = new AhaRequest( this._boxUrl, AhaCmd.getdevicelistinfos, this._sid );
            var response = ahaRequest.Create().GetResponseAsync().Result;
            using ( var stream = response.GetResponseStream() )
            {
                var serializer = new XmlSerializer( typeof( DeviceListDTO ) );
                result = serializer.Deserialize( stream ) as DeviceListDTO;
            }

            return result;
        }


        private string _boxUrl;

        private string _sid;
    }
#endregion
}
