/**********************************************************************
* Description:  Abstraction for fetching Arena configuration data
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/9/2009
*
* $Workfile: ConfigurationBase.cs $
* $Revision: 5 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/ConfigurationBase.cs   5   2010-01-11 14:29:11-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/ConfigurationBase.cs $
*  
*  Revision: 5   Date: 2010-01-11 21:29:11Z   User: JasonO 
*  
*  Revision: 4   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 3   Date: 2010-01-04 22:18:11Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-12-29 17:11:02Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-12-10 00:12:32Z   User: JasonO 
**********************************************************************/

using System;
using System.Configuration;
using Arena.Core;

namespace Arena.Custom.Cccev.FrameworkUtils.Util
{
    /// <summary>
    /// Base class to provide common functionality to accessing information stored in
    /// configuration files or in the Arena database.
    /// </summary>
    public abstract class ConfigurationBase
    {
        /// <summary>
        /// Attempts to retrieve a fully qualified Assembly/Class name path from web.config/
        /// app.config or Arena Organization Settings.
        /// </summary>
        /// <param name="key">Configuration key to query against</param>
        /// <returns>
        ///     String array with the first member being the assembly name 
        ///     and the second being the fully-qualified class
        /// </returns>
        protected static string[] GetConfigurationPath(string key)
        {
            string val = ConfigurationManager.AppSettings.Get(key);

            if (val != null)
            {
                return val.Split(new[] { ',' });
            }

            try
            {
                return ArenaContext.Current.Organization.Settings[key].Split(new[] { ',' });
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        /// <summary>
        /// Attempts to retrieve a singular string value from the web.config/app.config
        /// or Arena Organization Settings.
        /// </summary>
        /// <param name="key">Configuration key to query against</param>
        /// <returns>Configuration setting value</returns>
        protected static string GetConfigurationSetting(string key)
        {
            string val = ConfigurationManager.AppSettings.Get(key);

            if (val != null)
            {
                return val;
            }

            try
            {
                return ArenaContext.Current.Organization.Settings[key];
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
