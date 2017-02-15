using System.Xml.Serialization;
using v109 = XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_
{
#region not unit-tested
    public class HkrDTO : v109.HkrDTO
    {
        //  --> TODO
        [XmlElement( "batterlow" )]
        public string BatteryLow { get; set; }


        //  --> TODO
        [XmlElement( "devicelock" )]
        public string DeviceLock { get; set; }


        //  --> TODO
        [XmlElement( "errorcode" )]
        public string ErrorCode { get; set; }


        //  --> TODO
        [XmlElement( "lock" )]
        public string Lock { get; set; }


        //  --> TODO
        [XmlElement( "nextchange" )]
        public NextChangeDTO NextChange { get; set; }
    }
#endregion
}
