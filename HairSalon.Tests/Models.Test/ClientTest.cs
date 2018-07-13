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
    [TestMethod]
    public void Equals_ReturnsTrueIfNameAndStylistAreTheSame_SalonClient()
    {
      // Arrange, Act
      SalonClient firstSalonClient = new SalonClient("testName", "testStylist",1);
      SalonClient secondSalonClient = new SalonClient("testName", "testStylist",1);

      // Assert
      Assert.AreEqual(firstSalonClient, secondSalonClient);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      SalonClient testSalonClient = new SalonClient("testName", "testStylist");

      //Act
      testSalonClient.Save();
      SalonClient savedSalonClient = SalonClient.GetAll()[0];

      int result = savedSalonClient.GetId();
      int testId = testSalonClient.GetId();

      //Assert
      Assert.AreEqual(result, testId);
    }
    [TestMethod]
    public void FindByClientName()
    {
      //Arrange
      List<SalonClient> testList = new List<SalonClient> {};
      SalonClient testSalonClient = new SalonClient("testName", "testStylist");
      testSalonClient.Save();
      testList.Add(testSalonClient);

      //Act
      List<SalonClient> resultList = SalonClient.FindByClientName(testSalonClient.GetName());

      //Assert
      CollectionAssert.AreEqual(testList, resultList);
    }
  }
}
