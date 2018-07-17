using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientControllerTest
    {
      [TestMethod]
      public void Index_ReturnsCorrectView_True()
      {
          //Arrange
          ClientController controller = new ClientController();

          //Act
          ActionResult indexView = controller.Index();

          //Assert
          Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }
      [TestMethod]
      public void Index_HasCorrectModelType_ClientList()
      {
        //Arrange
        ClientController controller = new ClientController();
        ActionResult actionResult = controller.Index();
        ViewResult indexView = controller.Index() as ViewResult;

        //Act
        var result = indexView.ViewData.Model;

        //Assert
        Assert.IsInstanceOfType(result, typeof(List<Client>));
      }
    }
}
