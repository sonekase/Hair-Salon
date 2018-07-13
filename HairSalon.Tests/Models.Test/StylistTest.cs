using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public void Dispose()
    {
      SalonStylist.DeleteAll();
    }
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=anousone_kaseumsouk_test;";
    }
    [TestMethod]
    public void GetTest_ReturnSalonStylistField()
    {
     // arrange
      int id = 1;
      string name = "Stylist Test";
      string detail = "Detail Test";
      string client = "Client Test";
      SalonStylist testStylist = new SalonStylist(name, detail, client, id);

     // act
      int resultId = testStylist.GetId();
      string resultName = testStylist.GetName();
      string resultDetail = testStylist.GetDetail();
      string resultClient = testStylist.GetClient();

     // assert
      Assert.AreEqual(id, resultId);
      Assert.AreEqual(name, resultName);
      Assert.AreEqual(detail, resultDetail);
      Assert.AreEqual(client, resultClient);
    }
  }
}
