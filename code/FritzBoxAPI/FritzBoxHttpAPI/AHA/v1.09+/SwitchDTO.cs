using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_
{
#region not unit-tested
    public class SwitchDTO : v109.SwitchDTO
    {
        [XmlElement( "devicelock" )]
        public int DeviceLock { get; set; }
    }
#endregion
}
