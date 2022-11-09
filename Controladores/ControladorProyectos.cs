using LiteDB;
using System.Linq;
using System.Collections.Generic;
using DonacionesBackend.Modelos;
using Drawers;

namespace DonacionesBackend.Controladores
{

    public static class ControladorProyectos
    {

        public static void AgregarProyecto()
        {
            Console.WriteLine("Ingrese el nombre del proyecto");
            string titulo = Console.ReadLine();
            Console.WriteLine("Ingrese el monto requerido del proyecto");
            double monto = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la descripcion del proyecto");
            string descripcion = Console.ReadLine();

            var proyecto = new Proyectos
            {
                Id = ObjectId.NewObjectId(),
                Titulo = titulo,
                MontoRequerido = monto,
                Descripcion = descripcion,

            };

            Database.Proyectos.Insert(proyecto);
        }

        public static void EliminarProyecto()
        {

            Console.WriteLine("Ingrese el id del proyecto");
            Console.ForegroundColor = ConsoleColor.Red;
            //ListarProyectos();
            Console.ForegroundColor = ConsoleColor.White;
            string idproyecto = Console.ReadLine();

            var proyecto = Database.Proyectos.FindOne(x => x.Id == new ObjectId(idproyecto));
            if (proyecto == null)
                throw new Exception("No se encontro el proyecto");
            if (proyecto.MontoDonado != 0)
                throw new Exception("No se puede eliminar un proyecto que ya tiene donaciones");

            Database.Proyectos.Delete(proyecto.Id);
        }

        public static void ListarProyectos()
        {
            var proyectos = Database.Proyectos.FindAll();
            foreach (var proyecto in proyectos)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Id: {proyecto.Id}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Titulo: {proyecto.Titulo}");
                Console.WriteLine($"Monto Requerido: {proyecto.MontoRequerido}");
                Console.WriteLine($"Monto Donado: {proyecto.MontoDonado}");
                Console.WriteLine($"Descripcion: {proyecto.Descripcion}");
                Console.WriteLine("====================================");
            }
        }

        public static void ListarProyectosEnUnaTabla()
        {
            string[,] tabla = new string[Database.Proyectos.Count() + 1, 5];

            //Set the headers
            //  tabla[0, 0] = "Id";
            tabla[0, 0] = "Titulo";
            tabla[0, 1] = "Monto Requerido";
            tabla[0, 2] = "Monto Donado";
            tabla[0, 3] = "Montos Restantes";
            tabla[0, 4] = "Monto excedido";

            double montoRestante = 0;
            double montoExcedido = 0;


            //Set the data
            var proyectos = Database.Proyectos.FindAll();




            int k = 1;
            foreach (var proyecto in proyectos)
            {
                if (proyecto.MontoDonado > proyecto.MontoRequerido)
                {
                    montoExcedido = proyecto.MontoDonado - proyecto.MontoRequerido;
                }
                if (proyecto.MontoDonado < proyecto.MontoRequerido)
                {
                    montoRestante = proyecto.MontoRequerido - proyecto.MontoDonado;
                }

                //id to string
                //string id = proyecto.Id.ToString();

                // tabla[k, 0] = id;
                tabla[k, 0] = proyecto.Titulo;
                tabla[k, 1] = proyecto.MontoRequerido.ToString();
                tabla[k, 2] = proyecto.MontoDonado.ToString();
                tabla[k, 3] = montoRestante.ToString();
                tabla[k, 4] = montoExcedido.ToString();
                k++;

                montoExcedido = 0;
            }

            //Draw the table

            Drawers.DibujarTablas.DibujaTabla(tabla);

        }

        public static void ProyectToFile()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Introduzca el ID del proyecto");
            Console.ForegroundColor = ConsoleColor.White;
            ListarProyectos();
            string idproyecto = Console.ReadLine();


            var proyectos = Database.Proyectos.Query().Where(x => x.Id == new ObjectId(idproyecto)).ToList();
            string path = @"C:\TXT\proyectos.txt";

            double montoRestante = 0;
            double montoExcedido = 0;

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var proyecto in proyectos)
                    {

                        if (proyecto.MontoDonado > proyecto.MontoRequerido)
                        {
                            montoExcedido = proyecto.MontoDonado - proyecto.MontoRequerido;
                        }
                        if (proyecto.MontoDonado < proyecto.MontoRequerido)
                        {
                            montoRestante = proyecto.MontoRequerido - proyecto.MontoDonado;
                        }

                        sw.WriteLine($"Id: {proyecto.Id}");
                        sw.WriteLine($"Titulo: {proyecto.Titulo}");
                        sw.WriteLine($"Descripcion: {proyecto.Descripcion}");
                        sw.WriteLine($"Monto Requerido: {proyecto.MontoRequerido}");
                        sw.WriteLine($"Monto Donado: {proyecto.MontoDonado}");
                        sw.WriteLine($"Monto Restante: {montoRestante}");
                        sw.WriteLine($"Monto Excedido: {montoExcedido}");
                        sw.WriteLine("====================================");
                    }
                }
            }

        }
    }
}
