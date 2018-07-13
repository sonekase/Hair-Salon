using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class SalonStylist
  {
    private int Id;
    private string Name;
    private string Detail;
    private string Client;

    public SalonStylist(string newName, string newDetail, string newClient = "", int newId =0)
    {
      Id = newId;
      Name = newName;
      Detail = newDetail;
      Client = newClient;
    }
    public int GetId()
    {
      return Id;
    }
    public string GetName()
    {
      return Name;
    }
    public string GetDetail()
    {
      return Detail;
    }
    public string GetClient()
    {
      return Client;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM Stylist;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
       {
         conn.Dispose();
       }
    }
  }
}
