using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Client
  {
    private int Id;
    private string Name;
    private string Stylist;

    public Client(string newName, string newStylist = "", int newId =0)
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

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEqual = (this.GetId() == newClient.GetId());
        bool nameEqual = (this.GetName() == newClient.GetName());
        bool stylistEqual = (this.GetStylist() == newClient.GetStylist());
        return (idEqual && nameEqual && stylistEqual);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO client (name, stylist) VALUES (@inputName, @inputStylist);";
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

    public static List<Client> GetAll()
    {
      List<Client> allClient = new List<Client> {};
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
        Client newClient = new Client(name, stylist, id);
        allClient.Add(newClient);
       }
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
       return allClient;
    }

    public static List<Client> FindByClientName(string clientName)
    {
      List<Client> foundClient = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client WHERE name LIKE @ClientName;";
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
        Client newClient = new Client(name, stylist, id);
        foundClient.Add(newClient);
       }
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
       return foundClient;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM client;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
       {
         conn.Dispose();
       }
    }
  }
}
