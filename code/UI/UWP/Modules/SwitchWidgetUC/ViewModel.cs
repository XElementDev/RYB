using Prism.Commands;
using PropertyChanged;
using System.Windows.Input;

namespace XElement.RedYellowBlue.UI.UWP.Modules.SwitchWidget
{
#region not unit-tested
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public ViewModel( Model model )
        {
            this._needsRefresh = false;
            this.IsBusy = false;
            this.Model = model;
            this.TurnOffCommand = new DelegateCommand( this.TurnOffCommand_Execute, 
                                                       this.TurnOffOnCommand_CanExecute );
            this.TurnOnCommand = new DelegateCommand( this.TurnOnCommand_Execute, 
                                                      this.TurnOffOnCommand_CanExecute );
        }


        [AlsoNotifyFor( nameof( TurnOffCommand ), 
                        nameof( TurnOnCommand ) )]
        public bool IsBusy { get; private set; }


        [DoNotNotify]
        public Model Model { get; private set; }


        private async void SetStateAsync( bool value )
        {
            this.IsBusy = true;
            await this.Model.SetStateAsync( value );
            this._needsRefresh = true;
            this.IsBusy = false;
        }


        [DoNotNotify]
        public ICommand TurnOffCommand { get; private set; }

        private void TurnOffCommand_Execute()
        {
            this.SetStateAsync( false );
        }


        private bool TurnOffOnCommand_CanExecute()
        {
            return (!this.Model?.IsLocked ?? false) && !this.IsBusy && !this._needsRefresh;
        }


        [DoNotNotify]
        public ICommand TurnOnCommand { get; private set; }

        private void TurnOnCommand_Execute()
        {
            this.SetStateAsync( true );
        }


        private bool _needsRefresh;
    }
#endregion
}
