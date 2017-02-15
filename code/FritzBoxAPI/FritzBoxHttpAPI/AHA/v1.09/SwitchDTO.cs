using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109
{
#region not unit-tested
    public class SwitchDTO
    {
        public SwitchDTO() { }


        /// <summary>
        /// lock: 0/1 - Schaltsperre ein nein/ja( leer bei unbekannt oder Fehler)
        /// </summary>
        [XmlElement( "lock" )]
        public int Lock { get; set; }


        /// <summary>
        /// mode: "auto" oder "manuell"
        /// -> automatische Zeitschaltung oder manuell schalten( leer bei unbekannt oder Fehler)
        /// </summary>
        [XmlElement( "mode" )]
        public string Mode { get; set; }


        /// <summary>
        /// state: 0/1 - Schaltzustand aus/an( leer bei unbekannt oder Fehler)
        /// </summary>
        [XmlElement( "state" )]
        public int State { get; set; }
    }
#endregion
}
