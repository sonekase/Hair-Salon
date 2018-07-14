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
      cmd.CommandText = @"INSERT INTO stylist (name, detail) VALUES (@inputName, @inputDetail);";
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
      cmd.CommandText = @"SELECT * FROM stylist;";
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
      cmd.CommandText = @"SELECT * FROM stylist WHERE id = @idPara;";
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
      cmd.CommandText = @"SELECT * FROM stylist WHERE name LIKE @stylistName;";
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

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylist;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
       {
         conn.Dispose();
       }
    }
  }
}
