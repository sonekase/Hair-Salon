using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class SalonClient
  {
    private int Id;
    private string Name;
    private string Stylist;

    public SalonClient(string newName, string newStylist = "", int newId =0)
    {
      Id = newId;
      Name = newName;
      Stylist = newStylist;
    }
    public int GetId()
    {
      return Id;
    }
    public string GetName()
    {
      return Name;
    }
    public string GetStylist()
    {
      return Stylist;
    }

    public override bool Equals(System.Object otherSalonClient)
    {
      if (!(otherSalonClient is SalonClient))
      {
        return false;
      }
      else
      {
        SalonClient newSalonClient = (SalonClient) otherSalonClient;
        bool idEqual = (this.GetId() == newSalonClient.GetId());
        bool nameEqual = (this.GetName() == newSalonClient.GetName());
        bool stylistEqual = (this.GetStylist() == newSalonClient.GetStylist());
        return (idEqual && nameEqual && stylistEqual);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO client (client_name, stylist_name) VALUES (@inputName, @inputStylist);";
      MySqlParameter newName = new MySqlParameter();
      newName.ParameterName = "@inputName";
      newName.Value = this.Name;
      cmd.Parameters.Add(newName);
      MySqlParameter newStylist = new MySqlParameter();
      newStylist.ParameterName = "@inputStylist";
      newStylist.Value = this.Stylist;
      cmd.Parameters.Add(newStylist);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
    }

    public static List<SalonClient> GetAll()
    {
      List<SalonClient> allSalonClient = new List<SalonClient> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
       {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string stylist = rdr.GetString(2);
        SalonClient newSalonClient = new SalonClient(name, stylist, id);
        allSalonClient.Add(newSalonClient);
       }
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
       return allSalonClient;
    }

    public static List<SalonClient> FindByClientName(string clientName)
    {
      List<SalonClient> foundSalonClient = new List<SalonClient> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client WHERE client_name LIKE @ClientName;";
      MySqlParameter foundClientName = new MySqlParameter();
      foundClientName.ParameterName = "@ClientName";
      foundClientName.Value = clientName + "%";
      cmd.Parameters.Add(foundClientName);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
       {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string stylist = rdr.GetString(2);
        SalonClient newSalonClient = new SalonClient(name, stylist, id);
        foundSalonClient.Add(newSalonClient);
       }
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
       return foundSalonClient;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM Client;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
       {
         conn.Dispose();
       }
    }
  }
}
