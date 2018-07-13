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

    public override bool Equals(System.Object otherSalonStylist)
    {
      if (!(otherSalonStylist is SalonStylist))
      {
        return false;
      }
      else
      {
        SalonStylist newSalonStylist = (SalonStylist) otherSalonStylist;
        bool idEqual = (this.GetId() == newSalonStylist.GetId());
        bool nameEqual = (this.GetName() == newSalonStylist.GetName());
        bool detailEqual = (this.GetDetail() == newSalonStylist.GetDetail());
        bool clientEqual = (this.GetClient() == newSalonStylist.GetClient());
        return (idEqual && nameEqual && detailEqual && clientEqual);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylist (stylist_name, detail, client_name) VALUES (@inputName, @inputDetail, @inputClient);";
      MySqlParameter newName = new MySqlParameter();
      newName.ParameterName = "@inputName";
      newName.Value = this.Name;
      cmd.Parameters.Add(newName);
      MySqlParameter newDetail = new MySqlParameter();
      newDetail.ParameterName = "@inputDetail";
      newDetail.Value = this.Detail;
      cmd.Parameters.Add(newDetail);
      MySqlParameter newClient = new MySqlParameter();
      newClient.ParameterName = "@inputClient";
      newClient.Value = this.Client;
      cmd.Parameters.Add(newClient);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
    }

    public static List<SalonStylist> GetAll()
    {
      List<SalonStylist> allSalonStylist = new List<SalonStylist> {};
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
        string client = rdr.GetString(3);
        SalonStylist newSalonStylist = new SalonStylist(name, detail,client, id);
        allSalonStylist.Add(newSalonStylist);
       }
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
       return allSalonStylist;
    }

    public static SalonStylist FindBySalonStylistId(int byId)
    {
      int id = 0;
      string name = "";
      string detail = "";
      string client = "";
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylist WHERE stylist_id = @idPara;";
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
        client = rdr.GetString(3);
      }
      SalonStylist newSalonStylist = new SalonStylist(name, detail, client, id);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newSalonStylist;
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
