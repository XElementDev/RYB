using XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_;

namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
#region not unit-tested
    internal class Device : IDevice
    {
        public Device( DeviceDTO initialValues, IHttpService httpService )
        {
            this._ain = initialValues.Identifier;
            this._httpService = httpService;
            this.InitializeProperties( initialValues );
        }


        public bool /*IDevice.*/CanSenseTemperature { get; private set; }


        private void InitializeMetaInformation( DeviceDTO initialValues )
        {
            this.Manufacturer = initialValues.Manufacturer;
            this.Name = initialValues.Name;
            this.ProductName = initialValues.ProductName;
        }


        private void InitializeProperties( DeviceDTO initialValues )
        {
            this.IsConnected = initialValues.Present == 1;
            this.InitializeMetaInformation( initialValues );
            this.InitializeSwitchStuff( initialValues );
            this.IsAThermostat = (initialValues.FunctionBitmask & Device.BIT_NO6) != 0;
            this.InitializeTemperatureStuff( initialValues );
        }


        private void InitializeSwitchStuff( DeviceDTO initialValues )
        {
            this.IsASwitch = (initialValues.FunctionBitmask & Device.BIT_NO9) != 0;

            if ( this.IsASwitch )
            {
                this.SwitchFeature = new SwitchFeature( initialValues.Switch, 
                                                        this._httpService, 
                                                        this._ain );
            }
        }


        private void InitializeTemperatureStuff( DeviceDTO initialValues )
        {
            this.CanSenseTemperature = (initialValues.FunctionBitmask & Device.BIT_NO8) != 0;

            if ( this.CanSenseTemperature )
            {
                this.TemperatureFeature = new TemperatureFeature( initialValues.Temperature );
            }
        }


        public bool /*IDevice.*/IsASwitch { get; private set; }


        public bool /*IDevice.*/IsAThermostat { get; private set; }


        public bool /*IDevice.*/IsConnected { get; private set; }


        //public bool /*IDevice.*/IsConnected()
        //{
        //    // TODO: Call service to get recent state
        //}


        public string /*IDevice.*/Manufacturer { get; private set; }


        public string /*IDevice.*/Name { get; private set; }


        public string /*IDevice.*/ProductName { get; private set; }


        public ISwitchFeature /*IDevice.*/SwitchFeature { get; private set; }


        public ITemperatureFeature /*IDevice.*/TemperatureFeature { get; private set; }


        private const int BIT_NO6 = 64;

        private const int BIT_NO8 = 256;

        private const int BIT_NO9 = 512;

        public const int MAX_NAME_LENGTH = 29;  // tested on 2016-10-05


        private string _ain;

        private IHttpService _httpService;
    }
#endregion
}
