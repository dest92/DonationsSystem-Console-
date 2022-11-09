using LiteDB;

namespace DonacionesBackend.Modelos
{

    public class Donantes
    {
        public ObjectId Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Donaciones> Donaciones { get; set; }
    }

}