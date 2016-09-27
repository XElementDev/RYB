using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Modules.AhaDevice
{
#region not unit-tested
    internal class ViewModel : IDevice
    {
        public ViewModel( IDevice device )
        {
            this._device = device;
            // TODO: run auto refresh in background
        }


        public bool /*IDevice.*/IsConnected { get { return this._device.IsConnected; } }


        public string /*IDevice.*/Manufacturer { get { return this._device.Manufacturer; } }


        public string /*IDevice.*/Name { get { return this._device.Name; } }


        public string /*IDevice.*/ProductName { get { return this._device.ProductName; } }


        private IDevice _device;
    }
#endregion
}
