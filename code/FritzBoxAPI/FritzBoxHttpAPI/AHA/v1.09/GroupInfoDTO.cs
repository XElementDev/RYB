using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109
{
#region not unit-tested
    [XmlType( nameof( GroupInfoDTO ) + "_v109" )]
    public class GroupInfoDTO
    {
        public GroupInfoDTO() { }


        /// <summary>
        /// masterdeviceid: interne id des Master/Chef-Schalters, 0 bei "keiner gesetzt"
        /// </summary>
        [XmlElement( "masterdeviceid" )]
        public int MasterDeviceID { get; set; }


        /// <summary>
        /// members: interne ids der Gruppenmitglieder, kommasepariert
        /// </summary>
        [XmlElement( "members" )]
        public string Members { get; set; }
    }
#endregion
}
