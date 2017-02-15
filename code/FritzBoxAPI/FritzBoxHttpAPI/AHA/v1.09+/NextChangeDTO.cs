using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_
{
#region not unit-tested
    public class NextChangeDTO
    {
        //  --> TODO: Currently undocumented by AVM.
        // -->  TODO: Change return type.
        [XmlElement( "endperiod" )]
        public string EndPeriod { get; set; }


        //  --> TODO: Currently undocumented by AVM.
        // -->  TODO: Change return type.
        [XmlElement( "tchange" )]
        public string TChange { get; set; }
    }
#endregion
}
