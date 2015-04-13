using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ioana.RealEstate.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class PhoneNumbersRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            IEnumerable<string> values = value as IEnumerable<string>;
            if (values == null || values.Where(p => !string.IsNullOrWhiteSpace(p)).Count() == 0)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule()
            {
                ValidationType = "phonenumbersrequired",
                ErrorMessage = this.FormatErrorMessage(metadata.ShortDisplayName)
            };

            return new ModelClientValidationRule[] { rule };
        }
    }
}