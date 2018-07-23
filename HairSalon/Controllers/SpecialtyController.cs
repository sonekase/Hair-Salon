using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/Specialty")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialty = Specialty.GetAll();
      return View(allSpecialty);
    }
    [HttpGet("/Specialty/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/Specialty")]
    public ActionResult ReturnForm(string specialtyName)
    {
      Specialty newSpecialty = new Specialty(specialtyName);
      newSpecialty.Save();
      return RedirectToAction("Index");
    }
    [HttpPost("/Specialty/delete")]
    public ActionResult Delete(int deleteId)
    {
      Specialty.FindBySpecialtyId(deleteId).Delete();
      return RedirectToAction("Index");
    }
  }
}
