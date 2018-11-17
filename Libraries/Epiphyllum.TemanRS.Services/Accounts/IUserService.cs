using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Epiphyllum.TemanRS.Repositories.Domain.Accounts;

namespace Epiphyllum.TemanRS.Services.Accounts
{
    /// <summary>
    /// Represents an user service
    /// </summary>
    public interface IUserService : IRegisterTransient
    {
        /// <summary>
        /// Get list of users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Gets an user
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        Task<User> GetUser(int id);

        /// <summary>
        /// Creates an user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateUser(User user);

        /// <summary>
        /// Updates an user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task UpdateUser(User user);

        /// <summary>
        /// Deletes an user
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        Task DeleteUser(int id);
    }
}
