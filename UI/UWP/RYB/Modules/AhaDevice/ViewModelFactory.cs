using System.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.RedYellowBlue.UI.UWP.Resources;

namespace XElement.RedYellowBlue.UI.UWP.Modules.AhaDevice
{
#region not unit-tested
    [Shared] [Export( typeof( IFactory</*AhaDevice.*/ViewModel, /*AhaDevice.*/Model> ) )]
    internal class ViewModelFactory : IFactory</*AhaDevice.*/ViewModel, /*AhaDevice.*/Model>
    {
        [ImportingConstructor]
        public ViewModelFactory( SvgSwitch svgSwitch )
        {
            this._svgSwitch = svgSwitch;
        }


        public /*AhaDevice.*/ViewModel /*IFactory<TOut>.*/Get( /*AhaDevice.*/Model parameter )
        {
            var dependencies = new /*AhaDevice.*/ViewModelDependenciesDTO
            {
                SvgSwitch = this._svgSwitch
            };
            return new /*AhaDevice.*/ViewModel( parameter, dependencies );
        }


        private SvgSwitch _svgSwitch;
    }
#endregion
}
