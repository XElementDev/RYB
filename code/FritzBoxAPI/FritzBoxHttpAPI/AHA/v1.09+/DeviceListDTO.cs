using System.Collections.Generic;
using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_
{
#region not unit-tested
    public class DeviceListDTO : v109.DeviceListDTO
    {
        [XmlElement( "device", typeof( DeviceDTO ) )]
        public new List<DeviceDTO> Devices { get; set; }


        [XmlElement( "group", typeof( GroupDTO ) )]
        public new List<GroupDTO> Groups { get; set; }
    }
#endregion
}
