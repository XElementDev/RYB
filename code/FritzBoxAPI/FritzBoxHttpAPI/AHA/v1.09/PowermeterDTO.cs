using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109
{
#region not unit-tested
    public class PowermeterDTO
    {
        public PowermeterDTO() { }


        /// <summary>
        /// energy: Wert in 1.0 Wh( absoluter Verbrauch seit Inbetriebnahme )
        /// </summary>
        [XmlElement( "energy" )]
        public double Energy { get; set; }


        /// <summary>
        /// power: Wert in 0,01 W( aktuelle Leistung, wird etwa alle 2 Minuten aktualisiert )
        /// </summary>
        [XmlElement( "power" )]
        public double Power { get; set; }
    }
#endregion
}
