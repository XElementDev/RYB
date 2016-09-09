using PropertyChanged;
using System;
using System.Composition;
using System.Windows.Input;
using XElement.RedYellowBlue.UI.UWP.Model;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Export]
    [ImplementPropertyChanged]
    internal class Model
    {
        [ImportingConstructor]
        public Model( Config config )
        {
            this._config = config;
        }


        [DoNotNotify]
        public ICommand OkayCommand { get; private set; }

        private void OkayCommand_Execute()
        {
            if ( (this.Username ?? String.Empty) == String.Empty )
                this.Username = this._config.Username;
            else
                this._config.Username = this.Username;
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.Username = this._config.Username;
        }


        public string Username { get; set; }


        private Config _config;
    }
#endregion
}
