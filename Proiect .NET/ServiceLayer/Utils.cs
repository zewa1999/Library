using FluentValidation.Results;
using NLog;

namespace Library.ServiceLayer
{
    public static class Utils
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public static bool LogErrors(ValidationResult results)
        {
            if (results.IsValid == false)
            {
                foreach (var error in results.Errors)
                {
                     _logger.Error($"{error.ErrorMessage}");
                }
                return false;
            }
            return true;
        }
    }
}