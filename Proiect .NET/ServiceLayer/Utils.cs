using FluentValidation.Results;

namespace Library.ServiceLayer
{
    public static class Utils
    {
        public static bool LogErrors(ValidationResult results)
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