using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sevenimport.Models
{
    public class ItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int IdImagen { get; set; }

        public byte[] Image { get; set; }

        public marca SelecMarca { get; set; }

        public List<marca> Marcas { get; set; }


    }
}