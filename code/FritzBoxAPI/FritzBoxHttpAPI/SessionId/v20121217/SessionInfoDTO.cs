using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.SessionId.v20121217
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
