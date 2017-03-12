namespace XElement.RedYellowBlue.UI.UWP.Modules.TemperatureWidget
{
#region not unit-tested
    public class Model
    {
        public Model( ModelParametersDTO parameters )
        {
            this.Temperature = parameters.TemperatureFeature.Temperature;
        }


        public float Temperature { get; private set; }
    }
#endregion
}
