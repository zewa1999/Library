// ***********************************************************************
// Assembly         : Library.UI
// Author           : costa
// Created          : 11-28-2021
//
// Last Modified By : costa
// Last Modified On : 12-08-2021
// ***********************************************************************
// <copyright file="ConfigurationEditor.cs" company="Library.UI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Proiect_.NET
{
    using Library.DomainLayer;
    using Newtonsoft.Json;
    using System;
    using System.IO;

    /// <summary>
    /// Class ConfigurationEditor.
    /// </summary>
    public static class ConfigurationEditor
    {
        /// <summary>
        /// The logger
        /// </summary>
        //private static readonly ILogger _logger;

        /// <summary>
        /// Initializes static members of the <see cref="ConfigurationEditor"/> class.
        /// </summary>

        static ConfigurationEditor()
        {
        }

        /// <summary>
        /// Loads all properties.
        /// </summary>
        /// <returns>PropertiesModel.</returns>
        public static PropertiesModel LoadAllProperties()
        {
            PropertiesModel properties = null;
            try
            {
                using (StreamReader r = new StreamReader("AppSettings.json"))
                {
                    string json = r.ReadToEnd();
                    properties = JsonConvert.DeserializeObject<PropertiesModel>(json);
                }
            }
            catch (Exception ex)
            {
                //_logger.Error($"{ex.Message}");
            }

            if (properties == null)
            {
                //_logger.Error($"The properties object is null.");
            }

            //_logger.Info($"Finished LoadAllProperties method.");
            return properties;
        }

        /// <summary>
        /// Saves the properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        public static void SaveProperties(PropertiesModel properties)
        {
            //_logger.Info($"Entering SaveProperties method.");

            if (properties == null)
            {
                //_logger.Info($"The properties object is null. Finishing the method...");
                return;
            }

            try
            {
                var json = JsonConvert.SerializeObject(properties, Formatting.Indented);
                var path = @"C:\Users\costa\OneDrive\Desktop\Proiect .NET\Proiect .NET\AppSettings.json";
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                //  _logger.Info($"{ex.Message}");
            }

            // _logger.Info($"The properties were properly saved.");
        }
    }
}