using XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_;

namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
#region not unit-tested
    internal class TemperatureFeature : ITemperatureFeature
    {
        public TemperatureFeature( TemperatureDTO initialValue )
        {
            // -->  TODO: What about the Offset?
            var celsius = (float)initialValue.Celsius;
            this.Temperature = celsius / 10;
        }


        public float /*ITemperatureFeature.*/Temperature { get; private set; }
    }
#endregion
}
