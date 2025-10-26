using Banco.Core.Dtos;
using Banco.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Banco.ReglasDeNegocio.Reglas
{
    internal class EstadoReglasDeNegocio : IEstadoReglasDeNegocio
    {
        public List<EstadoDto> Obtener()
        {
            return new List<EstadoDto>()
            {
                new EstadoDto { Id = 1, Nombre = "Aguascalientes" },
                new EstadoDto { Id = 2, Nombre = "Baja California" },
                new EstadoDto { Id = 3, Nombre = "Baja California Sur" },
                new EstadoDto { Id = 4, Nombre = "Campeche" },
                new EstadoDto { Id = 5, Nombre = "Coahuila de Zaragoza" },
                new EstadoDto { Id = 6, Nombre = "Colima" },
                new EstadoDto { Id = 7, Nombre = "Chiapas" },
                new EstadoDto { Id = 8, Nombre = "Chihuahua" },
                new EstadoDto { Id = 9, Nombre = "Ciudad de México" },
                new EstadoDto { Id = 10, Nombre = "Durango" },
                new EstadoDto { Id = 11, Nombre = "Guanajuato" },
                new EstadoDto { Id = 12, Nombre = "Guerrero" },
                new EstadoDto { Id = 13, Nombre = "Hidalgo" },
                new EstadoDto { Id = 14, Nombre = "Jalisco" },
                new EstadoDto { Id = 15, Nombre = "México" },
                new EstadoDto { Id = 16, Nombre = "Michoacán de Ocampo" },
                new EstadoDto { Id = 17, Nombre = "Morelos" },
                new EstadoDto { Id = 18, Nombre = "Nayarit" },
                new EstadoDto { Id = 19, Nombre = "Nuevo León" },
                new EstadoDto { Id = 20, Nombre = "Oaxaca" },
                new EstadoDto { Id = 21, Nombre = "Puebla" },
                new EstadoDto { Id = 22, Nombre = "Querétaro" },
                new EstadoDto { Id = 23, Nombre = "Quintana Roo" },
                new EstadoDto { Id = 24, Nombre = "San Luis Potosí" },
                new EstadoDto { Id = 25, Nombre = "Sinaloa" },
                new EstadoDto { Id = 26, Nombre = "Sonora" },
                new EstadoDto { Id = 27, Nombre = "Tabasco" },
                new EstadoDto { Id = 28, Nombre = "Tamaulipas" },
                new EstadoDto { Id = 29, Nombre = "Tlaxcala" },
                new EstadoDto { Id = 30, Nombre = "Veracruz de Ignacio de la Llave" },
                new EstadoDto { Id = 31, Nombre = "Yucatán" },
                new EstadoDto { Id = 32, Nombre = "Zacatecas" }
            };
        }

        public string ObtenerPorId(int id)
        {
            string estado;
            switch (id)
            {
                case 1:
                    estado = "Aguascalientes"; break;
                case 2: estado = "Baja_California"; break;
                case 3: estado = "Baja_California_Sur"; break;
                case 4: estado = "Campeche"; break;
                case 5: estado = "Coahuila"; break;
                case 6: estado = "Colima"; break;
                case 7: estado = "Chiapas"; break;
                case 8: estado = "Chihuahua"; break;
                case 9: estado = "Distrito_Federal"; break;
                case 10: estado = "Durango"; break;
                case 11: estado = "Guanajuato"; break;
                case 12: estado = "Guerrero"; break;
                case 13: estado = "Hidalgo"; break;
                case 14: estado = "Jalisco"; break;
                case 15: estado = "Mexico"; break;
                case 16: estado = "Michoacan"; break;
                case 17: estado = "Morelos"; break;
                case 18: estado = "Nayarit"; break;
                case 19: estado = "Nuevo_Leon"; break;
                case 20: estado = "Oaxaca"; break;
                case 21: estado = "Puebla"; break;
                case 22: estado = "Queretaro"; break;
                case 23: estado = "Quintana_Roo"; break;
                case 24: estado = "San_Luis_Potosi"; break;
                case 25: estado = "Sinaloa"; break;
                case 26: estado = "Sonora"; break;
                case 27: estado = "Tabasco"; break;
                case 28: estado = "Tamaulipas"; break;
                case 29: estado = "Tlaxcala"; break;
                case 30: estado = "Veracruz"; break;
                case 31: estado = "Yucatan"; break;
                case 32: estado = "Zacatecas"; break;
                case 33: estado = "Extranjero"; break;
                default:
                    estado = string.Empty;
                    break;

            }
            return estado;
        }
    }
}
