using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Xml.Linq;

namespace MVCminiproject.Models
{
    public class BALregister
    {
        SqlConnection con = new SqlConnection("Data Source=INBOOK_X1_NEO;Initial Catalog=MVCminiproject;Integrated Security=True");
        public void register(string name,string address,string gender,string email,string phoneno,int countryid,int stateid,int cityid,string passward)
        {       
            con.Open();
            SqlCommand cmb = new SqlCommand("SpMVCminiproject", con); 
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "Register");
            cmb.Parameters.AddWithValue("@Name", name);
            cmb.Parameters.AddWithValue("@Useraddress", address);
            cmb.Parameters.AddWithValue("@gender", gender);
            cmb.Parameters.AddWithValue("@email", email);
            cmb.Parameters.AddWithValue("@phoneno", phoneno);
            cmb.Parameters.AddWithValue("@countryid", countryid);
            cmb.Parameters.AddWithValue("@stateid", stateid);
            cmb.Parameters.AddWithValue("@cityid", cityid);
            cmb.Parameters.AddWithValue("@Passward", passward);  
            cmb.ExecuteNonQuery();
                con.Close();
        }
        public DataSet getcountry()
        {       
            SqlCommand cmb = new SqlCommand("SpMVCminiproject", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "getcountry");
            SqlDataAdapter adpt=new SqlDataAdapter();
            adpt.SelectCommand= cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;          
        }

        public DataSet getstate(int Countsryid)
        {
            SqlCommand cmb = new SqlCommand("SpMVCminiproject", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "getstate");
            cmb.Parameters.AddWithValue("@countryid", Countsryid);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        public DataSet getcity(int state)
        {
            SqlCommand cmb = new SqlCommand("SpMVCminiproject", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "getcity");
            cmb.Parameters.AddWithValue("@stateid", state);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }

        public DataSet gridview()
        {
            con.Open();
            SqlCommand cmb = new SqlCommand("SpMVCminiproject", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "getregisterdata");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
           // con.Close();
        }

        public void Delete(int id)
        {
            con.Open();
            SqlCommand cmb = new SqlCommand("SpMVCminiproject", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "deletegridview");
            cmb.Parameters.AddWithValue("@registerid", id);
            cmb.ExecuteNonQuery();
            con.Close();
        }

        public void Update(int registerid, string name, string address, string gender, string phoneno, string email, int countryid, int stateid, int cityid, string passward)
        {
            con.Open();
            SqlCommand cmb = new SqlCommand("SpMVCminiproject", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "updatedate");
            cmb.Parameters.AddWithValue("@registerid", registerid);
            cmb.Parameters.AddWithValue("@name", name);
            cmb.Parameters.AddWithValue("@Useraddress", address);
            cmb.Parameters.AddWithValue("@gender", gender);
            cmb.Parameters.AddWithValue("@email", email);
            cmb.Parameters.AddWithValue("@phoneno", phoneno);
            cmb.Parameters.AddWithValue("@countryid", countryid);
            cmb.Parameters.AddWithValue("@stateid", stateid);
            cmb.Parameters.AddWithValue("@cityid", cityid);
            cmb.Parameters.AddWithValue("@Passward", passward);
            cmb.ExecuteNonQuery();
            con.Close();
        }

        public SqlDataReader getregisterid(int id)
        {
            con.Open();
            SqlCommand cmb = new SqlCommand("SpMVCminiproject", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "getgridvew");
            cmb.Parameters.AddWithValue("@registerid", id);
            SqlDataReader dr = cmb.ExecuteReader();
            return dr;
            con.Close();
        }

        public DataSet getcitydropdown()
        {
            SqlCommand cmb = new SqlCommand("SpMVCminiproject", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@Flag", "getcitydropdown");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
    }
}