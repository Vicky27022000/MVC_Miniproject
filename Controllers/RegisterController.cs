using Microsoft.Win32;
using MVCminiproject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MVCminiproject.Controllers
{
    public class RegisterController : Controller
    {
        private Register db = new Register();

        public object Context { get; private set; }

        // GET: Register
        public ActionResult Index()
        {
          //  Country_bind();
            return View();
        }
        [HttpGet]
        public ActionResult create()
        {
           
            Country_bind();
            show();
            City();
            show();
            return View();
        }

        [HttpPost]
        public ActionResult create(Register obj)
        {
            BALregister obj1 = new BALregister();
            obj1.register(obj.Name, obj.Address, obj.Gender, obj.Email, obj.Phoneno, obj.Countryid, obj.State, obj.City,obj.Passward);
            Response.Write("script>alert(save Successfully );</script>");
            return RedirectToAction("Create");
        }

        public void Country_bind()
        {
            BALregister obj = new BALregister();
            DataSet ds = obj.getcountry();
            List<SelectListItem>
                Countrylist = new List<SelectListItem>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Countrylist.Add(new SelectListItem
                {
                    Text =dr["Countryname"].ToString(),
                    Value = dr["Countryid"].ToString()
                }) ;        
            }
            ViewBag.Country = Countrylist;                   
        }

        public JsonResult state_bind(int Countryid)
        {
            BALregister obj = new BALregister();
            DataSet ds = obj.getstate(Countryid);
            List<SelectListItem>
                statelist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                statelist.Add(new SelectListItem
                {
                    Text = dr["statename"].ToString(),
                    Value = dr["stateid"].ToString()
                  
                }) ;
            }
          return Json(statelist,JsonRequestBehavior.AllowGet);
        }

        public JsonResult city_bind(int state)
        {
            BALregister obj = new BALregister();

            DataSet da = obj.getcity(state);
            List<SelectListItem>
                citylist = new List<SelectListItem>();
            foreach (DataRow dr in da.Tables[0].Rows)
            {
                citylist.Add(new SelectListItem
                {
                    Text = dr["Cityname"].ToString(),
                    Value = dr["Cityid"].ToString()

                });
            }
            return Json(citylist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult show()
        {
            BALregister obj2 = new BALregister();
            DataSet de = obj2.gridview();
            Register objdetails = new Register();
            List<Register> lstuserdt1 = new List<Register>();
            for (int i = 0; i < de.Tables[0].Rows.Count; i++)
            {
                Register obj =new Register();
                obj.Registerid = Convert.ToInt32(de.Tables[0].Rows[i]["Registerid"].ToString());
                obj.Name = de.Tables[0].Rows[i]["Name"].ToString();
                obj.Address = de.Tables[0].Rows[i]["UserAddress"].ToString();
                obj.Gender = de.Tables[0].Rows[i]["Gender"].ToString();
                obj.Email = de.Tables[0].Rows[i]["Email.com"].ToString();
                obj.Phoneno = de.Tables[0].Rows[i]["Phoneno"].ToString();
                // obj.Country = Convert.ToInt32(de.Tables[0].Rows[i]["Countryid"].ToString());
                obj.StateName = de.Tables[0].Rows[i]["statename"].ToString();
                obj.CityName = de.Tables[0].Rows[i]["Cityname"].ToString();
             
                obj.Passward = de.Tables[0].Rows[i]["Passward"].ToString();
                lstuserdt1.Add(obj);
            }
            objdetails.registers = lstuserdt1;
            return View(objdetails);
        }
        
        public ActionResult DeleteRow(int id)
        {
            BALregister objb = new BALregister ();
            objb.Delete(id);
            Response.Write("script>alert(save Successfully );</script>");
            return RedirectToAction("create");       
        }

        [HttpGet]
        public ActionResult Update(int ID)
        {
            Country_bind();
            Register obja = new Register();
            obja.Registerid = ID;
            BALregister objb = new BALregister();
            SqlDataReader dr;
            dr = objb.getregisterid(obja.Registerid);
            while (dr.Read())
            {
                obja.Registerid = Convert.ToInt32(dr["Registerid"].ToString());
                obja.Name = dr["Name"].ToString();
                obja.Address = dr["UserAddress"].ToString();
                obja.Gender = dr["Gender"].ToString();
                obja.Email = dr["Email.com"].ToString();
                obja.Phoneno =dr["Phoneno"].ToString();               
                obja.Country =Convert.ToInt32( dr["Countryid"].ToString());
                obja.countryName = dr["Countryname"].ToString();
                obja.State = Convert.ToInt32(dr["Stateid"].ToString());
                obja.StateName =dr["statename"].ToString();
                obja.City =Convert.ToInt32(dr["Cityid"].ToString());
                obja.CityName = dr["Cityname"].ToString();
                obja.Passward = dr["Passward"].ToString();
            }
             dr.Close();    
            ViewBag.State = obja.State;
            ViewBag.StateName = obja.StateName;
            ViewBag.City = obja.City;
            ViewBag.CityName = obja.CityName;
            return View(obja);
        }
        [HttpPost]
        public ActionResult Update(Register obj)
        {
            BALregister obj1 = new BALregister();
            obj1.Update(obj.Registerid, obj.Name, obj.Address, obj.Gender, obj.Email, obj.Phoneno, obj.Countryid, obj.State, obj.City, obj.Passward);
            Response.Write("script>alert(Update Successfully );</script>");
            return RedirectToAction("create");
        }

        public ActionResult details(int ID)
        {
            Country_bind();
            Register obja =new Register();
            obja.Registerid = ID;
            BALregister objb = new BALregister();
            SqlDataReader dr;
            dr = objb.getregisterid(obja.Registerid);
            while (dr.Read())
            {
                obja.Registerid = Convert.ToInt32(dr["Registerid"].ToString());
                obja.Name = dr["Name"].ToString();
                obja.Address = dr["UserAddress"].ToString();
                obja.Gender = dr["Gender"].ToString();
                obja.Email = dr["Email.com"].ToString();
                obja.Phoneno = dr["Phoneno"].ToString();
                obja.Country = Convert.ToInt32(dr["Countryid"].ToString());
                obja.countryName = dr["Countryname"].ToString();
                obja.State = Convert.ToInt32(dr["Stateid"].ToString());
                obja.StateName = dr["statename"].ToString();
                obja.City = Convert.ToInt32(dr["Cityid"].ToString());
                obja.CityName = dr["Cityname"].ToString();
               
            }
            dr.Close();
            return PartialView(obja);
        }
        public ActionResult Filter(int registerid)
        {
            int? emp_ID = Convert.ToInt32(registerid);
            List<Register> y = null;
            var qq = y;
            if (emp_ID == 0)
            {
                qq = (from e in db.registers
                      select new Register
                      {
                          Registerid = e.Registerid,
                          Name = e.Name,
                          Email = e.Email,
                          Country = e.Country,
                         
                      }).ToList();
            }
            else
            {
            //    qq = (from e in db.registers
            //          where e.Registerid == emp_ID
            //          select new Register
            //          {
            //              Registerid = e.Registerid,
            //              Name = e.Name,
            //              Email = e.Email,
            //              Country = e.Country,
                         
            //          }).ToList();
            }
            return ViewBag("Filter", qq);
        }


        public void City()
        {
            BALregister obj = new BALregister();
            DataSet ds = obj.getcitydropdown();
            List<SelectListItem>
                City = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                City.Add(new SelectListItem
                {
                    Text = dr["Name"].ToString(),
                    Value = dr["Registerid"].ToString()
                });
            }
            ViewBag.City = City;
        }
    }
}