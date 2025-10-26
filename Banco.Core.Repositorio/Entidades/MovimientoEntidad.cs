namespace Banco.Core.Repositorio.Entidades
{
    public class MovimientoEntidad
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string _id { get; set; } = ObjectId.GenerateNewId().ToString();

        public decimal Monto { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public string Concepto { get; set; }

        public string Referencia { get; set; }

        public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

        public decimal SaldoInicial { get; set; }

        public decimal SaldoFinal { get; set; }

        public int Id { get; set; }

        public string Canal { get; set; }

        //public Dictionary<string, string> Otros { get; set; }

        public int AhorroId { get; set; }

        public string AhorroEncodedkey { get; set; }

        public string Tipo { get; set; }
    }
}
