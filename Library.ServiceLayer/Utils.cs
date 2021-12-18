using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ServiceLayer
{
    public static class Utils
    {
        public static bool CheckErrors(ValidationResult results)
        {
            if (results.IsValid == false)
            {
                foreach (var error in results.Errors)
                {
                    // _logger.Error($"{error.ErrorMessage}");
                }
                return false;
            }
            return true;
        }
    }
}