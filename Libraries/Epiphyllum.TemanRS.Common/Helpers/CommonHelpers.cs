using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Epiphyllum.TemanRS.Common.Infrastructures;

namespace Epiphyllum.TemanRS.Common.Helpers
{
    /// <summary>
    /// Represents a common helpers
    /// </summary>
    public partial class CommonHelpers : IRegisterSingleton
    {
        private const string _encodedPattern = @"^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$";

        private static readonly Regex _encodedRegex;

        static CommonHelpers()
        {
            _encodedRegex = new Regex(_encodedPattern);
        }

        /// <summary>
        /// Verifies that a string is endoded format
        /// </summary>
        /// <param name="providedString">String to verify</param>
        /// <returns>True if the string is endoded and false if it's not</returns>
        public bool IsBase64Encoded(string providedString)
        {
            if (string.IsNullOrEmpty(providedString))
                return false;

            return (providedString.Length % 4 == 0) && _encodedRegex.IsMatch(providedString);
        }
    }
}
