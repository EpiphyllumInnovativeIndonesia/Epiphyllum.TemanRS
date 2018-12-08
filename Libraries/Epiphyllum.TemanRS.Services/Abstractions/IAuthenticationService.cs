using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Abstractions;
using Epiphyllum.TemanRS.Services.Models;

namespace Epiphyllum.TemanRS.Services.Abstractions
{
    /// <summary>
    /// Represents an authentication service
    /// </summary>
    public interface IAuthenticationService : IRegisterTransient
    {
        /// <summary>
        /// Represents a login authentication
        /// </summary>
        /// <param name="username">Provided username</param>
        /// <param name="password">Provided password</param>
        /// <returns></returns>
        Task<Authentication> Login(string username, string password);
    }
}
