using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109
{
#region not unit-tested
    [XmlRoot( "SessionInfo" )]
    public class SessionInfoDTO
    {
        [XmlElement( "BlockTime" )]
        public int BlockTime { get; set; }


        [XmlElement( "Challenge" )]
        public string Challenge { get; set; }


        // TODO: Rights


        [XmlElement( "SID" )]
        public string Sid { get; set; }
    }
#endregion
}
