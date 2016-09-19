using System;
using System.Collections.Generic;
using System.Composition;
using System.Threading;

namespace XElement.RedYellowBlue.UI.UWP.Model.AutoSave
{
#region not unit-tested
    [Shared] [Export]
    internal class Model
    {
        [ImportingConstructor]
        public Model( DependenciesDTO dependencies )
        {
            this._autoSaveTargetMap = new Dictionary<IAutoSaveTarget, IAutoSaveTarget>();
            this._dependencies = dependencies;
            //this.LastPersist = null;
        }


        private void InitializeMap()
        {
            foreach ( var target in this._dependencies.AutoSaveTargets )
            {
                this._autoSaveTargetMap[target] = target.DeepClone();
            }
        }


        //  --> TODO: Export via Interface
        //public DateTime? LastPersist { get; private set; }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.InitializeMap();
            this.StartRestartTimer();
        }


        private void OnTimerElapsed( object state )
        {
            this.StopTimer();

            var map = new Dictionary<IAutoSaveTarget, IAutoSaveTarget>();
            foreach ( var kvp in this._autoSaveTargetMap )
            {
                var newTarget = kvp.Key;
                var oldTarget = kvp.Value;
                if ( newTarget.NeedsToBePersisted( oldTarget ) )
                {
                    newTarget.Persist();
                    //this.LastPersist = DateTime.Now;
                }
                map[newTarget] = newTarget.DeepClone();
            }
            this._autoSaveTargetMap = map;

            this.StartRestartTimer();
        }


        private void StartRestartTimer()
        {
            var startDirectly = new TimeSpan( 0 );
            var period = new TimeSpan( hours: 0, minutes: 0, seconds: 5 );

            if ( this._timer == null )
                this._timer = new Timer( this.OnTimerElapsed, null, startDirectly, period );
            else
                this._timer.Change( startDirectly, period );
        }


        private void StopTimer()
        {
            var noRestart = Timeout.Infinite;
            var noPeriod = Timeout.Infinite;
            this._timer.Change( noRestart, noPeriod );
        }


        private IDictionary<IAutoSaveTarget, IAutoSaveTarget> _autoSaveTargetMap;

        private DependenciesDTO _dependencies;

        private Timer _timer;
    }
#endregion
}
