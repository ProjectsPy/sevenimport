using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sevenimport.ModelsViews
{
    public class IndexPortada
    {
        public IEnumerable<service> Services { get; set; }
        public IEnumerable<quiene> Quienes { get; set; }
        public IEnumerable<partner> Partners { get; set; }

        public IEnumerable<contact> Contacts { get; set; }

        public IEnumerable<slider> Sliders { get; set; }
    }
}