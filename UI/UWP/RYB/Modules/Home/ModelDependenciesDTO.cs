using System.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;
using XElement.RedYellowBlue.UI.UWP.Model;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Home
{
#region not unit-tested
    [Shared] [Export]
    internal class ModelDependenciesDTO
    {
        [Import]
        public IFactory<AhaDevice.Model, IDevice> AhaDeviceModelFactory { get; set; }


        [Import]
        public IHttpService ApiService { get; set; }


        [Import]
        public IConfig Config { get; set; }
    }
#endregion
}
