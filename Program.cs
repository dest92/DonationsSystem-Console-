using DonacionesBackend.Controladores;
using DonacionesBackend;

namespace Parcial{

    class Program{

        static void Main(){
           Database.Init();
            ControladorDonante.ListarDonantes();
        }

        public static void Menu(){
            
        }

    }

}