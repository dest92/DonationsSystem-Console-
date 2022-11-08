using LiteDB;
using System;
using System.Linq;
using System.Collections.Generic;
using DonacionesBackend.Modelos;

namespace DonacionesBackend.Controladores
{

    public static class ControladorDonante
    {

        public static void AgregarDonante()
        {
            Console.WriteLine("Ingrese el nombre del donante");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del donante");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el monto donado");
            double montoDonado = Convert.ToDouble(Console.ReadLine()); 


            var donante = new Donantes
            {
                Id = ObjectId.NewObjectId(),
                Nombre = nombre,
                Apellido = apellido,
                MontoDonado = montoDonado
            };
            Database.Donantes.Insert(donante);
        }


        public static void EliminarDonante()
        {

            Console.WriteLine("Ingrese el id del donante");
            Console.ForegroundColor = ConsoleColor.Red;
            ListarDonantes();
            Console.ForegroundColor = ConsoleColor.White;
            string idcliente = Console.ReadLine();

            
            
            var donante = Database.Donantes.FindOne(x => x.Id == new ObjectId(idcliente));
            if (donante == null)
                throw new Exception("No se encontro el donante");

            Database.Donantes.Delete(donante.Id);
        }


        public static void AgregarDonacion()
        {

            Console.WriteLine("Ingrese el id del donante");
            Console.ForegroundColor = ConsoleColor.Red;
            ListarDonantes();
            Console.ForegroundColor = ConsoleColor.White;
            string idcliente = Console.ReadLine();
            
            var donante = Database.Donantes.FindOne(x => x.Id == new ObjectId(idcliente));
            if (donante == null)
                throw new Exception("No se encontro el donante");

        
            Console.WriteLine("Ingrese el monto donado");
            double montoDonado = Convert.ToDouble(Console.ReadLine());

            if (montoDonado <= 0)
                throw new Exception("El monto donado debe ser mayor a 0");

            donante.MontoDonado += montoDonado;
            Database.Donantes.Update(donante);
        }

        public static void ListarDonantes()
        {
            var donantes = Database.Donantes.FindAll().ToList();
                     
            foreach (var donante in donantes)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Id: {donante.Id}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Nombre: {donante.Nombre}");
                Console.WriteLine($"Apellido: {donante.Apellido}");
                Console.WriteLine($"Monto Donado: {donante.MontoDonado}");
                Console.WriteLine();
            }
        }

    }



}