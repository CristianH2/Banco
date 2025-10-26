namespace Banco.Core.Dtos
{
    public class SolicitudDto
    {
        public string Nombres { get; set; }

        public string primerApellido { get; set; }

        public string segundoApellido { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public string Sexo { get; set; }

        public string Estado { get; set; }
    }
}
