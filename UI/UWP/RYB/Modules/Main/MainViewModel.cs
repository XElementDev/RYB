using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Model;

namespace XElement.RedYellowBlue.UI.UWP
{
#region not unit-tested
    [Export]
    internal class MainViewModel
    {
        [ImportingConstructor]
        public MainViewModel( NavigationModel navigationModel )
        {
            this.NavigationModel = navigationModel;
        }


        //[Import]
        //private Config Config { get; set; }


        public NavigationModel NavigationModel { get; private set; }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            //var login = new Login( this.Config.Uri, this.Config.Username );
            //login.Do( this.Config.Password );
            //var sid = login.Sid;
        }
    }
#endregion
}
