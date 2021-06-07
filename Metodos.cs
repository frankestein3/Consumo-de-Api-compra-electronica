using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Compra
{
    class Metodos
    {
        private EnvioPedido envio = new EnvioPedido();
        public Metodos(){}
        
        public void Facturar(int id)
        {
            envio.idCliente = id;
            var url = $"http://localhost:9095/api/pedido/GetPedidoCliente/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            int suma = 0;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {

                            string json = objReader.ReadToEnd();
                            var result = JsonConvert.DeserializeObject<List<Pedido>>(json);
                            foreach (Pedido p in result)
                            {
                                Console.WriteLine("Numero de pedido del cliente: " + p.id_pedido + "\n");
                                suma = suma + ObtenerPedidoProducto(p.id_pedido);


                            }
                            envio.totalCompra = suma;
                            Console.WriteLine("Total de la compra: " + suma);
                        }
                    }
                }
            }
            catch (WebException ex)
            {

            }
        }

        public int ObtenerPedidoProducto(int id)
        {
            int suma = 0;
            var url = $"http://localhost:9095/api/factura/buscarPedido/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return 0;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string json = objReader.ReadToEnd();
                            var result = JsonConvert.DeserializeObject<List<Factura>>(json);
                            foreach (Factura f in result)
                            {
                                Console.WriteLine("Identificador del producto: " + f.id_producto + "\n");
                                int valor = ObtenerPrecioProducto(f.id_producto);
                                suma += valor;
                                envio.SetProductoId(f.id_producto);

                            }
                            Console.WriteLine("Suma del  pedido: " + suma + "\n");
                            Console.WriteLine("--------------------------------------------------------------------" + "\n");
                            return suma;

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return 0;
            }
        }

        private static int ObtenerPrecioProducto(int id)
        {
            var url = $"http://localhost:9095/api/producto/GetPrecio/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return 0;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            dynamic jsonObj = JsonConvert.DeserializeObject(responseBody);
                            int result = Int32.Parse(jsonObj);
                            Console.WriteLine("Precio del producto: " + result + "\n");
                            return result;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return 0;
            }
        }

        public void Logistica()
        {
            envio.MostrarLista();
            Console.WriteLine("Id del cliente: " + envio.idCliente + "\n");
            Console.WriteLine("--------------------------------------------------------------------" + "\n");
            Console.WriteLine("Total de la compra : " + envio.totalCompra);

        }
    }
}

