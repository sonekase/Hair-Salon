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
      Client.DeleteAll();
    }
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=anousone_kaseumsouk_test;";
    }
    [TestMethod]
    public void GetTest_ReturnClientField()
    {
     // arrange
      int id = 1;
      string name = "Client Test";
      int stylistId= 1;
      Client testClient = new Client(name, stylistId, id);

     // act
      int resultId = testClient.GetId();
      string resultName = testClient.GetName();
      int resultStylistId = testClient.GetStylistId();

     // assert
      Assert.AreEqual(id, resultId);
      Assert.AreEqual(name, resultName);
      Assert.AreEqual(stylistId, resultStylistId);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfNameAndStylistAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("testName", 1, 1);
      Client secondClient = new Client("testName", 1, 1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Client testClient = new Client("testName", 1);

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      //Assert
      Assert.AreEqual(result, testId);
    }
    [TestMethod]
    public void FindByClientName()
    {
      //Arrange
      List<Client> testList = new List<Client> {};
      Client testClient = new Client("testName", 1);
      testClient.Save();
      testList.Add(testClient);

      //Act
      List<Client> resultList = Client.FindByClientName(testClient.GetName());

      //Assert
      CollectionAssert.AreEqual(testList, resultList);
    }
  }
}
