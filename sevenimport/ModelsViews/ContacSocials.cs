using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sevenimport.Models;


namespace sevenimport.ModelsViews
{
    public class ContacSocials
    {
        public IEnumerable<contact> Contacts { get; set; }

        public IEnumerable<social> Socials { get; set; }


    }
}