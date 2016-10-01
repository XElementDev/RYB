using Prism.Commands;
using PropertyChanged;
using System.Windows.Input;

namespace XElement.RedYellowBlue.UI.UWP.Modules.SwitchWidget
{
#region not unit-tested
    [ImplementPropertyChanged]
    public class ViewModel
    {
        public ViewModel( Model model )
        {
            this.IsBusy = false;
            this.Model = model;
            this.TurnOffCommand = new DelegateCommand( this.TurnOffCommand_Execute, 
                                                       this.TurnOffCommand_CanExecute );
            this.TurnOnCommand = new DelegateCommand( this.TurnOnCommand_Execute, 
                                                      this.TurnOnCommand_CanExecute );
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
            this.IsBusy = false;
        }


        [DoNotNotify]
        public ICommand TurnOffCommand { get; private set; }

        private bool TurnOffCommand_CanExecute()
        {
            return !this.IsBusy;
        }

        private void TurnOffCommand_Execute()
        {
            this.SetStateAsync( false );
        }


        [DoNotNotify]
        public ICommand TurnOnCommand { get; private set; }

        private bool TurnOnCommand_CanExecute()
        {
            return !this.IsBusy;
        }

        private void TurnOnCommand_Execute()
        {
            this.SetStateAsync( true );
        }
    }
#endregion
}
