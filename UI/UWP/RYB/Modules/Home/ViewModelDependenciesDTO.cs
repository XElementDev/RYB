using System.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Home
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModelDependenciesDTO
    {
        [Import]
        public IFactory<AhaDevice.ViewModel, AhaDevice.Model> AhaDeviceVmFactory { get; set; }
    }
#endregion
}
