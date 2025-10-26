using System.ComponentModel.DataAnnotations;

namespace Banco.Core.Dtos
{
    public class AhorroDtoIn
    {
        public string Encodedkey { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string ClienteId { get; set; }
    }

    public class AhorroDto
    {
        public string Encodedkey { get; set; }

        public int ClienteId { get; set; }

        public decimal Total { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public int Id { get; set; }
    }
}
