using PropertyChanged;
using System.Collections.Generic;
using System.Composition;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Home
{
#region not unit-tested
    [Shared] [Export]
    [ImplementPropertyChanged]
    internal class Model
    {
        [ImportingConstructor]
        public Model( ModelDependenciesDTO dependencies )
        {
            this._dependencies = dependencies;
        }


        public IEnumerable<IDevice> Devices { get; private set; }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.Devices = this._dependencies.ApiService.GetDevices();
        }


        private ModelDependenciesDTO _dependencies;
    }
#endregion
}
