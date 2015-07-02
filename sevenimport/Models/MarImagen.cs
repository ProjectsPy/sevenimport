using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sevenimport.Models
{
    public class MarImagen : marca
    {
        public virtual ICollection<imageMarca> Images { get; set; }
    }
}