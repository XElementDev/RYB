using PropertyChanged;
using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Model;
using XElement.RedYellowBlue.UI.UWP.Modules.Main;

namespace XElement.RedYellowBlue.UI.UWP
{
#region not unit-tested
    [Shared] [Export]
    [ImplementPropertyChanged]
    internal class MainViewModel
    {
        [ImportingConstructor]
        public MainViewModel( ViewModelDependenciesDTO dependencies )
        {
            this.NavigateToCommand = new RelayCommand<HamburgerMenuItem>( this.NavigateToCommand_Execute );

            this._dependencies = dependencies;
        }


        //[DoNotNotify]
        //public Config Config { get; private set; } // TODO: Is that needed here?


        public object FrameDataContext { get; private set; }


        private string _header;

        public string Header
        {
            get { return this._header; }
            set { this._header = value.ToUpper(); }
        }


        private void Initialize()
        {
            this._dataContextPageTypeMap = this._dependencies.DataContextPageTypeMap;

            //this.Config = this._dependencies.Config;
            this.NavigationModel = this._dependencies.NavigationModel;
        }


        [DoNotNotify]
        public ICommand NavigateToCommand { get; private set; }

        private void NavigateToCommand_Execute( HamburgerMenuItem clickedItem )
        {
            this.Header = clickedItem.Label;
            this.NavigationModel.NavigateTo( clickedItem.TargetPageType );
        }


        [DoNotNotify]
        public NavigationModel NavigationModel { get; private set; }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.Initialize();
            this.SubscribeEvents();

            //var login = new Login( this.Config.Uri, this.Config.Username );
            //login.Do( this.Config.Password );
            //var sid = login.Sid;
        }


        private void SubscribeEvents()
        {
            this.NavigationModel.PropertyChanged += ( s, e ) =>
            {
                if ( e.PropertyName == nameof( this.NavigationModel.CurrentTarget ) )
                {
                    var currentNavTarget = this.NavigationModel.CurrentTarget;
                    var dataContext = this._dataContextPageTypeMap.Get( currentNavTarget );
                    this.FrameDataContext = dataContext;
                }
            };
        }


        private Model.DataContextPageTypeMap.Model _dataContextPageTypeMap;
        private ViewModelDependenciesDTO _dependencies;
    }
#endregion
}
