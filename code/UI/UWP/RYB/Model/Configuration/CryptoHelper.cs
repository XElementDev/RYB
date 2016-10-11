using System.IO;
using System.Reflection;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace XElement.RedYellowBlue.UI.UWP.Model.Configuration
{
#region not unit-tested
    internal class CryptoHelper
    {
        public CryptoHelper() { }


        public string Decrypt( string encrypted )
        {
            string decrypted = null;

            if ( encrypted != null )
            {
                var cryptoKey = this.GetCryptoKey();
                var data = CryptographicBuffer.DecodeFromBase64String( encrypted );
                var buffer = CryptographicEngine.Decrypt( cryptoKey, data, iv: null );
                decrypted = CryptographicBuffer.ConvertBinaryToString( BIN_STR_ENCODING, buffer );
            }

            return decrypted;
        }


        public string Encrypt( string decrypted )
        {
            var cryptoKey = this.GetCryptoKey();
            var data = CryptographicBuffer.ConvertStringToBinary( decrypted, BIN_STR_ENCODING );
            var encryptedBuffer = CryptographicEngine.Encrypt( cryptoKey, data, iv: null );
            var encrypted = CryptographicBuffer.EncodeToBase64String( encryptedBuffer );
            return encrypted;
        }


        private CryptographicKey GetCryptoKey()
        {
            CryptographicKey cryptoKey;
            var rawKey = this.GetKey();
            var algorithmName = SymmetricAlgorithmNames.AesEcbPkcs7;
            var aes = SymmetricKeyAlgorithmProvider.OpenAlgorithm( algorithmName );
            var keyBuffer = CryptographicBuffer.ConvertStringToBinary( rawKey, BIN_STR_ENCODING );
            cryptoKey = aes.CreateSymmetricKey( keyBuffer );
            return cryptoKey;
        }


        /// <summary>
        /// Returns the encryption key.
        /// It's a private method and not a field such that the key is only shortly in memory.
        /// </summary>
        private string GetKey()
        {
            string key = null;

            var assembly = this.GetType().GetTypeInfo().Assembly;
            using ( var resource = assembly.GetManifestResourceStream( RESOURCE_NAME ) )
            using ( var reader = new StreamReader( resource ))
            {
                key = reader.ReadToEnd();
            }

            return key;
        }


        private const BinaryStringEncoding BIN_STR_ENCODING = BinaryStringEncoding.Utf8;

        private const string DEFAULT_NAMESPACE = "XElement.RedYellowBlue.UI.UWP.Model";

        private const string RESOURCE_NAME = DEFAULT_NAMESPACE + "." + "Configuration.key.txt";
    }
#endregion
}
