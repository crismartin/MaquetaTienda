using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaquetaTienda.Models
{
    public class ProductoDTO: Producto
    {
        public short Cantidad { get; set; }
    }
}