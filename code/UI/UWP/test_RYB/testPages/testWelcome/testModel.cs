using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.ComponentModel;
using System.Composition;
using System.Composition.Hosting;
using System.Reflection;
using XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer;
using XElement.RedYellowBlue.UI.UWP.Model;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Welcome
{
    [TestClass]
    public class TestModel
    {
        [TestMethod]
        public void Model_IsExportedViaMef()
        {
            var mefImport = new MefImportTestHelper();
            var container = this.CreateMefContainer();

            container.SatisfyImports( mefImport );

            var target = mefImport.Target;
            Assert.IsNotNull( target );
            Assert.IsInstanceOfType( target, typeof( Model ) );
        }

        [TestMethod]
        public void Model_IsSharedExport()
        {
            var container = this.CreateMefContainer();
            var mefImport1 = new MefImportTestHelper();
            var mefImport2 = new MefImportTestHelper();

            container.SatisfyImports( mefImport1 );
            container.SatisfyImports( mefImport2 );

            var target1 = mefImport1.Target;
            var target2 = mefImport2.Target;
            Assert.IsNotNull( target1 );
            Assert.IsNotNull( target2 );
            Assert.AreSame( target1, target2 );
        }


        [TestMethod]
        public void Model_FinishSetup_ParameterPassthrough__RandomValues()
        {
            var expectedBoxUrl = XeRandom.CreateString();
            var expectedUsername = XeRandom.CreateString();
            var expectedPassword = XeRandom.CreateString();
            IConfig configMock = new ConfigMock();
            var dependencies = new ModelDependencies { Config = configMock };
            var target = new Model( dependencies );

            target.FinishSetup( expectedBoxUrl, expectedUsername, expectedPassword );

            Assert.AreEqual( expectedBoxUrl, configMock.BoxUrlAsString );
            Assert.AreEqual( expectedPassword, configMock.Password );
            Assert.AreEqual( expectedUsername, configMock.Username );
        }

        [TestMethod]
        public void Model_FinishSetup_RaisesEvent()
        {
            var wasCalled = false;
            var dependencies = new ModelDependencies { Config = new ConfigMock() };
            var target = new Model( dependencies );
            target.SetupFinished += ( s, e ) => wasCalled = true;

            target.FinishSetup( "irrelevant", "irrelevant", "irrelevant" );

            Assert.IsTrue( wasCalled );
        }

        [TestMethod]
        public void Model_FinishSetup_RaisesEvent_CorrectCallOrder__RandomValues()
        {
            string actualBoxUrl = null;
            string actualPassword = null;
            string actualUsername = null;
            var dependencies = new ModelDependencies { Config = new ConfigMock() };
            var target = new Model( dependencies );
            target.SetupFinished += ( s, e ) =>
            {
                actualBoxUrl = dependencies.Config.BoxUrlAsString;
                actualPassword = dependencies.Config.Password;
                actualUsername = dependencies.Config.Username;
            };

            target.FinishSetup( XeRandom.CreateString(), 
                                XeRandom.CreateString(), 
                                XeRandom.CreateString() );

            Assert.IsNotNull( actualBoxUrl );
            Assert.IsNotNull( actualPassword );
            Assert.IsNotNull( actualUsername );
        }


        //[TestMethod]
        //public void Model_GetLoginTypeAsync_ReturnsUnknown__RandomValues()
        //{
        //    var expected = LoginType.UNKNOWN;
        //    var loginRecognizerMock = new StubILoginRecognizer().GetLoginType( str => expected );
        //    var target = CreateTargetWithMockedDependencies( loginRecognizerMock );

        //    var task = target.GetLoginTypeAsync( XeRandom.CreateString() );
        //    task.Wait();
        //    var actual = task.Result;

        //    Assert.AreEqual( expected, actual );
        //}

        //[TestMethod]
        //public void Model_GetLoginTypeAsync_ReturnsAnonymous()
        //{
        //    var expected = LoginType.ANONYMOUS;
        //    var loginRecognizerMock = new StubILoginRecognizer().GetLoginType( str => expected );
        //    var target = CreateTargetWithMockedDependencies( loginRecognizerMock );

        //    var task = target.GetLoginTypeAsync( XeRandom.CreateString() );
        //    task.Wait();
        //    var actual = task.Result;

        //    Assert.AreEqual( expected, actual );
        //}

        //[TestMethod]
        //public void Model_GetLoginTypeAsync_ReturnsPasswordBased()
        //{
        //    var expected = LoginType.PASSWORD_BASED;
        //    var loginRecognizerMock = new StubILoginRecognizer().GetLoginType( str => expected );
        //    var target = CreateTargetWithMockedDependencies( loginRecognizerMock );

        //    var task = target.GetLoginTypeAsync( XeRandom.CreateString() );
        //    task.Wait();
        //    var actual = task.Result;

        //    Assert.AreEqual( expected, actual );
        //}

        //[TestMethod]
        //public void Model_GetLoginTypeAsync_ReturnsUserBased()
        //{
        //    var expected = LoginType.USER_BASED;
        //    var loginRecognizerMock = new StubILoginRecognizer().GetLoginType( str => expected );
        //    var target = CreateTargetWithMockedDependencies( loginRecognizerMock );

        //    var task = target.GetLoginTypeAsync( XeRandom.CreateString() );
        //    task.Wait();
        //    var actual = task.Result;

        //    Assert.AreEqual( expected, actual );
        //}

        //[TestMethod]
        //public void Model_GetLoginTypeAsync_ReturnsDefaultOnError()
        //{
        //    var expected = LoginType.UNKNOWN;
        //    GetLoginType_Uri_Delegate boom = _ => { throw new Exception( "Bäm!" ); };
        //    var loginRecognizerMock = new StubILoginRecognizer().GetLoginType( boom );
        //    var target = CreateTargetWithMockedDependencies( loginRecognizerMock );

        //    var task = target.GetLoginTypeAsync( XeRandom.CreateString() );
        //    task.Wait();
        //    var actual = task.Result;

        //    Assert.AreEqual( expected, actual );
        //}



        private CompositionHost CreateMefContainer()
        {
            var containerConfig = this.CreateMefContainerConfiguration();
            var compositionHost = containerConfig.CreateContainer();
            return compositionHost;
        }


        private ContainerConfiguration CreateMefContainerConfiguration()
        {
            var unitTestAssembly = this.GetType().GetTypeInfo().Assembly;
            var rybAssembly = Assembly.Load( new AssemblyName( "RYB" ) );
            var containerConfig = new ContainerConfiguration()
                .WithAssembly( unitTestAssembly )
                .WithAssembly( rybAssembly );
            return containerConfig;
        }


        private static Model CreateTargetWithMockedDependencies( ILoginRecognizer loginRecognizerMock )
        {
            var dependencies = new ModelDependencies
            {
                Config = new ConfigMock(), 
                LoginRecognizer = loginRecognizerMock
            };
            var target = new Model( dependencies );
            return target;
        }



        private class ConfigMock : IConfig
        {
            Uri IConfig.BoxUrl
            {
                get { throw new NotImplementedException(); }
            }


            public string BoxUrlAsString { get; set; }


            public string Password { get; set; }


            event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
            {
                add { throw new NotImplementedException(); }
                remove { throw new NotImplementedException(); }
            }


            public string Username { get; set; }
        }


        private class MefImportTestHelper
        {
            [Import( AllowDefault = true )]
            public Model Target { get; set; }
        }
    }
}
