using LiteDB;

namespace DonacionesBackend.Modelos
{

    public class Proyectos
    {

        public ObjectId Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public double MontoRequerido { get; set; }

        //Guardar foto del proyecto
        public byte[] Foto { get; set; }

    }


}