using LiteDB;
using System.Linq;
using System.Collections.Generic;
using DonacionesBackend.Modelos;

namespace DonacionesBackend.Controladores
{

    public static class ControladorDonaciones
    {

        public static void AgregarDonacion()
        {
            
            Console.WriteLine("Ingrese el id del donante");
            Console.ForegroundColor = ConsoleColor.Red;
            ControladorDonante.ListarDonantes();
            Console.ForegroundColor = ConsoleColor.White;
            string iddonante = Console.ReadLine();

            var donante = Database.Donantes.FindOne(x => x.Id == new ObjectId(iddonante));
            if (donante == null)
                throw new Exception("No se encontro el donante");

            Console.WriteLine("Ingrese el id del proyecto");
            Console.ForegroundColor = ConsoleColor.Red;
            ControladorProyectos.ListarProyectos();
            Console.ForegroundColor = ConsoleColor.White;
            string idproyecto = Console.ReadLine();

            var proyecto = Database.Proyectos.FindOne(x => x.Id == new ObjectId(idproyecto));
            if (proyecto == null)
                throw new Exception("No se encontro el proyecto");

            Console.WriteLine("Ingrese el monto de la donacion");
            double monto = double.Parse(Console.ReadLine());

            var donacion = new Donaciones
            {
                Id = ObjectId.NewObjectId(),
                idDonante = donante.Id,
                idProyecto = proyecto.Id,
                MontoDonado = monto

            };

            Database.Donaciones.Insert(donacion);

            //Add donacion to donante

            donante.Donaciones.Add(donacion);

            Database.Donantes.Update(donante);

            proyecto.MontoDonado += monto;

            Database.Proyectos.Update(proyecto);


        }

    }



}