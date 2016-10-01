using System.Threading.Tasks;

namespace XElement.RedYellowBlue.UI.UWP.Modules.SwitchWidget
{
#region not unit-tested
    public class Model
    {
        public Model( ModelParametersDTO parameters )
        {
            this.IsActive = parameters.IsActive;
        }


        public bool IsActive { get; private set; }


        public Task SetStateAsync( bool targetState )
        {
            // TODO
            return Task.Delay( 5000 );
        }
    }
#endregion
}
