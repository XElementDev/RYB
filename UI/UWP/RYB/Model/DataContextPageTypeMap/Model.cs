using System;
using System.Collections.Generic;
using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Modules;

namespace XElement.RedYellowBlue.UI.UWP.Model.DataContextPageTypeMap
{
#region not unit-tested
    [Shared] [Export]
    internal class Model
    {
        [ImportingConstructor]
        public Model( ModelDependenciesDTO dependencies )
        {
            this._dependencies = dependencies;
        }


        private void InitializeMap()
        {
            this._map = new Dictionary<Type, object>();
            this._map[typeof( HomePage )] = this._dependencies.HomeVM;
            this._map[typeof( SettingsPage )] = this._dependencies.SettingsVM;
        }


        public object Get( Type pageType )
        {
            object dataContext = null;

            try { dataContext = this._map[pageType]; }
            catch ( KeyNotFoundException ) { }

            return dataContext;
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.InitializeMap();
        }


        private ModelDependenciesDTO _dependencies;
        private IDictionary<Type, object> _map;
    }
#endregion
}
