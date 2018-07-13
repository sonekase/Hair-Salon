using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/stylist")]
    public ActionResult Index()
    {
      List<SalonStylist> allSalonStylist = SalonStylist.GetAll();
      return View(allSalonStylist);
    }
    [HttpGet("/stylist/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/stylists/new")]
    public ActionResult Create(string stylistName, string detail)
    {
      string newDetail = "";
      if(!string.IsNullOrWhiteSpace(Request.Form["detail"]))
      {
        newDetail = detail;
      }
      SalonStylist allSalonStylist = new SalonStylist(stylistName, detail);
      allSalonStylist.Save();
      return RedirectToAction("Index");
    }
    [HttpPost("/stylists/search")]
    public ActionResult Search(string searchFx, string searchTerm)
    {
      List<SalonStylist> foundSalonStylist = new List<SalonStylist> {};
      if(searchFx.Equals("byStylist"))
      {
        foundSalonStylist = SalonStylist.FindByStylistName(searchTerm);
      }
      return View("Index", foundSalonStylist);
    }

  }
}
