using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Mappers;
using PairingTest.Web.Models;
using PairingTest.Web.Services;
using PairingTest.Web.Services.Exceptions;
using PairingTest.Web.Services.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTest
    {
        private QuestionnaireController _controller;

        private Mock<IQuestionnaireService> _service;

        private Mock<IMapper> _mapper;

        [TestFixtureSetUp]
        public void Setup()
        {
            _mapper = new Mock<IMapper>();
            _service = new Mock<IQuestionnaireService>();

            _controller = new QuestionnaireController(_service.Object, _mapper.Object);
        }

        [Test]
        public async void When_ServiceThrowsAnException_Then_ItRaisesIt()
        {
            // Setup
            _service.Setup(x => x.GetQuestionnaireAsync()).Throws(new ServiceException("testEx"));

            // Act
            try
            {
                await _controller.Index();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ServiceException), ex.GetType());
                Assert.AreEqual("testEx", ex.Message);
            }
        }

        [Test]
        public async void When_IndexIsCalled_Then_ReturnsTheRightView()
        {
            // Setup
            var quest = new Questionnaire {Title = "title1", QuestionsText = new[] {"q1", "q2"}};
            _service.Setup(x => x.GetQuestionnaireAsync()).Returns(Task.Run(() => quest));
            _mapper.Setup(x => x.Map<Questionnaire, QuestionnaireViewModel>(It.IsAny<Questionnaire>()))
                .Returns(new QuestionnaireViewModel
                {
                    QuestionsText = quest.QuestionsText.ToList(),
                    QuestionnaireTitle = quest.Title
                });

            // Act
            var view = await _controller.Index();

            // Assert
            Assert.AreEqual(typeof(QuestionnaireViewModel), view.Model.GetType());
            Assert.AreEqual(quest.QuestionsText.ToList()[0], (view.Model as QuestionnaireViewModel).QuestionsText.ToList()[0]);
            Assert.AreEqual(quest.QuestionsText.ToList()[1], (view.Model as QuestionnaireViewModel).QuestionsText.ToList()[1]);
            Assert.AreEqual(quest.Title, (view.Model as QuestionnaireViewModel).QuestionnaireTitle);
            _service.Verify(x => x.GetQuestionnaireAsync(), Times.Once);
            _mapper.Verify(x => x.Map<Questionnaire, QuestionnaireViewModel>(
                It.Is<Questionnaire>(q => q.Title == quest.Title && q.QuestionsText.Count() == quest.QuestionsText.Count())), Times.Once);
        }
    }
}
