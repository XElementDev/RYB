using System.Collections.Generic;
using System.Threading.Tasks;

namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
    public interface IHttpService
    {
        IEnumerable<IDevice> GetDevices();


        bool IsLoginValid();

        Task<bool> IsLoginValidAsync();


        void SetSwitch( bool targetState, string ain );
    }
}
