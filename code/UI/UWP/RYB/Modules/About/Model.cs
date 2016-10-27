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
            // TODO
            this.InitializeAssemblyInfos();
        }


        public string ApplicationName { get; private set; }


        private void InitializeAssemblyInfos()
        {
            var package = Package.Current;
            this.ApplicationName = package.DisplayName;
            var version = package.Id.Version;
            this.Version = $"v{version.Major}.{version.Minor}-.{version.Build}.{version.Revision}";
        }


        public string Version { get; private set; }
    }
#endregion
}
