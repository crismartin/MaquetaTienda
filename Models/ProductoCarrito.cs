using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaquetaTienda.Models
{
    public class ProductoCarrito: Producto
    {
        public short Cantidad { get; set; }        
    }
}