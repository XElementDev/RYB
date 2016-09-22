using XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109;

namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
#region not unit-tested
    internal class Device : IDevice
    {
        public Device( DeviceDTO initialValues )
        {
            this._ain = initialValues.Identifier;

            this.Manufacturer = initialValues.Manufacturer;
            this.ProductName = initialValues.ProductName;
        }


        public string /*IDevice.*/Manufacturer { get; private set; }


        public string /*IDevice.*/ProductName { get; private set; }


        private string _ain;
    }
#endregion
}
