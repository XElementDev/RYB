using Microsoft.Toolkit.Uwp;
using System.IO;
using System.Xml.Serialization;
using Windows.Storage;
using XElement.RedYellowBlue.UI.UWP.Model.AutoSave;

namespace XElement.RedYellowBlue.UI.UWP.Model.Configuration
{
#region not unit-tested
    [XmlRoot( "roamingConfig" )]
    public class RoamingConfig : IAutoSaveTarget
    {
        public RoamingConfig()
        {
            this._cryptoHelper = new CryptoHelper();
            this._serializer = new XmlSerializer( typeof( RoamingConfig ) );
        }


        [XmlElement( "boxUrl" )]
        public string BoxUrl { get; set; }


        [XmlElement( "password" )]
        public string EncryptedPassword { get; set; }


        [XmlIgnore()]
        public string Password
        {
            get { return this._cryptoHelper.Decrypt( this.EncryptedPassword ); }
            set { this.EncryptedPassword = this._cryptoHelper.Encrypt( value ); }
        }


        //  --> TODO: Fix error causing this operation not to complete before app is closed.
        void IAutoSaveTarget.Persist()
        {
            using ( var stream = new MemoryStream() )
            {
                this._serializer.Serialize( stream, this );
                var bytes = stream.ToArray();
                this.RoamingFolder.WriteBytesToFileAsync( bytes, FILE_NAME );
            }
        }


        public void Read()
        {
            if ( this.RoamingFolder.IsFileExistsAsync( FILE_NAME ).Result )
            {
                var bytes = this.RoamingFolder.ReadBytesFromFileAsync( FILE_NAME ).Result;
                var deserialized = this._serializer.Deserialize( new MemoryStream( bytes ) );
                var roamingConfig = deserialized as RoamingConfig;

                this.BoxUrl = roamingConfig.BoxUrl;
                this.EncryptedPassword = roamingConfig.EncryptedPassword;
                this.Username = roamingConfig.Username;
            }
        }


        private StorageFolder RoamingFolder
        {
            get { return ApplicationData.Current.RoamingFolder; }
        }


        [XmlElement( "username" )]
        public string Username { get; set; }


        private const string FILE_NAME = "config.xml";


        private CryptoHelper _cryptoHelper;

        private XmlSerializer _serializer;
    }
#endregion
}
