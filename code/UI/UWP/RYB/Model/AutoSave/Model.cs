using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Model.AutoSave
{
#region not unit-tested
    [Shared] [Export]
    internal class Model
    {
        [ImportingConstructor]
        public Model( DependenciesDTO dependencies )
        {
            this._dependencies = dependencies;
        }


        private void OnAppSuspending()
        {
            foreach ( var autoSaveTarget in this._dependencies.AutoSaveTargets )
            {
                autoSaveTarget.Persist();
            }
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this._dependencies.AppStateManager.OnSuspending += this.OnAppSuspending;
        }


        private DependenciesDTO _dependencies;
    }
#endregion
}
