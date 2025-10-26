using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Banco.Core.Repositorio.Entidades
{
    public class AhorroEntidad
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int Id { get; set; }

        public string Encodedkey { get; set; } = Guid.NewGuid().ToString();

        public string Nombre { get; set; }

        public decimal Total { get; set; } = 0m;

        public string ClienteEncodedkey { get; set; }

        public int ClienteId { get; set; }

        public bool EstaActivo { get; set; } = true;

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public virtual List<MovimientoEntidad> Movimientos { get; set; } = new List<MovimientoEntidad>();
    }
}
