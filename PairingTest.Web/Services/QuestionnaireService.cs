using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PairingTest.Web.Services.Exceptions;
using PairingTest.Web.Services.Models;
using PairingTest.Web.Services.Wrapper;

namespace PairingTest.Web.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IHttpClientWrapper _client;

        public QuestionnaireService(IHttpClientWrapper client)
        {
            _client = client;
        }

        public async Task<Questionnaire> GetQuestionnaireAsync()
        {
            var questionnaire = new Questionnaire();

            var response = await _client.GetAsync(ConfigurationManager.AppSettings["QuestionnaireServiceUri"]);

            if (!response.IsSuccessStatusCode)
                throw new ServiceException($"Error from service, status code: {response.StatusCode}");

            var questionniaResponse = JsonConvert.DeserializeObject<QuestionnaireResponse>(await response.Content.ReadAsStringAsync());
            questionnaire.QuestionsText = questionniaResponse.QuestionsText;
            questionnaire.Title = questionniaResponse.QuestionnaireTitle;

            return questionnaire;
        }
    }
}