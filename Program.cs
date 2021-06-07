using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;

namespace Compra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba id del cliente: ");
            var dato = Console.ReadLine();
            int nuevoValor = Convert.ToInt32(dato);
            Metodos programa = new Metodos();
            programa.Facturar(nuevoValor);
            Console.WriteLine("--------------------------------------------------------------------" + "\n");
            Console.WriteLine("Datos para el envio de los productos: " + "\n");
            programa.Logistica();
        }
    }

}
