using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      SalonClient.DeleteAll();
    }
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=anousone_kaseumsouk_test;";
    }
    [TestMethod]
    public void GetTest_ReturnSalonClientField()
    {
     // arrange
      int id = 1;
      string name = "Client Test";
      string stylist= "Stylist Test";
      SalonClient testClient = new SalonClient(name, stylist, id);

     // act
      int resultId = testClient.GetId();
      string resultName = testClient.GetName();
      string resultStylist = testClient.GetStylist();

     // assert
      Assert.AreEqual(id, resultId);
      Assert.AreEqual(name, resultName);
      Assert.AreEqual(stylist, resultStylist);
    }
  }
}
