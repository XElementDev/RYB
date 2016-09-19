using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using System.Composition;
using System.Windows.Input;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Shared] [Export]
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


        [DoNotNotify]
        public ICommand ValidateCommand { get; private set; }

        private void ValidateCommand_Execute()
        {
            this.Model.CheckLogin();
        }
    }
#endregion
}
