using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Core.Infrastructures
{
    /// <summary>
    /// Represents a user manager
    /// </summary>
    public partial interface IUserManager : IRegisterScoped
    {
        /// <summary>
        /// Gets or sets the user manager user id
        /// </summary>
        int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user manager username
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the user manager roles
        /// </summary>
        string[] Roles { get; set; }

        /// <summary>
        /// Gets or sets the user manager department
        /// </summary>
        string Department { get; set; }
    }
}
