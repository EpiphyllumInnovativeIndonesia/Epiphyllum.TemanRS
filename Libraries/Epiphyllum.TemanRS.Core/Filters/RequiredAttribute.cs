using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Epiphyllum.TemanRS.Core.Localization.Resources;
using Microsoft.Extensions.Localization;

namespace Epiphyllum.TemanRS.Core.Filters
{
    public class RequiredAttribute : ValidationAttribute
    {
        public new string ErrorMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }

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
