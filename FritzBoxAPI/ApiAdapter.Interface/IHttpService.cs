using System.Threading.Tasks;

namespace XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter
{
    public interface IHttpService
    {
        bool IsLoginValid();

        Task<bool> IsLoginValidAsync();
    }
}
