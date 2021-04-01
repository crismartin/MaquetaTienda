using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaquetaTienda.Models
{
    public class CarritoCompra : List<ProductoCarrito>
    {

        public void AddProducto(Producto producto)
        {
            ProductoCarrito prodCart = new ProductoCarrito();
            prodCart.Id = producto.Id;
            prodCart.Nombre = producto.Nombre;
            prodCart.Descripcion = producto.Descripcion;
            prodCart.Precio = producto.Precio;
            List<ProductoCarrito> listaProds = this.ToList();

            if (listaProds.Count > 0)
            {
                //  tengo que buscar el producto y aumentar 1 a la Cantidad
                var prodFounded = listaProds.FirstOrDefault(x => x.Id == producto.Id);
                if (prodFounded != null)
                {
                    if(prodFounded.Cantidad < producto.Stock)
                    {
                        prodFounded.Cantidad = (short)((short)prodFounded.Cantidad + 1);
                    }                    
                }
                else
                {
                    prodCart.Cantidad = 1;
                    this.Add(prodCart);
                }
            }
            else
            {
                prodCart.Cantidad = 1;
                this.Add(prodCart);
            }

        }

        public void RemoveProducto(Producto producto)
        {
            if (producto != null)
            {
                List<ProductoCarrito> listaProds = this.ToList();
                // comprobar que el producto existe en el carrito
                var prodFounded = listaProds.FirstOrDefault(x => x.Id == producto.Id);
                if (prodFounded.Cantidad > 1)
                {
                    prodFounded.Cantidad = (short)((short)prodFounded.Cantidad - 1);
                }
                else
                {
                    this.Remove(prodFounded);
                }
            }
        }
    }
}