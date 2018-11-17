using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Epiphyllum.TemanRS.Repositories.Domain.Accounts;

namespace Epiphyllum.TemanRS.Services.Accounts
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
