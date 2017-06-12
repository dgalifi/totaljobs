using System.Threading.Tasks;
using System.Web.Mvc;
using PairingTest.Web.Mappers;
using PairingTest.Web.Models;
using PairingTest.Web.Services;
using PairingTest.Web.Services.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireService _service;

        private readonly IMapper _mapper;

        public QuestionnaireController(IQuestionnaireService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ViewResult> Index()
        {
            var questionnaire = await _service.GetQuestionnaireAsync();

            var viewModel = _mapper.Map<Questionnaire, QuestionnaireViewModel>(questionnaire);

            return View(viewModel);
        }
    }
}
