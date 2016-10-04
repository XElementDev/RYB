using XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109;

namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
#region not unit-tested
    internal class SwitchFeature : ISwitchFeature
    {
        public SwitchFeature( SwitchDTO initialValues, IHttpService httpService, string ain )
        {
            this._ain = ain;
            this._httpService = httpService;
            this._isActive = initialValues.State == 1;
        }


        private bool _isActive;

        public bool /*ISwitchFeature.*/IsActive
        {
            get { return this._isActive; }
            set { this.SetIsActive( value ); }
        }


        private void SetIsActive( bool targetState )
        {
            this._httpService.SetSwitch( targetState, this._ain );
        }


        private string _ain;

        private IHttpService _httpService;
    }
#endregion
}
