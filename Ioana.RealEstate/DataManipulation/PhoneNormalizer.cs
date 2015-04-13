using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Ioana.RealEstate.DataManipulation
{
    public class PhoneNormalizer
    {
        public string Normalize(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length == 1)
            {
                return phoneNumber;
            }

            phoneNumber = phoneNumber.Trim();

            if (phoneNumber[0] == '0' && !phoneNumber.StartsWith("00"))
            {
                phoneNumber = string.Concat("00359", phoneNumber.Substring(1));
            }

            if (phoneNumber[0] == '+')
            {
                phoneNumber = string.Concat("00", phoneNumber.Substring(1));
            }

            phoneNumber = Regex.Replace(phoneNumber, "\\D", string.Empty);

            return phoneNumber;
        }
    }
}