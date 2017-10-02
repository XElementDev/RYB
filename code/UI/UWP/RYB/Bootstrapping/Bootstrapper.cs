using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Windows.ApplicationModel;
using Windows.Storage;
using RootViewModel = XElement.RedYellowBlue.UI.UWP.Pages.Root.ViewModel;

namespace XElement.RYB.UI.UWP.Bootstrapping
{
#region not unit-tested
    internal class Bootstrapper
    {
        public Bootstrapper() { }


        private CompositionHost CreateCompositionHost()
        {
            var containerConfig = this.CreateContainerConfiguration();
            var compositionHost = containerConfig.CreateContainer();
            return compositionHost;
        }


        private ContainerConfiguration CreateContainerConfiguration()
        {
            var assemblies = this.GetMefAssemblies();
            var containerConfig = new ContainerConfiguration().WithAssemblies( assemblies );
            return containerConfig;
        }


        private static IEnumerable<AssemblyName> GetAllReferencedAssemblyNames()
        {
            var allFiles = GetFilesInPackage();
            var allDllFiles = allFiles 
                .Where( sf => sf.Name.EndsWith( DLL_FILE_EXTENSION ) ) 
                .ToList();
            var allAssemblyNames = allDllFiles 
                .Select( sf => new AssemblyName( sf.DisplayName ) ) 
                .ToList();
            return allAssemblyNames;
        }


        private static IEnumerable<StorageFile> GetFilesInPackage()
        {
            var installLocation = Package.Current.InstalledLocation;
            var task = installLocation.GetFilesAsync().AsTask();
            task.Wait();
            var allFiles = task.Result;
            return allFiles;
        }


        private IEnumerable<Assembly> GetMefAssemblies()
        {
            var thisAssembly = this.GetType().GetTypeInfo().Assembly;
            var mefAssemblies = new List<Assembly> { thisAssembly };
            mefAssemblies.AddRange( GetPlausibleReferencedAssemblies() );
            return mefAssemblies;
        }


        private static IEnumerable<Assembly> GetPlausibleReferencedAssemblies()
        {
            var allAssemblyNames = GetAllReferencedAssemblyNames();
            var plausibleAssemblyNames = allAssemblyNames
                .Where( an => an.FullName.StartsWith( "XElement." ) ) 
                .ToList();
            var plausibleReferencedAssemblies = plausibleAssemblyNames 
                .Select( an => Assembly.Load( an ) )
                .ToList();
            return plausibleReferencedAssemblies;
        }


        private void InitializeMef()
        {
            var compositionHost = this.CreateCompositionHost();
            compositionHost.SatisfyImports( this );
            this.RootVM = this.MefRootVM;
        }


        [Import]
        private RootViewModel MefRootVM { get; set; }


        public void Run()
        {
            this.InitializeMef();
            this.SetLocaleIfInDebug();
        }


        public RootViewModel RootVM { get; private set; }


        private void SetLocaleIfInDebug()
        {
#if DEBUG
            CultureInfo.CurrentUICulture = new CultureInfo( "en-US" );
#endif
        }


        private const string DLL_FILE_EXTENSION = ".dll";
    }
#endregion
}
