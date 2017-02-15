using System.Xml.Serialization;
using v109 = XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109;

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
