using Microsoft.AspNetCore.Identity;

namespace MyApi.Domain.Entities
{
    /// <summary>
    /// Entidade de usuário para autenticação e autorização.
    /// Herda de IdentityUser para uso com ASP.NET Core Identity.
    /// </summary>
    public class User : IdentityUser
    {
        // Adicione propriedades customizadas aqui se necessário
    }
} 