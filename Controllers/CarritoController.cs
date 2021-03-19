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
            List<ProductoCarrito> productos = cc.ToList();
            string nameUser = HttpContext.User.Identity.Name;
            string referencePedido = RandomGenerator.RandomReferenceId();

            // crear pedido
            var pedido = new Pedido();
            pedido.Pagado = false;
            pedido.Fecha = TimeSpan.Zero;
            pedido.NombreUsuario = nameUser;
            pedido.Referencia = referencePedido;
            
            db.Pedidos.Add(pedido);
            db.SaveChanges();

            // guardar los productos asociados al pedido
            foreach (ProductoCarrito p in productos)
            {
                var productosPedido = new ProductosPedido();
                productosPedido.IdPedido = pedido.Id;
                productosPedido.IdProducto = p.Id;
                productosPedido.Cantidad = p.CantidadCarrito;
                db.ProductoPedido.Add(productosPedido);
                db.SaveChanges();
                cc.Clear(); //vacio el carrito del modelo
            }
            
            return RedirectToAction("Index", "Pedidos");
        }

        public ActionResult Delete(int id, CarritoCompra cc)
        {
            // buscar el producto con el id
            Producto producto = db.Productos.Find(id);
            cc.RemoveProducto(producto);

            return RedirectToAction("Index");
        }
    }
}

