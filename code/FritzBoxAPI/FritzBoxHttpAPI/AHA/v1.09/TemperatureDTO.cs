using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109
{
#region not unit-tested
    [XmlType( nameof( TemperatureDTO ) + "_v109" )]
    public class TemperatureDTO
    {
        public TemperatureDTO() { }


        /// <summary>
        /// celsius: Wert in 0,1 °C, negative und positive Werte möglich
        /// Actual example: "220" for "22,0°C"
        /// </summary>
        [XmlElement( "celsius" )]
        public int Celsius { get; set; }


        /// <summary>
        /// offset: Wert in 0,1 °C, negative und positive Werte möglich
        /// </summary>
        [XmlElement( "offset" )]
        public double Offset { get; set; }
    }
#endregion
}
