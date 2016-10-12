﻿using PropertyChanged;
using System.Collections.Generic;
using System.Composition;

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


        public IEnumerable<AhaDevice.Model> DeviceModels { get; private set; }


        private void InitializeDeviceModels()
        {
            var devices = this._dependencies.ApiService.GetDevices();
            var deviceModels = new List<AhaDevice.Model>();
            foreach ( var device in devices )
            {
                var deviceModel = this._dependencies.AhaDeviceModelFactory.Get( device );
                deviceModels.Add( deviceModel );
            }
            this.DeviceModels = deviceModels;
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.TryInitializeDeviceModels();
        }


        private void TryInitializeDeviceModels()
        {
            if ( this._dependencies.Config.BoxUrl != null )
            {
                this.InitializeDeviceModels();
            }
        }


        private ModelDependenciesDTO _dependencies;
    }
#endregion
}