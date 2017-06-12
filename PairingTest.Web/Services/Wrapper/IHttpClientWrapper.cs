using System.Net.Http;
using System.Threading.Tasks;

namespace PairingTest.Web.Services.Wrapper
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string uri);
    }
}
