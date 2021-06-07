using System;
using System.Collections.Generic;
using System.Text;

namespace Compra
{
    class Factura
    {
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public int id_factura { get; set; }

        public class FacturaList
        {
            public Factura record;
        }
    }
   
}
