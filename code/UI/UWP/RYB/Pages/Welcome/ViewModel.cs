using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using System;
using System.Composition;
using System.Windows.Input;
using XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Welcome
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public ViewModel( Model model )
        {
            this._model = model;

            this.FinishSetupCommand = new RelayCommand( this.FinishSetupCommand_Execute, 
                                                        this.FinishSetupCommand_CanExecute );
        }


        private string _boxUrlAsString;

        public string BoxUrlAsString
        {
            get { return this._boxUrlAsString; }
            set
            {
                this._boxUrlAsString = value;
                this.RunLoginRecognizerAsync();
            }
        }


        [DoNotNotify]
        public ICommand FinishSetupCommand { get; private set; }

        private bool FinishSetupCommand_CanExecute()
        {
            var usernameNotNullOrEmpty = (this.Username ?? String.Empty) != String.Empty;
            var passwordNotNullOrEmpty = (this.Password ?? String.Empty) != String.Empty;
            if ( usernameNotNullOrEmpty && passwordNotNullOrEmpty )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FinishSetupCommand_Execute()
        {
            this._model.FinishSetup( this.BoxUrlAsString, this.Username, this.Password );

            this.Password = null;
        }


        public bool IsLoginRecognizerRunning { get; private set; }


        private string _password;

        public string Password
        {
            get { return this._password; }
            set
            {
                this._password = value;
                this.RaisePropertyChanged( nameof( FinishSetupCommand ) );
            }
        }


        private async void RunLoginRecognizerAsync()
        {
            this.IsLoginRecognizerRunning = true;
            var loginType = await this._model.GetLoginTypeAsync( this.BoxUrlAsString );
            this.IsLoginRecognizerRunning = false;
            if ( loginType == LoginType.USER_BASED )
            {
                this.ShowPasswordField = true;
                this.ShowUsernameField = true;
            }
        }


        public bool ShowPasswordField { get; private set; }


        public bool ShowUsernameField { get; private set; }


        private string _username;

        public string Username
        {
            get { return this._username; }
            set
            {
                this._username = value;
                this.RaisePropertyChanged( nameof( FinishSetupCommand ) );
            }
        }


        private Model _model;
    }
#endregion
}
