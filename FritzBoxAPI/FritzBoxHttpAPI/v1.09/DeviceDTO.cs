using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109
{
#region not unit-tested
    public class DeviceDTO
    {
        public DeviceDTO() { }


        /// <summary>
        /// functionbitmask: Bitmaske der Geräte-Funktionsklassen
        /// Bit 6: Comet DECT, Heizkostenregler
        /// Bit 7: Energie Messgerät
        /// Bit 8: Temperatursensor
        /// Bit 9: Schaltsteckdose
        /// Bit 10: AVM DECT Repeater
        /// </summary>
        [XmlAttribute( "functionbitmask" )]
        public int FunctionBitmask { get; set; }


        /// <summary>
        /// fwversion: Firmwareversion des Gerätes
        /// </summary>
        [XmlAttribute( "fwversion" )]
        public string FwVersion { get; set; }


        //  --> optional content
        [XmlElement( "hkr" )]
        public HkrDTO Hkr { get; set; }


        /// <summary>
        /// id: interne Geräteid
        /// </summary>
        [XmlAttribute( "id" )]
        public int Id { get; set; }


        /// <summary>
        /// identifier: AIN, MAC-Adresse, eindeutige ID
        /// </summary>
        [XmlAttribute( "identifier" )]
        public string /*Device.*/Identifier { get; set; }


        /// <summary>
        /// manufacturer: "AVM"
        /// </summary>
        [XmlAttribute( "manufacturer" )]
        public string Manufacturer { get; set; }


        /// <summary>
        /// name: Gerätename
        /// </summary>
        [XmlElement( "name" )]
        public string Name { get; set; }


        //  --> optional content
        [XmlElement( "powermeter" )]
        public PowermeterDTO Powermeter { get; set; }


        /// <summary>
        /// present: 0/1 - Gerät verbunden nein/ja
        /// </summary>
        [XmlElement( "present" )]
        public int Present { get; set; }


        /// <summary>
        /// productname: Produktname des Gerätes, leer bei unbekanntem/undefiniertem Gerät
        /// </summary>
        [XmlAttribute( "productname" )]
        public string ProductName { get; set; }


        //  --> optional content
        [XmlElement( "switch" )]
        public SwitchDTO Switch { get; set; }


        //  --> optional content
        [XmlElement( "temperature" )]
        public TemperatureDTO Temperature { get; set; }
    }
#endregion
}
