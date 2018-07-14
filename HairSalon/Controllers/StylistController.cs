using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/Stylist")]
      public ActionResult ReturnForm()
      {
        return View();
      }
    [HttpPost("/Stylist/new")]
      public ActionResult ReturnForm(string newName, string newDetail)
      {
      Stylist newStylist = new Stylist(newName, newDetail);
      newStylist.Save();
        return View(newStylist);
      }
    [HttpGet("/Stylist/new")]
      public ActionResult CreateForm()
      {
        return View();
      }
    // [HttpGet("/stylist")]
    // public ActionResult Index()
    // {
    //   List<Stylist> allStylist = Stylist.GetAll();
    //   return View(allStylist);
    // }
    // [HttpGet("/stylist/new")]
    // public ActionResult CreateForm()
    // {
    //   return View();
    // }
    // [HttpPost("/stylists/new")]
    // public ActionResult Create(string stylistName, string detail)
    // {
    //   string newDetail = "";
    //   if(!string.IsNullOrWhiteSpace(Request.Form["detail"]))
    //   {
    //     newDetail = detail;
    //   }
    //   Stylist allStylist = new Stylist(stylistName, detail);
    //   allStylist.Save();
    //   return RedirectToAction("Index");
    // }
    // [HttpPost("/stylists/search")]
    // public ActionResult Search(string searchFx, string searchTerm)
    // {
    //   List<Stylist> foundStylist = new List<Stylist> {};
    //   if(searchFx.Equals("byStylist"))
    //   {
    //     foundStylist = Stylist.FindByStylistName(searchTerm);
    //   }
    //   return View("Index", foundStylist);
  }
}
