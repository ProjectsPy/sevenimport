using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sevenimport.Models;

namespace sevenimport.Controllers
{
    public class marcasImgController : Controller
    {
        // GET: marcasImg
        importEntities entidad = new importEntities();
        public ActionResult Index()
        {
            var lismarcas = entidad.marcas;
            return View(lismarcas.ToList());
        }

        private MarImagen db = new MarImagen();


        public ActionResult ListarImagenxProducto(int IdProducto)
        {

            //var modelo = from p in db.ProductoImagen
            //             join c in db.Producto
            //                 ////on p.IdProducto equals c.IdProducto
            //              on p.IdProducto equals c.IdProducto
            //             where p.IdProducto == 


            //             select new ItemModel
            //             {
            //                 ////IdProducto = p.IdProducto,
            //                 Descripcion = c.Descripcion,
            //                 IdImagen = p.IdImagen,
            //                 Imagen = p.Imagen,
            //                 Nombre = p.Nombre,

            //             };

            //return View(modelo.ToList());


        }
 

    }
}