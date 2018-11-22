using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Data;
using Epiphyllum.TemanRS.Core.Helpers;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Epiphyllum.TemanRS.Repositories.Domain.Accounts;
using Microsoft.AspNetCore.Http;

namespace Epiphyllum.TemanRS.Repositories.Data
{
    /// <summary>
    /// Represents a user manager
    /// </summary>
    public partial class UserManager : IUserManager
    {
        private readonly IHttpContextAccessor _httpContext;
        private string _username;
        private int _userId;
        private string[] _roles;
        private string _department;

        public UserManager(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        /// <summary>
        /// Gets or sets the user manager user id
        /// </summary>
        public int UserId
        {
            get
            {
                if (_userId <= 0)
                {
                    int.TryParse(_httpContext.HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value, out _userId);
                }
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        /// <summary>
        /// Gets or sets the user manager username
        /// </summary>
        public string Username
        {
            get
            {
                if (_username == null)
                {
                    _username = _httpContext.HttpContext.User.Identity.Name;
                }
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        /// <summary>
        /// Gets or sets the user manager roles
        /// </summary>
        public string[] Roles
        {
            get
            {
                if (_roles == null)
                {
                    var repository = EngineContext.Current.Resolve<IRepository<User>>();
                    User user = Task.Run(() =>
                        repository.Select(prop => prop.Id == UserId && prop.Username == Username, $"{nameof(User.UserRoles)}.{nameof(UserRole.Role)}")).Result;
                    _roles = user.UserRoles.Select(prop => prop.Role).Select(prop => prop.RoleName).ToArray();
                }
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }

        /// <summary>
        /// Gets or sets the user manager department
        /// </summary>
        public string Department { get => _department; set => _department = value; }
    }
}
