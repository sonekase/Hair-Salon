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
      public ActionResult Index()
      {
        List<Stylist> allStylist = Stylist.GetAll();
        return View(allStylist);
      }
    [HttpPost("/Stylist")]
      public ActionResult ReturnForm(string newName, string newDetail)
      {
      Stylist newStylist = new Stylist(newName, newDetail);
      newStylist.Save();
        return RedirectToAction("Index");
      }
    [HttpGet("/Stylist/new")]
      public ActionResult CreateForm()
      {
        return View();
      }
    [HttpPost("/Stylist/delete")]
      public ActionResult Delete(string deleteId)
      {
        int id = int.Parse(deleteId);
        Stylist.FindByStylistId(id).Delete();
        return RedirectToAction("Index");
      }
    [HttpGet("Stylist/{name}")]
    public ActionResult StylistDetail(string name)
    {
      return View(Stylist.FindByStylistName(name)[0]);
    }
    [HttpPost("Stylists/{stylistName}/addclient")]
    public ActionResult AddClient(string stylistName, string clientName)
    {
      Client newClient = new Client(clientName, stylistName);
      newClient.Save();
      return RedirectToAction("StylistDetail", new { name = stylistName});
    }
    [HttpGet("Stylist/search")]
    public ActionResult SearchForm()
    {
      return View();
    }
    [HttpPost("Stylist/search")]
    public ActionResult ReturnStylist(string searchName)
    {
      List<Stylist> newStylist = Stylist.FindByStylistName(searchName);
      return View("Index", newStylist);
    }
  }
}
