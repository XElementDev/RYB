using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Modules.AhaDevice
{
#region not unit-tested
    internal class Model
    {
        public Model( IDevice device )
        {
            this._device = device;
            this.InitializeSwitchWidgeModel();
            this.InitializeTemperatureWidgetModel();
        }


        public bool CanSenseTemperature { get { return this._device.CanSenseTemperature; } }


        private void InitializeSwitchWidgeModel()
        {
            if ( this.IsASwitch )
            {
                var parameters = new SwitchWidget.ModelParametersDTO
                {
                    SwitchFeature = this._device.SwitchFeature
                };
                this.SwitchWidgetModel = new SwitchWidget.Model( parameters );
            }
        }


        private void InitializeTemperatureWidgetModel()
        {
            if (this.CanSenseTemperature )
            {
                var parameters = new TemperatureWidget.ModelParametersDTO
                {
                    TemperatureFeature = this._device.TemperatureFeature
                };
                this.TemperatureWidgetModel = new TemperatureWidget.Model( parameters );
            }
        }


        public bool IsASwitch { get { return this._device.IsASwitch; } }


        public bool IsAThermostat { get { return this._device.IsAThermostat; } }


        public bool IsConnected { get { return this._device.IsConnected; } }


        public string Name { get { return this._device.Name; } }


        public SwitchWidget.Model SwitchWidgetModel { get; private set; }


        public TemperatureWidget.Model TemperatureWidgetModel { get; private set; }


        private IDevice _device;
    }
#endregion
}
