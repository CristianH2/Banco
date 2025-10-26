using System.ComponentModel.DataAnnotations;

namespace Banco.Core.Dtos
{
    public class ClienteDtoIn
    {
        public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(255)]
        public string PrimerApellido { get; set; }

        [MaxLength(255)]
        public string SegundoApellido { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Required]
        [MaxLength(20)]
        public string Contrasenia { get; set; } 

        [Required]
        [MaxLength(64)]
        public string Nombre { get; set; }

        /// <summary>
        /// Telefono a 10 digitos, sin espacios o guiones
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        /// <summary>
        /// EstadoId de nacimiento, ver catalogo de estados
        /// </summary>
        [Required]
        [Range(1,32)]
        public int EstadoDeNacimiento { get; set; }

        /// <summary>
        /// H para hombre, M mujer
        /// </summary>
        [Required]
        public string Sexo { get; set; }
    }

    public class ClienteDto
    {
        public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Correo { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public string EstadoDeNacimiento { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public int Id { get; set; }
    }
}
