using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutorizacionJwtServicio
{
    public class TokenServicio
    {
        private readonly string _llaveJwt;

        public TokenServicio(IConfiguration configuration)
        {

            _llaveJwt = configuration["LLaveJwt"];
        }

        public string ObtenerToken(string nombre, string role, string clienteId, string correo, DateTime fechaDeExpiracion)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_llaveJwt));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            //var expirationTimeStamp = DateTime.Now.AddMinutes(20);

            var claims = new List<Claim>
        {
            new Claim("Nombre", nombre),
            new Claim("Role", role),
            new Claim("ClienteId",clienteId),
            new Claim("email", correo)
            //new Claim("scope", string.Join(" ", user.Scopes))
        };

            var tokenOptions = new JwtSecurityToken(
                //issuer: "https://localhost:5002",            
                claims: claims,
                expires: fechaDeExpiracion,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
