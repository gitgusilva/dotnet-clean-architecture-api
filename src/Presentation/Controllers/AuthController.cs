using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MyApi.Presentation.Middleware;
using Microsoft.AspNetCore.Identity;
using MyApi.Domain.Entities;
using System.Threading.Tasks;

namespace MyApi.Presentation.Controllers
{
    /// <summary>
    /// Controller responsável pela autenticação e registro de usuários.
    /// </summary>
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly string _jwtSecret;
        private readonly UserManager<User> _userManager;
        /// <summary>
        /// Inicializa uma nova instância de AuthController.
        /// </summary>
        /// <param name="config">Configuração da aplicação.</param>
        /// <param name="userManager">Gerenciador de usuários do Identity.</param>
        public AuthController(IConfiguration config, UserManager<User> userManager)
        {
            _jwtSecret = config["Jwt:Secret"];
            _userManager = userManager;
        }
        /// <summary>
        /// Realiza o login do usuário e retorna um JWT se as credenciais forem válidas.
        /// </summary>
        /// <param name="req">Dados de login.</param>
        /// <returns>Token JWT ou Unauthorized.</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            // Exemplo: autenticação fake (substitua por validação real)
            if (req.Username == "admin" && req.Password == "admin")
            {
                var token = GenerateJwtToken(req.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }
        /// <summary>
        /// Registra um novo usuário no sistema.
        /// </summary>
        /// <param name="req">Dados de registro.</param>
        /// <returns>200 OK se sucesso, 400 BadRequest se erro.</returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var user = new User { UserName = req.Username, Email = req.Email };
            var result = await _userManager.CreateAsync(user, req.Password);
            if (result.Succeeded)
                return Ok();
            return BadRequest(result.Errors);
        }
        /// <summary>
        /// Gera um token JWT para o usuário autenticado.
        /// </summary>
        /// <param name="username">Nome do usuário.</param>
        /// <returns>Token JWT.</returns>
        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        /// <summary>
        /// Modelo de requisição para login.
        /// </summary>
        public class LoginRequest
        {
            /// <summary>
            /// Nome de usuário.
            /// </summary>
            public string Username { get; set; }
            /// <summary>
            /// Senha.
            /// </summary>
            public string Password { get; set; }
        }
        /// <summary>
        /// Modelo de requisição para registro.
        /// </summary>
        public class RegisterRequest
        {
            /// <summary>
            /// Nome de usuário.
            /// </summary>
            public string Username { get; set; }
            /// <summary>
            /// Email do usuário.
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// Senha.
            /// </summary>
            public string Password { get; set; }
        }
    }
} 