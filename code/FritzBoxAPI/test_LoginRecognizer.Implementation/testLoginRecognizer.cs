using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using XElement.RedYellowBlue.FritzBoxAPI.HttpApi.SessionId.v20121217;
using XElement.RedYellowBlue.TestUtils;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
    [TestClass]
    public class testLoginRecognizer
    {
        [TestMethod]
        public void testLoginRecognizer_Constructor_UsesPassedInWebRequestFactory()
        {
            var wasCalled = false;
            var requestMock = testLoginRecognizer.CreateRequestWithEmptyResponse();
            var mock = new StubIWebRequestCreate().Create( uri =>
            {
                wasCalled = true;
                return requestMock;
            } );
            var target = new LoginRecognizer( mock );

            var irrelevantButNotNull = new Uri( "http://www.google.de" );
            target.GetLoginInstance( irrelevantButNotNull );

            Assert.IsTrue( wasCalled );
        }


        [TestMethod]
        public void testLoginRecognizer_GetLoginInstance_AnonymousLogin()
        {
            var uriString = Path.Combine( "AnonymousLogin", "data.html" );
            var uri = GetAbsoluteUriFromRelativeUriString( uriString );
            var target = testLoginRecognizer.CreateLoginRecognizerWithFileAccess( uri.LocalPath );

            var actual = target.GetLoginInstance( uri );

            Assert.IsNotNull( actual );
            Assert.IsInstanceOfType( actual, typeof( AnonymousLogin ) );
        }

        [TestMethod]
        public void testLoginRecognizer_GetLoginInstance_PasswordBasedLogin()
        {
            var uriString = Path.Combine( "PasswordBasedLogin", "FRITZ!Box.html" );
            var uri = GetAbsoluteUriFromRelativeUriString( uriString );
            var target = testLoginRecognizer.CreateLoginRecognizerWithFileAccess( uri.LocalPath );

            var actual = target.GetLoginInstance( uri );

            Assert.IsNotNull( actual );
            Assert.IsInstanceOfType( actual, typeof( PasswordBasedLogin ) );
        }

        [TestMethod]
        public void testLoginRecognizer_GetLoginInstanceAsync_UserBasedLogin()
        {
            var uriString = Path.Combine( "UserBasedLogin", "FRITZ!Box.html" );
            var uri = GetAbsoluteUriFromRelativeUriString( uriString );
            var target = testLoginRecognizer.CreateLoginRecognizerWithFileAccess( uri.LocalPath );

            var actual = target.GetLoginInstance( uri );

            Assert.IsNotNull( actual );
            Assert.IsInstanceOfType( actual, typeof( UserBasedLogin ) );
        }



        private static LoginRecognizer CreateLoginRecognizerWithFileAccess( string path )
        {
            var responseMock = new MockableWebResponse();
            var stream = new FileStream( path, FileMode.Open, FileAccess.Read );
            responseMock.GetResponseStreamInt = () => stream;

            var requestMock = new MockableWebRequest();
            requestMock.GetResponseAsyncInt = () => Task.Run<WebResponse>( () => responseMock );

            var mockFactory = new StubIWebRequestCreate().Create( uri => requestMock );
            var recognizer = new LoginRecognizer( mockFactory );
            return recognizer;
        }


        private static WebRequest CreateRequestWithEmptyResponse()
        {
            var responseMock = new MockableWebResponse();
            responseMock.GetResponseStreamInt = () => new MemoryStream();
            var requestMock = new MockableWebRequest();
            requestMock.GetResponseAsyncInt = () => Task.Run<WebResponse>( () => responseMock );
            return requestMock;
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
