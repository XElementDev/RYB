using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_
{
#region not unit-tested
    public class DeviceDTO : v109.DeviceDTO
    {
        //  --> optional content
        [XmlElement( "hkr" )]
        public new HkrDTO Hkr { get; set; }


        //  --> optional content
        [XmlElement( "powermeter" )]
        public new PowermeterDTO Powermeter { get; set; }


        //  --> optional content
        [XmlElement( "switch" )]
        public new SwitchDTO Switch { get; set; }


        //  --> optional content
        [XmlElement( "temperature" )]
        public new TemperatureDTO Temperature { get; set; }
    }
#endregion
}
