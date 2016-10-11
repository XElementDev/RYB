using System.Composition;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Model.Api
{
#region not unit-tested
    [Shared] [Export( typeof( IHttpService ) )]
    internal class MefHttpService : HttpService, IHttpService
    {
        [ImportingConstructor]
        public MefHttpService( HttpServiceParametersDTO parameters, OptionalHttpServiceParametersDTO optional ) 
            : base( parameters, optional ) { }
    }


    [Shared] [Export( typeof( HttpServiceParametersDTO ) )]
    internal class MefParametersDTO : HttpServiceParametersDTO
    {
        [ImportingConstructor]
        public MefParametersDTO( IConfig config )
        {
            this.BoxUrl = config.BoxUrl;
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.SubscribeEvents();
        }


        private void SubscribeEvents()
        {
            // TODO: Update Service on Config change
        }
    }


    [Shared] [Export( typeof( OptionalHttpServiceParametersDTO ) )]
    internal class MefOptionalParametersDT : OptionalHttpServiceParametersDTO
    {
        [ImportingConstructor]
        public MefOptionalParametersDT( IConfig config )
        {
            this.Password = config.Password;
            this.Username = config.Username;
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.SubscribeEvents();
        }


        private void SubscribeEvents()
        {
            // TODO: Update Service on Config change
        }
    }
#endregion
}
