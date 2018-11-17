using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Common.Data;
using Epiphyllum.TemanRS.Repositories.Domain.Accounts;

namespace Epiphyllum.TemanRS.Services.Accounts
{
    /// <summary>
    /// Represents an user service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get list of users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.SelectAll();
        }

        /// <summary>
        /// Gets an user
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        public async Task<User> GetUser(int id)
        {
            return await _userRepository.SelectById(id);
        }

        /// <summary>
        /// Creates an user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateUser(User user)
        {
            await _userRepository.Insert(user);
        }

        /// <summary>
        /// Updates an user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UpdateUser(User user)
        {
            await _userRepository.Update(user);
        }

        /// <summary>
        /// Deletes an user
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        public async Task DeleteUser(int id)
        {
            User deletedUser = await _userRepository.SelectById(id);
            await _userRepository.Delete(deletedUser);
        }
    }
}
