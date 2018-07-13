using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/client")]
    public ActionResult Index()
    {
      List<SalonClient> allSalonClient = SalonClient.GetAll();
      return View(allSalonClient);
    }
    [HttpGet("/client/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
  }
}
