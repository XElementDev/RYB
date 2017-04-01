using System.Composition;
using Windows.ApplicationModel;

namespace XElement.RedYellowBlue.UI.UWP.Modules.About
{
#region not unit-tested
    [Shared] [Export]
    internal class Model
    {
        [ImportingConstructor]
        public Model()
        {
            this.Initialize();
        }


        public string ApplicationName { get; private set; }



        private void Initialize()
        {
            this.InitializeUsingAssemblyInformation();
            this.InitializeUsingPackageInformation();
        }


        private void InitializeUsingAssemblyInformation()
        {
            // TODO
            //this.Copyright = 
        }


        private void InitializeUsingPackageInformation()
        {
            var package = Package.Current;
            this.ApplicationName = package.DisplayName;
            var version = package.Id.Version;
            var minor = $"{version.Minor}-";
            this.Version = $"v{version.Major}.{minor}.{version.Build}.{version.Revision}";
        }


        public string Version { get; private set; }
    }
#endregion
}
