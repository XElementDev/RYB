using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
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

            this.InitializeCommands();
            this.InitializeProperties();
        }


        public string BoxUrlAsString { get; set; }


        [DoNotNotify]
        [DependsOn( nameof( BoxUrlAsString ), 
                    nameof( Password ), 
                    nameof( SelectedLoginType ), 
                    nameof( Username ) )]
        public ICommand FinishSetupCommand { get; private set; }

        private bool FinishSetupCommand_CanExecute()
        {
            bool uriNotNullOrEmpty = (this.BoxUrlAsString ?? String.Empty) != String.Empty;
            bool usernameNotNullOrEmpty = (this.Username ?? String.Empty) != String.Empty;
            bool passwordNotNullOrEmpty = (this.Password ?? String.Empty) != String.Empty;

            bool validPasswordBasedLogin = this.SelectedLoginType == LoginType.PASSWORD_BASED && 
                                           passwordNotNullOrEmpty;
            bool validUserBasedLogin = this.SelectedLoginType == LoginType.USER_BASED && 
                                       usernameNotNullOrEmpty && 
                                       passwordNotNullOrEmpty;

            bool isInputValidWrtSyntax = uriNotNullOrEmpty && 
                (this.SelectedLoginType == LoginType.ANONYMOUS || 
                 validPasswordBasedLogin || 
                 validUserBasedLogin);
            return isInputValidWrtSyntax;
        }

        private void FinishSetupCommand_Execute()
        {
            this._model.FinishSetup( this.BoxUrlAsString, this.Username, this.Password );

            this.Password = null;
        }


        private void InitializeCommands()
        {
            this.FinishSetupCommand = new RelayCommand( this.FinishSetupCommand_Execute, 
                                                        this.FinishSetupCommand_CanExecute );
        }

        private void InitializeProperties()
        {
            this.LoginTypes = Enum.GetValues( typeof( LoginType ) )
                .Cast<LoginType>()
                .Except( new LoginType[] { default( LoginType ) } )
                .ToList();
            this.SelectedLoginType = LoginType.ANONYMOUS;
        }


        public bool IsLoginRecognizerRunning { get; private set; }


        public IEnumerable<LoginType> LoginTypes { get; private set; }


        public string Password { get; set; }


        public LoginType SelectedLoginType { get; set; }


        [DependsOn( nameof( SelectedLoginType ) )]
        public bool ShowPasswordField
        {
            get
            {
                return this.SelectedLoginType == LoginType.PASSWORD_BASED || 
                       this.SelectedLoginType == LoginType.USER_BASED;
            }
        }


        [DependsOn( nameof( SelectedLoginType ) )]
        public bool ShowUsernameField
        {
            get { return this.SelectedLoginType == LoginType.USER_BASED; }
        }


        public string Username { get; set; }


        private Model _model;
    }
#endregion
}
