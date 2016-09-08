using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxApi.v109
{
#region not unit-tested
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
