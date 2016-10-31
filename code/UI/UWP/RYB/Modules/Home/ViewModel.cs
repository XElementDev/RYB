using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using System.Collections.Generic;
using System.Composition;
using System.Windows.Input;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Home
{
#region not unit-tested
    [Shared] [Export]
    [ImplementPropertyChanged]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( Home.Model model, ViewModelDependenciesDTO dependencies )
        {
            this._model = model;
            this._dependencies = dependencies;
            this.RefreshCommand = new RelayCommand( this.RefreshCommand_Execute );
        }


        public IEnumerable<AhaDevice.ViewModel> DeviceVMs { get; private set; }


        private void Initialize()
        {
            var deviceVMs = new List<AhaDevice.ViewModel>();
            var deviceModels = this._model.DeviceModels ?? new List<AhaDevice.Model>();
            foreach ( var device in deviceModels )
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


        private async void RefreshAsync()
        {
            await this._model.RefreshAsync();
            this.Initialize();
        }


        [DoNotNotify]
        public ICommand RefreshCommand { get; private set; }

        private void RefreshCommand_Execute()
        {
            this.RefreshAsync();
        }


        private ViewModelDependenciesDTO _dependencies;

        private Home.Model _model;
    }
#endregion
}
