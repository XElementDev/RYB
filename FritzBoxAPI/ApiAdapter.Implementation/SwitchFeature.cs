using XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109;

namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
#region not unit-tested
    internal class SwitchFeature : ISwitchFeature
    {
        public SwitchFeature( SwitchDTO initialValues )
        {
            this.IsActive = initialValues.State == 1;
        }


        public bool /*ISwitchFeature.*/IsActive { get; private set; }
    }
#endregion
}
