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
    private int StylistId;

    public Client(string newName, int newStylistId, int newId = 0)
    {
      Id = newId;
      Name = newName;
      StylistId = newStylistId;
    }
    public int GetId()
    {
      return Id;
    }
    public string GetName()
    {
      return Name;
    }
    public int GetStylistId()
    {
      return StylistId;
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
        bool stylistIdEqual = (this.GetStylistId() == newClient.GetStylistId());
        return (idEqual && nameEqual && stylistIdEqual);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@inputName, @inputStylistId);";
      MySqlParameter newName = new MySqlParameter();
      newName.ParameterName = "@inputName";
      newName.Value = this.Name;
      cmd.Parameters.Add(newName);
      MySqlParameter newStylistId = new MySqlParameter();
      newStylistId.ParameterName = "@inputStylistId";
      newStylistId.Value = this.StylistId;
      cmd.Parameters.Add(newStylistId);
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
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
       {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(name, stylistId, id);
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
      cmd.CommandText = @"SELECT * FROM clients WHERE name LIKE @ClientName;";
      MySqlParameter foundClientName = new MySqlParameter();
      foundClientName.ParameterName = "@ClientName";
      foundClientName.Value = clientName + "%";
      cmd.Parameters.Add(foundClientName);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
       {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(name, stylistId, id);
        foundClient.Add(newClient);
       }
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
       return foundClient;
    }

    public static Client FindByClientId(int byId)
    {
      int id = 0;
      string name = "";
      int stylistId = 0;
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = @idPara;";
      MySqlParameter paraId = new MySqlParameter();
      paraId.ParameterName = "@idPara";
      paraId.Value = byId;
      cmd.Parameters.Add(paraId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        stylistId = rdr.GetInt32(2);
      }
      Client newClient = new Client(name, stylistId, id);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newClient;
    }

    public void EditClientName(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET name = @clientName WHERE id = @idPara;";
      MySqlParameter editName = new MySqlParameter();
      editName.ParameterName = "@clientName";
      editName.Value = newName;
      cmd.Parameters.Add(editName);
      MySqlParameter paraId = new MySqlParameter();
      paraId.ParameterName = "@idPara";
      paraId.Value = this.Id;
      cmd.Parameters.Add(paraId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"DELETE FROM clients WHERE id=@thisId;";
     MySqlParameter deleteId = new MySqlParameter();
     deleteId.ParameterName = "@thisId";
     deleteId.Value = this.Id;
     cmd.Parameters.Add(deleteId);
     cmd.ExecuteNonQuery();
     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
       {
         conn.Dispose();
       }
    }
  }
}
