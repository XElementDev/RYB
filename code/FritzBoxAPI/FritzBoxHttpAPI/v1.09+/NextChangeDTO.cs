using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109_
{
#region not unit-tested
    public class NextChangeDTO
    {
        //  --> TODO
        [XmlElement( "endperiod" )]
        public string EndPeriod { get; set; }


        //  --> TODO
        [XmlElement( "tchange" )]
        public string TChange { get; set; }
    }
#endregion
}
