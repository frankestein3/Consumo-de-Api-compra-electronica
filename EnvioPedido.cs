using System;
using System.Collections.Generic;
using System.Text;

namespace Compra
{
    class EnvioPedido
    {
        public EnvioPedido() { }

        public List<int> productos = new List<int>();

        public void SetProductoId(int id)
        {
            productos.Add(id);
        }
        public void MostrarLista()
        {
            foreach (int i in productos)
            {
                Console.WriteLine("Id del producto: " + i + "\n");
            }
        }
        public int idCliente {get; set;}
        public int totalCompra { get; set;}
    }
}
