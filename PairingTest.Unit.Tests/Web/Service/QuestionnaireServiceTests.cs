using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PairingTest.Web.Services;
using PairingTest.Web.Services.Exceptions;
using PairingTest.Web.Services.Wrapper;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi.Service
{
    [TestFixture]
    public class QuestionnaireServiceTests
    {
        private QuestionnaireService _service;
        private Mock<IHttpClientWrapper> _client;

        [TestFixtureSetUp]
        public void Setup()
        {
            _client = new Mock<IHttpClientWrapper>();
            _service = new QuestionnaireService(_client.Object);
        }

        [Test]
        public async void When_ClientResponseIsNotSuccessful_Then_ThrowsAnException()
        {
            // Setup
            _client.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(
                    Task.Run(
                        () => new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError }));

            // Act
            try
            {
                await _service.GetQuestionnaireAsync();
            }
            catch (Exception ex)
            {

                // Assert
                Assert.AreEqual(ex.GetType(), typeof(ServiceException));
                Assert.AreEqual(ex.Message, $"Error from service, status code: {HttpStatusCode.InternalServerError}");
            }
        }

        [Test]
        public async void When_ClientResponseIsOk_Then_ReturnsAQuestionnaire()
        {
            // Setup
            _client.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(
                    Task.Run(
                        () =>
                            new HttpResponseMessage
                            {
                                StatusCode = HttpStatusCode.OK,
                                Content = new StringContent("{ \"QuestionnaireTitle\" : \"title\", \"QuestionsText\" : [\"question1\", \"question2\"]}")
                            }));

            // Act
            var questionnaire = await _service.GetQuestionnaireAsync();

            // Assert
            Assert.AreEqual("title", questionnaire.Title);
            Assert.AreEqual(2, questionnaire.QuestionsText.Count());
            Assert.AreEqual("question1", questionnaire.QuestionsText.ToList()[0]);
            Assert.AreEqual("question2", questionnaire.QuestionsText.ToList()[1]);
        }
    }
}
