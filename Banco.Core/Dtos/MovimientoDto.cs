using System.ComponentModel.DataAnnotations;

namespace Banco.Core.Dtos
{
    public class MovimientoDtoIn
    {
        [Required]
        [Range(0, 10000000)]
        public decimal Monto{ get; set; }

        [MaxLength(48)]
        public string Referencia { get; set; }

        [Required]
        [MaxLength(48)]
        public string Concepto { get; set; }

        [Required]
        [MaxLength(100)]
        public string Encodedkey { get; set; } 
    }

    public class MovimientoDto
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public string Concepto { get; set; }
        public string Referencia { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoFinal { get; set; }
        public string Tipo { get; set; }
    }
}
