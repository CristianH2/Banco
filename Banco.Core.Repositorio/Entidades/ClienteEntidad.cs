using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Banco.Core.Repositorio.Entidades
{
    public class ClienteEntidad
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int Id { get; set; }

        public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Correo { get; set; }

        public string Contrasenia { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public string EstadoDeNacimiento { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public bool EstaActivo { get; set; } = true;

        public virtual List<AhorroEntidad> Ahorros { get; set; } = new List<AhorroEntidad>();
        public object Curp { get; set; }
    }
}
