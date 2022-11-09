using DonacionesBackend.Controladores;
using DonacionesBackend;

namespace Parcial
{

    class Program
    {

        static void Main()
        {

            Menu();
        }

        public static void Menu()
        {
            Database.Init();
            Console.Clear();
            int options = 1;

            while (options != 0)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Cargar Donante");
                Console.WriteLine("2. Crear proyecto");
                Console.WriteLine("3. Donar");
                Console.WriteLine("4. Listar Proyectos");
                Console.WriteLine("5. Listar Donantes por cantidad de donaciones");
                Console.WriteLine("6. Proyecto a txt");

                //Seleccionar opcion con las flechas
                int index = 0;
                int selected = 0;
                int salir = 0;
                string[] opciones = { "0. Exit", "1. Cargar Donante", "2. Crear proyecto", "3. Donar", "4. Listar Proyectos", "5. Listar Donantes por cantidad de donaciones", "6. Proyecto a txt" };
                do
                {
                    index = selected;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Cargar Donante");
                    Console.WriteLine("2. Crear proyecto");
                    Console.WriteLine("3. Donar");
                    Console.WriteLine("4. Listar Proyectos");
                    Console.WriteLine("5. Listar Donantes por cantidad de donaciones");
                    Console.WriteLine("6. Proyecto a txt");


                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(0, index);
                    Console.CursorVisible = false;
                    Console.WriteLine(opciones[index]);
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        selected++;
                        if (selected == opciones.Length)
                        {
                            selected = 0;
                        }
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        selected--;
                        if (selected == -1)
                        {
                            selected = opciones.Length - 1;
                        }
                    }

                    //seleccionar con enter

                    if (key.Key == ConsoleKey.Enter)
                    {
                        options = selected;
                        salir = 1;

                    }
                } while (salir != 1);


                switch (options)
                {
                    case 0:
                        Console.Clear();
                        Database.Close();
                        Console.WriteLine(@"
                     ██████╗  ██████╗  ██████╗ ██████╗ ██████╗ ██╗   ██╗███████╗██╗
                    ██╔════╝ ██╔═══██╗██╔═══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝██╔════╝██║
                    ██║  ███╗██║   ██║██║   ██║██║  ██║██████╔╝ ╚████╔╝ █████╗  ██║
                    ██║   ██║██║   ██║██║   ██║██║  ██║██╔══██╗  ╚██╔╝  ██╔══╝  ╚═╝
                    ╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝██████╔╝   ██║   ███████╗██╗
                     ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝ ╚═════╝    ╚═╝   ╚══════╝╚═╝                                         
");
                        break;

                    case 1:
                        Console.Clear();
                        ControladorDonante.AgregarDonante();
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        ControladorProyectos.AgregarProyecto();
                        break;

                    case 3:
                        Console.Clear();
                        ControladorDonaciones.AgregarDonacion();
                        break;

                    case 4:
                        Console.Clear();
                        ControladorProyectos.ListarProyectosEnUnaTabla();
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        ControladorDonante.ListarDonantesPorDonaciones();
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.Clear();
                        ControladorProyectos.ProyectToFile();
                        break;


                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}

