using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Common;
using Epiphyllum.TemanRS.Common.Enums;
using Epiphyllum.TemanRS.Common.Security;
using Epiphyllum.TemanRS.Repositories;
using Epiphyllum.TemanRS.Repositories.Domain.Accounts;
using Microsoft.IdentityModel.Tokens;

namespace Epiphyllum.TemanRS.Services.Accounts
{
    /// <summary>
    /// Represents an authentication service
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IRepository<User> userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Represents a login authentication
        /// </summary>
        /// <param name="username">Provided username</param>
        /// <param name="password">Provided password</param>
        /// <returns></returns>
        public async Task<Authentication> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            User user = await _userRepository.Select(prop => prop.Username == username, $"{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
            if (user == null)
            {
                throw new ArgumentNullException("Username is not valid.");
            }

            Authentication authentication = new Authentication();
            PasswordVerificationStatus verificationStatus = _passwordHasher.VerifyHashedPassword(user.Password, password);
            if (verificationStatus == PasswordVerificationStatus.Failed)
            {
                throw new ArgumentNullException("Username and password doesn't match.");
            }
            else if (verificationStatus == PasswordVerificationStatus.SuccessRehashNeeded)
            {
                string hashedPassword = _passwordHasher.HashPassword(user.Password);
                user.Password = hashedPassword;
                await _userRepository.Update(user);
            }

            authentication.Username = user.Username;
            authentication.Token = GenerateToken(user);
            authentication.Roles = user.UserRoles.Select(prop => prop.Role);

            return authentication;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Th1s !s 5ecR3t k3Y !!!");
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
