using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_
{
#region not unit-tested
    [XmlType( nameof( HkrDTO ) + "_v109+" )]
    public class HkrDTO : v109.HkrDTO
    {
        public HkrDTO() { }


        //  --> TODO: Currently undocumented by AVM.
        // -->  TODO: Change return type.
        [XmlElement( "batterlow" )]
        public string BatteryLow { get; set; }


        //  --> TODO: Currently undocumented by AVM.
        // -->  TODO: Change return type.
        [XmlElement( "devicelock" )]
        public string DeviceLock { get; set; }


        //  --> TODO: Currently undocumented by AVM.
        // -->  TODO: Change return type.
        [XmlElement( "errorcode" )]
        public string ErrorCode { get; set; }


        //  --> TODO: Currently undocumented by AVM.
        // -->  TODO: Change return type.
        [XmlElement( "lock" )]
        public string Lock { get; set; }


        //  --> TODO: Currently undocumented by AVM.
        // -->  TODO: Change return type.
        [XmlElement( "nextchange" )]
        public NextChangeDTO NextChange { get; set; }
    }
#endregion
}
