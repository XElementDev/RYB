using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109
{
#region not unit-tested
    public class HkrDTO
    {
        public HkrDTO() { }


        /// <summary>
        /// absenk: Absenktemperatur in 0,5 °C, Wertebereich: 0x10 – 0x38
        ///         16 – 56 (8 bis 28°C), 16 <= 8°C, 17 = 8,5°C...... 56 >= 28°C, 254 = ON , 253 = OFF
        /// </summary>
        [XmlElement( "absenk" )]
        public double Absenk { get; set; }


        /// <summary>
        /// komfort:    Komforttemperatur in 0,5 °C, Wertebereich: 0x10 – 0x38
        ///             16 – 56 (8 bis 28°C), 16 <= 8°C, 17 = 8,5°C...... 56 >= 28°C, 254 = ON , 253 = OFF
        /// </summary>
        [XmlElement( "komfort" )]
        public double Komfort { get; set; }


        /// <summary>
        /// tist:   Isttemperatur in 0,5 °C, Wertebereich: 0x10 – 0x38
        ///         16 – 56 (8 bis 28°C), 16 <= 8°C, 17 = 8,5°C...... 56 >= 28°C, 254 = ON , 253 = OFF
        /// </summary>
        [XmlElement( "tist" )]
        public double TIst { get; set; }


        /// <summary>
        /// tsoll:  Solltemperatur in 0,5 °C, Wertebereich: 0x10 – 0x38
        ///         16 – 56 (8 bis 28°C), 16 <= 8°C, 17 = 8,5°C...... 56 >= 28°C, 254 = ON , 253 = OFF
        /// </summary>
        [XmlElement( "tsoll" )]
        public double TSoll { get; set; }
    }
#endregion
}
