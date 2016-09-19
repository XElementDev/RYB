using System.Composition;
using Windows.UI.Xaml;

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

            Application.Current.Suspending += ( s, e ) => this.OnAppSuspending();
        }


        private void OnAppSuspending()
        {
            foreach ( var autoSaveTarget in this._dependencies.AutoSaveTargets )
            {
                autoSaveTarget.Persist();
            }
        }


        private DependenciesDTO _dependencies;
    }
#endregion
}
