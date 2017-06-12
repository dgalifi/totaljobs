using System.Threading.Tasks;
using PairingTest.Web.Services.Models;

namespace PairingTest.Web.Services
{
    public interface IQuestionnaireService
    {
        Task<Questionnaire> GetQuestionnaireAsync();
    }
}
