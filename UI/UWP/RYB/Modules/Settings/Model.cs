using System;
using System.Composition;
using System.Windows.Input;
using XElement.RedYellowBlue.UI.UWP.Model;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Export]
    internal class Model
    {
        public Model() { }


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


        [Import]
        private Config _config { get; set; }
    }
#endregion
}
