using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Epiphyllum.TemanRS.Core.Localization.Resources;
using Microsoft.Extensions.Localization;

namespace Epiphyllum.TemanRS.Core.Filters
{
    /// <summary>
    /// Represents a required attribute
    /// </summary>
    public class RequiredAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets or sets the required attribute error message
        /// </summary>
        public new string ErrorMessage { get; set; }

        /// <summary>
        /// Overrides is valid method from <see cref="ValidationAttribute"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }

        /// <summary>
        /// Overrides format error message method from <see cref="ValidationAttribute"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null)
            {
                var stringLocalizer = EngineContext.Current.Resolve<IStringLocalizer<AttributeMessage>>();
                ErrorMessage = stringLocalizer[AttributeMessage.Required];
            }

            return string.Format(ErrorMessage, name);
        }
    }
}
