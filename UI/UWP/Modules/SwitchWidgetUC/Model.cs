using System.Threading.Tasks;

namespace XElement.RedYellowBlue.UI.UWP.Modules.SwitchWidget
{
#region not unit-tested
    public class Model
    {
        public Model( ModelParametersDTO parameters )
        {
            this._parameters = parameters;

            this.IsActive = this._parameters.SwitchFeature.IsActive;
        }


        public bool IsActive { get; private set; }


        public Task SetStateAsync( bool targetState )
        {
            var task = new Task( () => this._parameters.SwitchFeature.IsActive = targetState );
            task.Start();
            return task;
        }


        private ModelParametersDTO _parameters;
    }
#endregion
}
