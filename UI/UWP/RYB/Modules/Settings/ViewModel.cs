using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using System;
using System.Composition;
using System.Windows.Input;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Export]
    [ImplementPropertyChanged]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( Settings.Model model )
        {
            this.Model = model;
            this.ValidateCommand = new RelayCommand( this.ValidateCommand_Execute );
        }


        public Settings.Model Model { get; private set; }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.Password = this.Model.Password;
            this.Url = this.Model.Url;
            this.Username = this.Model.Username;
        }


        public string Password { get; set; }


        public string Url { get; set; }


        public string Username { get; set; }


        [DoNotNotify]
        public ICommand ValidateCommand { get; private set; }

        private void ValidateCommand_Execute()
        {
            if ( (this.Password ?? String.Empty) == String.Empty )
                this.Password = this.Model.Password;
            else
                this.Model.Password = this.Password;

            if ( (this.Username ?? String.Empty) == String.Empty )
                this.Username = this.Model.Username;
            else
                this.Model.Username = this.Username;

            this.Model.CheckLogin();
        }
    }
#endregion
}
