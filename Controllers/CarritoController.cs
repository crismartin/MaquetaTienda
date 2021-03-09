using MaquetaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MaquetaTienda.Controllers
{
    [Authorize]
    public class CarritoController : Controller
    {
        private ModeloTiendaContainer db = new ModeloTiendaContainer();

        // GET: Carrito
        public ActionResult Index(CarritoCompra cc)
        {
            return View(cc);
        }

        public ActionResult Save(CarritoCompra cc)
        {
            List<Producto> productos = cc.ToList();
            string nameUser = HttpContext.User.Identity.Name;
            string referencePedido = RandomGenerator.RandomReferenceId();

            // crear pedido
            var pedido = new Pedido();
            pedido.Pagado = false;
            pedido.Fecha = TimeSpan.Zero;
            pedido.NombreUsuario = nameUser;
            pedido.Referencia = referencePedido;


            // guardar los productos asociados al pedido


            /*
            foreach (Producto p in productos)
            {
                var pedido = new Pedido();
                pedido.IdProducto = p.Id;
                pedido.Cantidad = 1;
                pedido.Pagado = false;
                pedido.Fecha = TimeSpan.Zero;
                pedido.NombreUsuario = nameUser;
                pedido.Referencia = referencePedido;
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                cc.Clear(); //vacio el carrito del modelo
            }
            */
            return RedirectToAction("Index", "Pedidos");
        }
    }
}

