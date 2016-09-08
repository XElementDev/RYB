using System.Composition;
using System.Windows.Input;

namespace XElement.RedYellowBlue.UI.UWP
{
#region not unit-tested
    [Export]
    internal class MainViewModel
    {
        public MainViewModel()
        {
            //new DelegateCommand()
            //new RoutedCommand()
            //new RoutedUICommand()
            this.NavigationCommand = null; // TODO
        }


        public string Blubb { get; private set; }


        //[Import]
        //private Config Config { get; set; }


        public ICommand NavigationCommand { get; private set; }

        private void NavigationCommand_Execute( object obj )
        {
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            //var login = new Login( this.Config.Uri, this.Config.Username );
            //login.Do( this.Config.Password );
            //var sid = login.Sid;
            this.Blubb = "blubb.waogiherioguahegrhiarguraugigiauaurenvar0gmf,";// + "\t sid:" + sid;
        }
    }
#endregion
}
