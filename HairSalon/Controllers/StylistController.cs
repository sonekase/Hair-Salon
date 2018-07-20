using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/Stylists")]
      public ActionResult Index()
      {
        List<Stylist> allStylist = Stylist.GetAll();
        return View(allStylist);
      }
    [HttpPost("/Stylists")]
      public ActionResult ReturnForm(string newName, string newDetail)
      {
      Stylist newStylist = new Stylist(newName, newDetail);
      newStylist.Save();
        return RedirectToAction("Index");
      }
    [HttpGet("/Stylists/new")]
      public ActionResult CreateForm()
      {
        return View();
      }
    [HttpPost("/Stylists/delete")]
      public ActionResult Delete(string deleteId)
      {
        int id = int.Parse(deleteId);
        Stylist.FindByStylistId(id).Delete();
        return RedirectToAction("Index");
      }
    [HttpGet("Stylists/{id}")]
    public ActionResult StylistDetail(int id)
    {
      return View(Stylist.FindByStylistId(id));
    }
    [HttpPost("Stylist/{stylistId}/editname")]
    public ActionResult EditName(int stylistId, string newName)
    {
      Stylist newStylist = Stylist.FindByStylistId(stylistId);
      newStylist.EditStylistName(newName);
      string stylistName = newStylist.GetName();
      return RedirectToAction("StylistDetail", new { id = stylistId});
    }
    [HttpPost("Stylists/{stylistId}/addclient")]
    public ActionResult AddClient(int stylistId, string clientName)
    {
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      return RedirectToAction("StylistDetail", new { id = stylistId});
    }
    [HttpPost("/Stylist/deleteclient/{stylistName}")]
    public ActionResult DeleteClient(int clientId, string stylistName)
    {
      Client.FindByClientId(clientId).Delete();
      return RedirectToAction("StylistDetail", new { name = stylistName});
    }
    [HttpGet("Stylists/search")]
    public ActionResult SearchForm()
    {
      return View();
    }
    [HttpPost("Stylists/search")]
    public ActionResult ReturnStylist(string searchName)
    {
      List<Stylist> newStylist = Stylist.FindByStylistName(searchName);
      return View("Index", newStylist);
    }
  }
}
