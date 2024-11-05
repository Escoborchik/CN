using Coach.Core.Interfaces;
using Coach.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Coach.Infrastructure.Authentication
{
    public class JWTProvider : IJWTProvider
    {
        private readonly JwtOptions _options;

        public JWTProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateTokenCoach(CoachModel coach)
        {
            Claim[] claims = [
                new("userId", coach.Id.ToString()),                
                ];

            return WriteToken(claims);
        }

        public string GenerateTokenSportsmen(Sportsmen sportsmen)
        {
            Claim[] claims = [
                new("userId", sportsmen.Id.ToString())
                ];

            return WriteToken(claims);
        }

        private string WriteToken(Claim[] claims)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
