using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Composition;
using System.Composition.Hosting;
using System.Reflection;
using XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer;

namespace XElement.RedYellowBlue.UI.UWP.testPages.testWelcome
{
    [TestClass]
    public class testMefLoginRecognizer
    {
        [TestMethod]
        public void MefLoginRecognizer_IsExportedViaMef()
        {
            var mefImport = new MefImportTestHelper();
            var container = this.CreateMefContainer();

            container.SatisfyImports( mefImport );

            var target = mefImport.Target;
            Assert.IsNotNull( target );
            Assert.IsInstanceOfType( target, typeof( ILoginRecognizer ) );
        }


        [TestMethod]
        public void MefLoginRecognizer_IsSharedExport()
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
            public ILoginRecognizer Target { get; set; }
        }
    }
}
