using System.Web.Mvc;
using NUnit.Framework;
using PairingTest.Web.Controllers;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class ErrorControllerTest
    {
        private ErrorController _controller;

        [TestFixtureSetUp]
        public void Setup()
        {
            _controller = new ErrorController();
        }

        [Test]
        public void When_IsCalled_ReturnsTheProperView()
        {
            var res = _controller.Index();

            Assert.AreEqual(typeof(ViewResult), res.GetType());
            Assert.AreEqual("Error", res.ViewName);
        }
    }
}
