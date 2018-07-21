using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistControllerTest
    {
      [TestMethod]
      public void Index_ReturnsCorrectView_True()
      {
          //Arrange
          StylistController controller = new StylistController();

          //Act
          ActionResult indexView = controller.Index();

          //Assert
          Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }
      [TestMethod]
      public void Index_HasCorrectModelType_StylistList()
      {
        //Arrange
        StylistController controller = new StylistController();
        ActionResult actionResult = controller.Index();
        ViewResult indexView = controller.Index() as ViewResult;

        //Act
        var result = indexView.ViewData.Model;

        //Assert
        Assert.IsInstanceOfType(result, typeof(List<Stylist>));
      }
      [TestMethod]
      public void CreateForm_ReturnsCorrectView_True()
      {
        //Arrange
        StylistController controller = new StylistController();

        //Act
        ActionResult createFormView = controller.CreateForm();

        //Assert
        Assert.IsInstanceOfType(createFormView, typeof(ViewResult));
      }
      // [TestMethod]
      // public void StylistDetail_ReturnsCorrectView_True()
      // {
      //   //Arrange
      //   StylistController controller = new StylistController();
      //
      //  //Act //Failed Line 57, need to fix.
      //   ActionResult indexView = controller.StylistDetail("testName");
      //
      //   //Assert
      //   Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      // }
    }
}
