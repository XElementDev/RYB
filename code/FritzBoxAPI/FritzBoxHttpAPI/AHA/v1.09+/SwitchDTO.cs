using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_
{
#region not unit-tested
    [XmlType( nameof( SwitchDTO ) + "_v109+" )]
    public class SwitchDTO : v109.SwitchDTO
    {
        [XmlElement( "devicelock" )]
        public int DeviceLock { get; set; }
    }
#endregion
}
