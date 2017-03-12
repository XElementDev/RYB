namespace XElement.RedYellowBlue.UI.UWP.Modules.TemperatureWidget
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( Model model )
        {
            this._model = model;
        }


        public string Temperature
        {
            get { return $"{ this._model.Temperature }°C"; }
        }


        public Model _model;
    }
#endregion
}
