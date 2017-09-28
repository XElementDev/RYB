using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.IO;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
    [TestClass]
    public class TestLoginRecognizer
    {
        [TestMethod]
        public void LoginRecognizer_ImplementsILoginRecognizer()
        {
            var target = new LoginRecognizer();

            Assert.IsInstanceOfType( target, typeof( ILoginRecognizer ) );
        }


        [TestMethod]
        public void LoginRecognizer_GetLoginType_Unknown__SomeValue()
        {
            var uri = new Uri( "https://www.outlook.com" );
            var target = new LoginRecognizer();

            var actual = target.GetLoginType( uri );

            Assert.AreEqual( LoginType.UNKNOWN, actual );
        }

        [TestMethod]
        public void LoginRecognizer_GetLoginType_AnonymousLogin()
        {
            string uriString = Path.Combine( "testLoginRecognizer", "AnonymousLogin.html" );
            var uri = GetAbsoluteUriFromRelativeUriString( uriString );
            var target = CreateLoginRecognizerWithFileScheme();

            var actual = target.GetLoginType( uri );

            Assert.AreEqual( LoginType.ANONYMOUS, actual );
        }

        [TestMethod]
        public void LoginRecognizer_GetLoginType_PasswordBasedLogin()
        {
            string uriString = Path.Combine( "testLoginRecognizer", "PasswordBasedLogin.html" );
            var uri = GetAbsoluteUriFromRelativeUriString( uriString );
            var target = CreateLoginRecognizerWithFileScheme();

            var actual = target.GetLoginType( uri );

            Assert.AreEqual( LoginType.PASSWORD_BASED, actual );
        }

        [TestMethod]
        public void LoginRecognizer_GetLoginType_Unknown__OtherValue()
        {
            var uri = new Uri( "https://www.gmail.com" );
            var target = new LoginRecognizer();

            var actual = target.GetLoginType( uri );

            Assert.AreEqual( LoginType.UNKNOWN, actual );
        }

        [TestMethod]
        public void LoginRecognizer_GetLoginType_UserBasedLogin()
        {
            string uriString = Path.Combine( "testLoginRecognizer", "UserBasedLogin.html" );
            var uri = GetAbsoluteUriFromRelativeUriString( uriString );
            var target = CreateLoginRecognizerWithFileScheme();

            var actual = target.GetLoginType( uri );

            Assert.AreEqual( LoginType.USER_BASED, actual );
        }

        [TestMethod]
        public void LoginRecognizer_GetLoginType_ContentNotYetLoaded()
        {
            string uriString = Path.Combine( "testLoginRecognizer", 
                                             "ContentNotYetLoaded",
                                             "index.html" );
            var uri = GetAbsoluteUriFromRelativeUriString( uriString );
            var target = CreateLoginRecognizerWithFileScheme();

            var actual = target.GetLoginType( uri );

            Assert.AreNotEqual( LoginType.UNKNOWN, actual );
        }






        private static LoginRecognizer CreateLoginRecognizerWithFileScheme()
        {
            var fileRequester = new FileRequester();
            var recognizer = new LoginRecognizer( fileRequester );
            return recognizer;
        }


        private static Uri GetAbsoluteUriFromRelativeUriString( string uriString )
        {
            var relativeUri = new Uri( uriString, UriKind.Relative );
            var baseUri = new Uri( AppContext.BaseDirectory );
            var absoluteUri = new Uri( baseUri, relativeUri );
            return absoluteUri;
        }
    }
}
