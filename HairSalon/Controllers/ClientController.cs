using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/Clients")]
    public ActionResult Index()
    {
      List<Client> allClient = Client.GetAll();
      return View(allClient);
    }
    [HttpGet("/Clients/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/Clients/delete")]
    public ActionResult Delete(string deleteId)
    {
      int id = int.Parse(deleteId);
      Client.FindByClientId(id).Delete();
      return RedirectToAction("Index");
    }
    [HttpGet("/Clients/{id}")]
    public ActionResult ClientDetail(int id)
    {
      return View(Client.FindByClientId(id));
    }
    [HttpPost("/Clients/{clientId}/editname")]
    public ActionResult EditName(int clientId, string newName)
    {
      Client newClient = Client.FindByClientId(clientId);
      newClient.EditClientName(newName);
      string clientName = newClient.GetName();
      return RedirectToAction("ClientDetail", new { id = clientId});
    }
  }
}
