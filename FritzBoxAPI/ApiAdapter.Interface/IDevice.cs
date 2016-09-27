namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
    public interface IDevice
    {
        bool IsConnected { get; }


        //bool IsConnected();


        string Manufacturer { get; }


        string Name { get; }


        string ProductName { get; }
    }
}
