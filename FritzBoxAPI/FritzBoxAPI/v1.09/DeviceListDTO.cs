using System.Collections.Generic;
using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxApi.v109
{
#region not unit-tested
    [XmlRoot( "devicelist" )]
    internal class DeviceListDTO
    {
        public DeviceListDTO() { }


        [XmlElement( "device", typeof( DeviceDTO ) )]
        public List<DeviceDTO> Devices { get; set; }


        [XmlElement( "group", typeof( GroupDTO ) )]
        public List<GroupDTO> Groups { get; set; }


        [XmlAttribute( "version")]
        public int Version { get; set; }
    }
#endregion
}
