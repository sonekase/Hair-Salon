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
      string stylist= "Stylist Test";
      Client testClient = new Client(name, stylist, id);

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
    public void Equals_ReturnsTrueIfNameAndStylistAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("testName", "testStylist",1);
      Client secondClient = new Client("testName", "testStylist",1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Client testClient = new Client("testName", "testStylist");

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
      Client testClient = new Client("testName", "testStylist");
      testClient.Save();
      testList.Add(testClient);

      //Act
      List<Client> resultList = Client.FindByClientName(testClient.GetName());

      //Assert
      CollectionAssert.AreEqual(testList, resultList);
    }
  }
}
