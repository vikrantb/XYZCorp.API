using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XYZCorp.API;
using XYZCorp.API.Controllers;

namespace XYZCorp.API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
