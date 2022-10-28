using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.Controllers
{
    public class EmailValidator
    {
        public static bool ValidateEmail(String text)
        {
            //if (String.IsNullOrEmpty(text))
            //{
                return !String.IsNullOrEmpty(text) && new EmailAddressAttribute().IsValid(text);
                //return false;
            //}

            //return new EmailAddressAttribute().IsValid(text);
        }
    }
}
