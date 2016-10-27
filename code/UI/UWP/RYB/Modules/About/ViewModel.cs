using Mntone.SvgForXaml;
using System.Composition;
using Windows.UI.Xaml;

namespace XElement.RedYellowBlue.UI.UWP.Modules.About
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( About.Model model, ViewModelDepdenciesDTO dependencies )
        {
            this._dependencies = dependencies;
            this.Model = model;
        }


        public bool IsInDarkMode
        {
            get { return Application.Current.RequestedTheme == ApplicationTheme.Dark; }
        }


        public About.Model Model { get; private set; }


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
