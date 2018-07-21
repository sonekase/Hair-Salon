using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyStylistTests : IDisposable
  {
    public void Dispose()
    {
      SpecialtyStylist.DeleteAll();
    }
    public SpecialtyStylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=anousone_kaseumsouk_test;";
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      SpecialtyStylist testSpecialtyStylist = new SpecialtyStylist(1, 1);

      //Act
      testSpecialtyStylist.Save();
      SpecialtyStylist savedSpecialtyStylist = SpecialtyStylist.GetAll()[0];

      int result = savedSpecialtyStylist.GetId();
      int testId = testSpecialtyStylist.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }
  }
}
