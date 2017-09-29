using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Composition;
using System.Composition.Hosting;
using System.Reflection;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;
using localRandom = XElement.RedYellowBlue.TestUtils.Random;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.RedYellowBlue.UI.UWP.Model.Api
{
    [TestClass]
    public class TestMefApiAdapter
    {
        [TestMethod]
        public void MefHttpService_IsExportedViaMef()
        {
            var mefImport = new MefImportTestHelper();
            var container = this.CreateMefContainer();

            container.SatisfyImports( mefImport );

            var target = mefImport.MefHttpService;
            Assert.IsNotNull( target );
            Assert.IsInstanceOfType( target, typeof( IHttpService ) );
        }


        [TestMethod]
        public void MefHttpService_IsSharedExport()
        {
            var container = this.CreateMefContainer();
            var mefImport1 = new MefImportTestHelper();
            var mefImport2 = new MefImportTestHelper();

            container.SatisfyImports( mefImport1 );
            container.SatisfyImports( mefImport2 );

            var target1 = mefImport1.MefHttpService;
            var target2 = mefImport2.MefHttpService;
            Assert.IsNotNull( target1 );
            Assert.IsNotNull( target2 );
            Assert.AreSame( target1, target2 );
        }


        [TestMethod]
        public void MefHttpService_ImplementsIHttpService()
        {
            var target = new MefHttpService( null, null );

            Assert.IsInstanceOfType( target, typeof( IHttpService ) );
        }

        [TestMethod]
        public void MefHttpService_ExtendsHttpService()
        {
            var target = new MefHttpService( null, null );

            Assert.IsInstanceOfType( target, typeof( HttpService ) );
        }



        [TestMethod]
        public void MefParametersDTO_IsExportedViaMef()
        {
            var mefImport = new MefImportTestHelper();
            var container = this.CreateMefContainer();

            container.SatisfyImports( mefImport );

            var target = mefImport.MefParameters;
            Assert.IsNotNull( target );
            Assert.IsInstanceOfType( target, typeof( HttpServiceParametersDTO ) );
        }


        [TestMethod]
        public void MefParametersDTO_IsSharedExport()
        {
            var container = this.CreateMefContainer();
            var mefImport1 = new MefImportTestHelper();
            var mefImport2 = new MefImportTestHelper();

            container.SatisfyImports( mefImport1 );
            container.SatisfyImports( mefImport2 );

            var target1 = mefImport1.MefParameters;
            var target2 = mefImport2.MefParameters;
            Assert.IsNotNull( target1 );
            Assert.IsNotNull( target2 );
            Assert.AreSame( target1, target2 );
        }


        [TestMethod]
        public void MefParametersDTO_Constructor_CorrectInitialValues__SomeValue()
        {
            var expected = new Uri( "http://example.org" );
            var configMock = new StubIConfig().BoxUrl_Get( () => expected );

            var target = new MefParametersDTO( configMock );

            var actual = target.BoxUrl;
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void MefParametersDTO_Constructor_CorrectInitialValues__OtherValue()
        {
            var expected = new Uri( "https://www.google.de" );
            var configMock = new StubIConfig().BoxUrl_Get( () => expected );

            var target = new MefParametersDTO( configMock );

            var actual = target.BoxUrl;
            Assert.AreEqual( expected, actual );
        }


        [TestMethod]
        public void MefParametersDTO_EventSubscription__SomeValue()
        {
            var url1 = new Uri( "http://www.heute.de" );
            var configMock = new StubIConfig().BoxUrl_Get( () => url1 );
            var target = new MefParametersDTO( configMock );
            var expectedUrl = new Uri( "http://www.sportschau.de" );

            configMock.BoxUrl_Get( () => expectedUrl, overwrite: true );
            configMock.PropertyChanged_Raise( null );

            Assert.AreEqual( expectedUrl, target.BoxUrl );
        }

        [TestMethod]
        public void MefParametersDTO_EventSubscription__OtherValue()
        {
            var url1 = new Uri( "https://outlook.com" );
            var configMock = new StubIConfig().BoxUrl_Get( () => url1 );
            var target = new MefParametersDTO( configMock );
            var expectedUrl = new Uri( "ftp://localhost/" );

            configMock.BoxUrl_Get( () => expectedUrl, overwrite: true );
            configMock.PropertyChanged_Raise( configMock );

            Assert.AreEqual( expectedUrl, target.BoxUrl );
        }



        [TestMethod]
        public void MefOptionalParametersDTO_IsExportedViaMef()
        {
            var mefImport = new MefImportTestHelper();
            var container = this.CreateMefContainer();

            container.SatisfyImports( mefImport );

            var target = mefImport.MefOptionalParameters;
            Assert.IsNotNull( target );
            Assert.IsInstanceOfType( target, typeof( OptionalHttpServiceParametersDTO ) );
        }


        [TestMethod]
        public void MefOptionalParametersDTO_IsSharedExport()
        {
            var container = this.CreateMefContainer();
            var mefImport1 = new MefImportTestHelper();
            var mefImport2 = new MefImportTestHelper();

            container.SatisfyImports( mefImport1 );
            container.SatisfyImports( mefImport2 );

            var target1 = mefImport1.MefOptionalParameters;
            var target2 = mefImport2.MefOptionalParameters;
            Assert.IsNotNull( target1 );
            Assert.IsNotNull( target2 );
            Assert.AreSame( target1, target2 );
        }


        [TestMethod]
        public void MefOptionalParametersDTO_Constructor_CorrectInitialValues__RandomValues()
        {
            var configMock = localRandom.CreateConfigMockWithRandomCredentials();

            var target = new MefOptionalParametersDT( configMock );

            Assert.AreEqual( configMock.Username, target.Username );
            Assert.AreEqual( configMock.Password, target.Password );
        }


        [TestMethod]
        public void MefOptionalParametersDTO_EventSubscription__RandomValues()
        {
            var expectedUsername = XeRandom.CreateString();
            var expectedPassword = XeRandom.CreateString();
            var configMock = localRandom.CreateConfigMockWithRandomCredentials() as StubIConfig;
            var target = new MefOptionalParametersDT( configMock );

            configMock.Username_Get( () => expectedUsername, overwrite: true );
            configMock.Password_Get( () => expectedPassword, overwrite: true );
            configMock.PropertyChanged_Raise( configMock );

            Assert.AreEqual( expectedUsername, target.Username );
            Assert.AreEqual( expectedPassword, target.Password );
        }



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


        private class MefImportTestHelper
        {
            [Import( AllowDefault = true )]
            public IHttpService MefHttpService { get; set; }


            [Import( AllowDefault = true )]
            public HttpServiceParametersDTO MefParameters { get; set; }


            [Import( AllowDefault = true )]
            public OptionalHttpServiceParametersDTO MefOptionalParameters { get; set; }
        }
    }
}
