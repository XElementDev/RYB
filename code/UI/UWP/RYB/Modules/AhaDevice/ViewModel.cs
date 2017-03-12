using Mntone.SvgForXaml;

namespace XElement.RedYellowBlue.UI.UWP.Modules.AhaDevice
{
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel( Model model, ViewModelDependenciesDTO dependencies )
        {
            this.Model = model;
            this.InitializeSvgImage( dependencies );
            this.SwitchWidgetVM = new SwitchWidget.ViewModel( this.Model.SwitchWidgetModel );
            this.TemperatureWidgetVM = new TemperatureWidget.ViewModel( this.Model.TemperatureWidgetModel );
            // TODO: run auto refresh in background
        }


        private void InitializeSvgImage( ViewModelDependenciesDTO dependencies )
        {
            if ( this.Model.IsASwitch )
            {
                this.SvgImage = dependencies.SvgSwitch.Svg;
            }
            else if ( this.Model.IsAThermostat )
            {
                this.SvgImage = dependencies.SvgThermostat.Svg;
            }
        }


        public bool IsImageVisible { get { return this.SvgImage != null; } }


        public Model Model { get; private set; }


        public SvgDocument SvgImage { get; private set; }


        public SwitchWidget.ViewModel SwitchWidgetVM { get; private set; }


        public TemperatureWidget.ViewModel TemperatureWidgetVM { get; private set; }
    }
#endregion
}
