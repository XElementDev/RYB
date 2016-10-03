using Mntone.SvgForXaml;
using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Modules.About
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( ViewModelDepdenciesDTO dependencies )
        {
            this._dependencies = dependencies;
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.Switch = this._dependencies.SvgSwitch.Svg;
            this.Thermostat = this._dependencies.SvgThermostat.Svg;
        }


        public SvgDocument Switch { get; private set; }


        public SvgDocument Thermostat { get; private set; }


        private ViewModelDepdenciesDTO _dependencies;
    }
#endregion
}
