using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PairingTest.Web.Services;
using PairingTest.Web.Services.Wrapper;

namespace PairingTest.Web.Tests
{
    [TestClass]
    public class QuestionnaireServiceTest
    {
        private QuestionnaireService _service;
        private Mock<IHttpClientWrapper> _client;

        [TestInitialize]
        public void Setup()
        {
            _client = new Mock<IHttpClientWrapper>();
            _service = new QuestionnaireService(_client.Object);
        }

        [TestMethod]
        public void Test()
        {

        }
    }
}
