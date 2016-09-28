using System.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;
using XElement.RedYellowBlue.UI.UWP.Resources;

namespace XElement.RedYellowBlue.UI.UWP.Modules.AhaDevice
{
#region not unit-tested
    [Shared] [Export( typeof( IFactory</*AhaDevice.*/ViewModel, IDevice> ) )]
    internal class ViewModelFactory : IFactory</*AhaDevice.*/ViewModel, IDevice>
    {
        [ImportingConstructor]
        public ViewModelFactory( SvgSwitch svgSwitch )
        {
            this._svgSwitch = svgSwitch;
        }


        public /*AhaDevice.*/ViewModel /*IFactory<TOut>.*/Get( IDevice parameter )
        {
            var dependencies = new ViewModelDependenciesDTO
            {
                SvgSwitch = this._svgSwitch
            };
            return new ViewModel( parameter, dependencies );
        }


        private SvgSwitch _svgSwitch;
    }
#endregion
}
