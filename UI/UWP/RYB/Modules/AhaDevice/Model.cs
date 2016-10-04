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
        }


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


        public bool IsASwitch { get { return this._device.IsASwitch; } }


        public bool IsAThermostat { get { return this._device.IsAThermostat; } }


        public bool IsConnected { get { return this._device.IsConnected; } }


        public string Manufacturer { get { return this._device.Manufacturer; } }


        public string Name { get { return this._device.Name; } }


        public string ProductName { get { return this._device.ProductName; } }


        public SwitchWidget.Model SwitchWidgetModel { get; private set; }


        private IDevice _device;
    }
#endregion
}
