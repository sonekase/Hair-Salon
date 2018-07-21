using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTests : IDisposable
  {
    public void Dispose()
    {
      Specialty.DeleteAll();
    }
    public SpecialtyTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=anousone_kaseumsouk_test;";
    }
    [TestMethod]
    public void GetTest_ReturnDataField()
    {
      // Arrange
      string testName = "Color";
      Specialty testSpecialty = new Specialty(testName);

      // act
      string resultName = testSpecialty.GetName();

      // assert
      Assert.AreEqual(testName, resultName);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfAllAreTheSame_Specialty()
    {
      // Arrange, Act
      Specialty firstSpecialty = new Specialty("testName");
      Specialty secondSpecialty = new Specialty("testName");

      // Assert
      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("testName");

      //Act
      testSpecialty.Save();
      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.GetId();
      int testId = testSpecialty.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }
  }
}
