using System.ComponentModel.DataAnnotations;

namespace Banco.Core.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaDeExpiracion { get; set; }

        public int ExpiracionEnMinutos { get; set; }
    }

    public class InicioDeSesionDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        [MaxLength(50)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MaxLength(12)]
        public string Contraseña { get; set; }
    }
}
