using MVCminiproject.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCminiproject.Models
{
    public class Register
    {
        public int Registerid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }      
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public int Countryid { get; set; }
        public string countryName { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }
        public int City { get; set; }
        public string CityName { get; set; }
        public string Passward { get; set; }
       // public List<Register> listregister { get; set; }
        public List<Register> registers { get; set; }

        [DefaultValue(null)]
        public ASPxSummaryItemCollection GroupSummary { get; }



    }
}