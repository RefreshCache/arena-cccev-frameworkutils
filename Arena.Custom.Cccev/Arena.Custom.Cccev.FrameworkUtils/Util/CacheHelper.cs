/**********************************************************************
* Description:  Decouples caching configuration from business logic
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/29/2009
*
* $Workfile: CacheHelper.cs $
* $Revision: 7 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/CacheHelper.cs   7   2010-01-11 14:36:25-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/CacheHelper.cs $
*  
*  Revision: 7   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 6   Date: 2010-01-11 21:29:11Z   User: JasonO 
*  
*  Revision: 5   Date: 2010-01-11 21:25:07Z   User: JasonO 
*  
*  Revision: 4   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 3   Date: 2010-01-11 21:10:04Z   User: JasonO 
*  
*  Revision: 2   Date: 2010-01-04 22:18:11Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-12-29 17:10:58Z   User: JasonO 
**********************************************************************/

using System;
using Arena.Custom.Cccev.FrameworkUtils.FrameworkConstants;

namespace Arena.Custom.Cccev.FrameworkUtils.Util
{
    public class CacheHelper : ConfigurationBase
    {
        private const string CACHE_TYPE_KEY = "Cccev.FrameworkUtils.CacheType";
        private const string CACHE_TIME_TO_LIVE = "Cccev.FrameworkUtils.CacheTimeToLive";

        /// <summary>
        /// Will attempt to load the current Cache Type from web.config/app.config or
        /// from Arena Organization Settings.
        /// </summary>
        /// <returns>Enum value of current Cache Type</returns>
        public static CacheType GetCacheType()
        {
            string cacheType = GetConfigurationSetting(CACHE_TYPE_KEY);

            if (cacheType != null)
            {
                return (CacheType) Enum.Parse(typeof (CacheType), cacheType);
            }

            throw new ApplicationException(
                string.Format("'{0}' has not been defined in Config or Organization settings.", CACHE_TYPE_KEY));
        }

        /// <summary>
        /// Will attempt to load the current Time To Live from web.config/app.config or
        /// from Arena Organization Settings.
        /// </summary>
        /// <returns>TimeStamp of minutes for items in the cache to live for.</returns>
        public static TimeSpan GetTimeToLive()
        {
            string ttl = GetConfigurationSetting(CACHE_TIME_TO_LIVE);

            if (ttl != null)
            {
                return TimeSpan.FromMinutes(double.Parse(ttl));
            }

            return TimeSpan.FromMinutes(30);
        }
    }
}
