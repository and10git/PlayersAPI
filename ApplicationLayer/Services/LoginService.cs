using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using InfraestructureLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationLayer.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginDAO _loginDAO;
        private readonly IConfiguration _configuration;

        public LoginService(ILoginDAO loginDAO, IConfiguration configuration)
        {
            _loginDAO = loginDAO;
            _configuration = configuration;
        }

        public bool Authenticate(string username, string password)
        {           
            var exists = _loginDAO.Exists(username, password);

            return exists;
        }

        public void CreateUser(string username, string password)
        {
            var exists = _loginDAO.Exists(username, password);

            if (!exists)
                _loginDAO.CreateUser(new DomainLayer.Entities.User(Guid.NewGuid(), username, password));
            else
                throw new InvalidOperationException($"The user entered already exists.");
        }

        public string EncodePassword(string password)
        {
            SHA1 sha1 = SHA1.Create();
            var inputBytes = Encoding.UTF8.GetBytes(password);
            var hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

        public string GetToken(string user, string encriptedPassword)
        {            
            var jwtKey = _configuration.GetSection("Jwt").GetSection("Key").Value;
            var jwtIssuer = _configuration.GetSection("Jwt").GetSection("Issuer").Value;
            var jwtAudience = _configuration.GetSection("Jwt").GetSection("Audience").Value;
            var claims = new[]
            {
                new Claim("user", user),
                new Claim("password", encriptedPassword),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.Now.AddHours(1), 
                signingCredentials: creds
            );

            var tokenResult =  new JwtSecurityTokenHandler().WriteToken(token);

            return tokenResult;
        }

    }
}
