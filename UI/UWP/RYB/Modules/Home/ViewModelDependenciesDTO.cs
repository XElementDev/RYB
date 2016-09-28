using System.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Home
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModelDependenciesDTO
    {
        [Import]
        public IFactory<AhaDevice.ViewModel, IDevice> AhaDeviceVmFactory { get; set; }
    }
#endregion
}
