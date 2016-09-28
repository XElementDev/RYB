using System.Collections.Generic;
using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Home
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( Home.Model model, ViewModelDependenciesDTO dependencies )
        {
            this._model = model;
            this._dependencies = dependencies;
        }


        public IEnumerable<AhaDevice.ViewModel> DeviceVMs { get; private set; }


        private void Initialize()
        {
            var deviceVMs = new List<AhaDevice.ViewModel>();
            foreach ( var device in this._model.Devices )
            {
                var deviceVM = this._dependencies.AhaDeviceVmFactory.Get( device );
                deviceVMs.Add( deviceVM );
            }
            this.DeviceVMs = deviceVMs;
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.Initialize();
        }


        private ViewModelDependenciesDTO _dependencies;

        private Home.Model _model;
    }
#endregion
}
