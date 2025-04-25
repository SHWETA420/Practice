using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common
{
    public class JWTAuthentication
    {
        /// <summary>
        /// get data from backend apsetting.json
        /// </summary>
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiryYear;

        public JWTAuthentication(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
            _expiryYear = 1;

        }
        /// <summary>
        ///  Taking Static admin or user for authentication, 
        ///  Dependency added in Program.cs in web api for jwt 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<string> GenerateJWT(string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Iat,
                          ((int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()).ToString(),
                          ClaimValueTypes.Integer64)
            };

            if (role == "admin")
            {
                claims.Add(new Claim("IsAdmin", "true"));
            }

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddYears(_expiryYear),
                signingCredentials: credentials);

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
