// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="Utils.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.ServiceLayer
{
    using FluentValidation.Results;
    using NLog;

    /// <summary>
    /// Class Utils.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Logs the errors.
        /// </summary>
        /// <param name="results">The results.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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