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
      Stylist.DeleteAll();
    }
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=anousone_kaseumsouk_test;";
    }
    [TestMethod]
    public void GetTest_ReturnStylistField()
    {
     // arrange
      int id = 1;
      string name = "Stylist Test";
      string detail = "Detail Test";
      Stylist testStylist = new Stylist(name, detail, id);

     // act
      int resultId = testStylist.GetId();
      string resultName = testStylist.GetName();
      string resultDetail = testStylist.GetDetail();

     // assert
      Assert.AreEqual(id, resultId);
      Assert.AreEqual(name, resultName);
      Assert.AreEqual(detail, resultDetail);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfNameAndDescriptionsAreTheSame_Stylist()
    {
      // Arrange, Act
      Stylist firstStylist = new Stylist("testName", "testDetail", 1);
      Stylist secondStylist = new Stylist("testName", "testDetail", 1);

      // Assert
      Assert.AreEqual(firstStylist, secondStylist);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Stylist testStylist = new Stylist("testName", "testDetail");

      //Act
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      //Assert
      Assert.AreEqual(result, testId);
    }
    [TestMethod]
    public void Find_FindByStylistId()
    {
      //Arrange
      Stylist testStylist = new Stylist("testName", "testDetail");
      testStylist.Save();

      //Act
      Stylist resultStylist = Stylist.FindByStylistId(testStylist.GetId());

      //Assert
      Assert.AreEqual(testStylist, resultStylist);
    }
    [TestMethod]
    public void FindByStylistByName()
    {
      //Arrange
      List<Stylist> testList = new List<Stylist> {};
      Stylist testStylist = new Stylist("testName", "testDetail");
      testStylist.Save();
      testList.Add(testStylist);

      //Act
      List<Stylist> resultList = Stylist.FindByStylistName(testStylist.GetName());

      //Assert
      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void Edit_UpdatesStylistNameInDatabase_String()
    {
      //Arrange
      string firstName = "Michael Jackson";
      Stylist testStylist = new Stylist("testName", "testDetail");
      testStylist.Save();
      string secondName = "Aubrey Graham";

      //Act
      testStylist.EditStylistName(secondName);

      string result = Stylist.FindByStylistId(testStylist.GetId()).GetName();

      //Assert
      Assert.AreEqual(secondName, result);
    }
    [TestMethod]
    public void Delete_DeleteStylistEntry()
    {
      // Arrange
      List<Stylist> testList = new List<Stylist> {};
      Stylist testStylist = new Stylist("testName", "testDetail");
      testStylist.Save();

      // Act
      Stylist.FindByStylistId(testStylist.GetId()).Delete();
      List<Stylist> resultList = Stylist.GetAll();

      // Assert
      CollectionAssert.AreEqual(testList, resultList);
    }
  }
}
