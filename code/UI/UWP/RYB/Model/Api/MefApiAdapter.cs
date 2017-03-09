using System.Composition;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Model.Api
{
    [Shared] [Export( typeof( IHttpService ) )]
    internal class MefHttpService : HttpService, IHttpService
    {
        [ImportingConstructor]
        public MefHttpService( HttpServiceParametersDTO parameters, 
                               OptionalHttpServiceParametersDTO optional ) 
            : base( parameters, optional ) { }
    }


    [Shared] [Export( typeof( HttpServiceParametersDTO ) )]
    internal class MefParametersDTO : HttpServiceParametersDTO
    {
        [ImportingConstructor]
        public MefParametersDTO( IConfig config )
        {
            this._config = config;
            this.SubscribeEvents();
            this.UpdatePropertyValues();
        }


        private void SubscribeEvents()
        {
            this._config.PropertyChanged += ( s, e ) => this.UpdatePropertyValues();
        }


        private void UpdatePropertyValues()
        {
            this.BoxUrl = this._config.BoxUrl;
        }


        private IConfig _config;
    }


    [Shared] [Export( typeof( OptionalHttpServiceParametersDTO ) )]
    internal class MefOptionalParametersDT : OptionalHttpServiceParametersDTO
    {
        [ImportingConstructor]
        public MefOptionalParametersDT( IConfig config )
        {
            this._config = config;
            this.UpdatePropertyValues();
            this.SubscribeEvents();
        }


        private void SubscribeEvents()
        {
            this._config.PropertyChanged += ( s, e ) => this.UpdatePropertyValues();
        }


        private void UpdatePropertyValues()
        {
            this.Password = this._config.Password;
            this.Username = this._config.Username;
        }


        private IConfig _config;
    }
}
