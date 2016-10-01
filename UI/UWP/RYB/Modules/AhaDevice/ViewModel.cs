using Mntone.SvgForXaml;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Modules.AhaDevice
{
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel( IDevice device, ViewModelDependenciesDTO dependencies )
        {
            this._device = device;
            this.InitializeSvgImage( dependencies );
            // TODO: run auto refresh in background
        }


        private void InitializeSvgImage( ViewModelDependenciesDTO dependencies )
        {
            if ( this.IsASwitch )
            {
                this.SvgImage = dependencies.SvgSwitch.Svg;
            }
        }


        public bool /*IDevice.*/IsASwitch { get { return this._device.IsASwitch; } }


        public bool /*IDevice.*/IsConnected { get { return this._device.IsConnected; } }


        public bool IsImageVisible { get { return this.SvgImage != null; } }



        public string /*IDevice.*/Manufacturer { get { return this._device.Manufacturer; } }


        public string /*IDevice.*/Name { get { return this._device.Name; } }


        public string /*IDevice.*/ProductName { get { return this._device.ProductName; } }


        public SvgDocument SvgImage { get; private set; }


        private IDevice _device;
    }
#endregion
}
