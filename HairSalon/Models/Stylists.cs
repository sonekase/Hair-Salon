using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int Id;
    private string Name;
    private string Detail;

    public Stylist(string newName, string newDetail, int newId =0)
    {
      Id = newId;
      Name = newName;
      Detail = newDetail;
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

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEqual = (this.GetId() == newStylist.GetId());
        bool nameEqual = (this.GetName() == newStylist.GetName());
        bool detailEqual = (this.GetDetail() == newStylist.GetDetail());
        return (idEqual && nameEqual && detailEqual);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name, detail) VALUES (@inputName, @inputDetail);";
      MySqlParameter newName = new MySqlParameter();
      newName.ParameterName = "@inputName";
      newName.Value = this.Name;
      cmd.Parameters.Add(newName);
      MySqlParameter newDetail = new MySqlParameter();
      newDetail.ParameterName = "@inputDetail";
      newDetail.Value = this.Detail;
      cmd.Parameters.Add(newDetail);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylist = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
       {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string detail = rdr.GetString(2);
        Stylist newStylist = new Stylist(name, detail, id);
        allStylist.Add(newStylist);
       }
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
       return allStylist;
    }

    public static Stylist FindByStylistId(int byId)
    {
      int id = 0;
      string name = "";
      string detail = "";
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = @idPara;";
      MySqlParameter paraId = new MySqlParameter();
      paraId.ParameterName = "@idPara";
      paraId.Value = byId;
      cmd.Parameters.Add(paraId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        detail = rdr.GetString(2);
      }
      Stylist newStylist = new Stylist(name, detail, id);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newStylist;
    }

    public static List<Stylist> FindByStylistName(string stylistName)
    {
      List<Stylist> foundStylist = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE name LIKE @stylistName;";
      MySqlParameter foundStylistName = new MySqlParameter();
      foundStylistName.ParameterName = "@stylistName";
      foundStylistName.Value = stylistName + "%";
      cmd.Parameters.Add(foundStylistName);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
       {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string detail = rdr.GetString(2);
        Stylist newStylist = new Stylist(name, detail, id);
        foundStylist.Add(newStylist);
       }
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
       return foundStylist;
    }

    public List<Client> GetAllClient()
    {
      List<Client> allClient = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylistId;";
      MySqlParameter clientStylistId = new MySqlParameter();
      clientStylistId.ParameterName = "@stylistId";
      clientStylistId.Value = this.Id;
      cmd.Parameters.Add(clientStylistId);
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

    public void EditStylistName(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name = @stylistName WHERE id = @idPara;";
      MySqlParameter editName = new MySqlParameter();
      editName.ParameterName = "@stylistName";
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

    public List<Specialty> GetAllStylistSpecialties()
    {
      List<Specialty> allSpecialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialties.* FROM specialties JOIN specialties_stylist ON (specialties.id = specialties_stylist.specialty_id) JOIN stylists ON (specialties_stylist.stylist_id = stylists.id) WHERE stylists.id = @stylistId;";
      MySqlParameter clientStylistId = new MySqlParameter();
      clientStylistId.ParameterName = "@stylistId";
      clientStylistId.Value = this.Id;
      cmd.Parameters.Add(clientStylistId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
       {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(name, id);
        allSpecialties.Add(newSpecialty);
       }
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
       return allSpecialties;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id=@thisId;";
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
      cmd.CommandText = @"DELETE FROM stylists;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
       {
         conn.Dispose();
       }
    }
  }
}
