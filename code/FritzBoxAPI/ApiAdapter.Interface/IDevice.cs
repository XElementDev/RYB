namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
    public interface IDevice
    {
        bool CanSenseTemperature { get; }


        bool IsASwitch { get; }


        bool IsAThermostat { get; }


        bool IsConnected { get; }


        //bool IsConnected();


        string Manufacturer { get; }


        string Name { get; }


        string ProductName { get; }


        ISwitchFeature SwitchFeature { get; }


        ITemperatureFeature TemperatureFeature { get; }
    }
}
