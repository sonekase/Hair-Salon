using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class SpecialtyStylist
  {
    private int Id;
    private int SpecialtyId;
    private int StylistId;

    public SpecialtyStylist(int newSpecialtyId, int newStylistId, int newId =0)
    {
      Id = newId;
      SpecialtyId = newSpecialtyId;
      StylistId = newStylistId;
    }
    public int GetId()
    {
      return Id;
    }
    public int GetSpecialtyId()
    {
      return SpecialtyId;
    }
    public int GetStylistId()
    {
      return StylistId;
    }
    public override bool Equals(System.Object otherSpecialtyStylist)
    {
      if (!(otherSpecialtyStylist is SpecialtyStylist))
      {
        return false;
      }
      else
      {
        SpecialtyStylist newSpecialtyStylist = (SpecialtyStylist) otherSpecialtyStylist;
        bool idEqual = (this.GetId() == newSpecialtyStylist.GetId());
        bool specialtyIdEqual = (this.GetSpecialtyId() == newSpecialtyStylist.GetSpecialtyId());
        bool stylistIdEqual = (this.GetStylistId() == newSpecialtyStylist.GetStylistId());
        return (idEqual && specialtyIdEqual && stylistIdEqual);
      }
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties_stylist (specialty_id, stylist_id) VALUES (@inputSpecialtyId, @inputStylistId);";
      MySqlParameter newSpecialtyId = new MySqlParameter();
      newSpecialtyId.ParameterName = "@inputSpecialtyId";
      newSpecialtyId.Value = this.SpecialtyId;
      cmd.Parameters.Add(newSpecialtyId);
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
    public static List<SpecialtyStylist> GetAll()
    {
      List<SpecialtyStylist> allSpecialties = new List<SpecialtyStylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties_stylist;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        int specialtyId = rdr.GetInt32(1);
        int stylistId = rdr.GetInt32(2);
        SpecialtyStylist newSpecialtyStylist = new SpecialtyStylist(specialtyId, stylistId);
        allSpecialties.Add(newSpecialtyStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties_stylist;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
