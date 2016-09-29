using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Controls;
using PropertyChanged;
using System.Composition;
using System.Windows.Input;
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


        [DependsOn( nameof( Header ) )]
        public string BigHeader { get { return this.Header; }}


        public object FrameDataContext { get; private set; }


        private string Header { get; set; }


        private void Initialize()
        {
            this._dataContextPageTypeMap = this._dependencies.DataContextPageTypeMap;
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

        }


        [DependsOn( nameof( Header ) )]
        public string SmallHeader { get { return this.Header.ToUpper(); } }


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
