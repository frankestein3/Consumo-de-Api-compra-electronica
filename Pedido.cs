using System;
using System.Collections.Generic;
using System.Text;

namespace Compra
{
    class Pedido
    {
        public int id_pedido { get; set; }
        public int id_cliente { get; set; }
        public string fecha { get; set; }

        public class PedidoList
        {
            public Pedido record;
        }
    }
}
