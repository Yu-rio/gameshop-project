using ClassLibraryGameShop;
using gameshop_project.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TestShop;

namespace gameshop_project.Server.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        private string _secretKey = "ILoveStrayKidsAndITZYespeciallyLoveYeji";


        // POST: api/Authenticate/Login
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Проверяем учетные данные пользователя
            bool isValidUser = CheckUserCredentials(model.Email, model.Password);

            if (isValidUser)
            {
                // Генерируем токен аутентификации
                var token = GenerateToken(model.Email);
                Customer customer = new CustomerDB().GetByEmail(model.Email);
                String id = customer.CustomerId;
                // Возвращаем токен в ответе
                return Ok(new { token , id});
            }
            else
            {
                // Возвращаем ошибку аутентификации
                return Unauthorized();
            }
        }

        // Метод для проверки учетных данных пользователя
        private bool CheckUserCredentials(string email, string password)
        {
            Customer customer = new CustomerDB().GetByEmail(email);
            if (customer != null)
            {
                if(customer.PasswordHash== password)
                    return true;
            }
            return false;
        }

        // Метод для генерации токена аутентификации
        private string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new System.Security.Claims.Claim[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    
        
    }
}
