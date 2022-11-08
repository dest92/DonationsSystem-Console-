using LiteDB;

namespace DonacionesBackend.Modelos
{

    public class Donaciones
    {

        public ObjectId Id { get; set; }
        public ObjectId idDonante { get; set; }
        public ObjectId idProyecto { get; set; }
        public double MontoDonado { get; set; }

    }
}