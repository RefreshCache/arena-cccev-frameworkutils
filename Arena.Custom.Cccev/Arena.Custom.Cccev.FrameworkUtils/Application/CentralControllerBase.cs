/**********************************************************************
* Description:  Base controller object that offers shared cache management
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/30/2009
*
* $Workfile: CentralControllerBase.cs $
* $Revision: 10 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Application/CentralControllerBase.cs   10   2010-01-21 17:41:45-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Application/CentralControllerBase.cs $
*  
*  Revision: 10   Date: 2010-01-22 00:41:45Z   User: JasonO 
*  
*  Revision: 9   Date: 2010-01-22 00:28:06Z   User: JasonO 
*  
*  Revision: 8   Date: 2010-01-11 21:38:49Z   User: JasonO 
*  
*  Revision: 7   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 6   Date: 2010-01-06 23:42:40Z   User: JasonO 
*  
*  Revision: 5   Date: 2010-01-06 21:32:20Z   User: JasonO 
*  
*  Revision: 4   Date: 2010-01-04 22:18:11Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-12-30 18:57:25Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-12-30 18:14:27Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-12-30 17:36:05Z   User: JasonO 
**********************************************************************/

using System;
using Arena.Custom.Cccev.FrameworkUtils.Entity;
using Arena.Custom.Cccev.FrameworkUtils.Util;

namespace Arena.Custom.Cccev.FrameworkUtils.Application
{
    /// <summary>
    /// Base Controller class to add basic caching functionality via static methods
    /// to concrete implementations.
    /// </summary>
    public abstract class CentralControllerBase
    {
        public virtual void OnCacheRefreshed()
        {
            var cache = CacheFactory.GetCache(CacheHelper.GetCacheType());
            cache.Clear();
        }

        /// <summary>
        /// Will attempt to retrieve matching object by its key from the server cache.
        /// If unsuccessful, will attempt to instantiate the object via constructor.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="keyPrefix">Prefix for cache key</param>
        /// <param name="id">ID value to be appended to cache key</param>
        /// <returns>Object corresponding to key</returns>
        protected static T GetCachedObject<T>(string keyPrefix, int id)
        {
            string key = GetKey(keyPrefix, id);
            var cache = CacheFactory.GetCache(CacheHelper.GetCacheType());
            object cachedObject;

            if (cache.Get(key) != null)
            {
                return (T) cache.Get(key);   
            }

            try
            {
                Type type = typeof(T);
                cachedObject = Activator.CreateInstance(type, id);
            }
            catch
            {
                cachedObject = Activator.CreateInstance<T>();
            }

            SaveObjectToCache(cache, keyPrefix, id, cachedObject);
            return (T)cachedObject;
        }

        /// <summary>
        /// Will save an object to the current cache.
        /// </summary>
        /// <param name="keyPrefix">Prefix for cache key</param>
        /// <param name="id">ID value to be appended to cache key</param>
        /// <param name="val">Object to be cached</param>
        protected static void SaveObjectToCache(string keyPrefix, int id, object val)
        {
            SaveObjectToCache(CacheFactory.GetCache(CacheHelper.GetCacheType()), keyPrefix, id, val);
        }

        protected static void SaveObjectToCache(ICachable cache, string keyPrefix, int id, object val)
        {
            string key = GetKey(keyPrefix, id);
            cache.Insert(key, val);
        }

        /// <summary>
        /// Will remove an object from the current cache.
        /// </summary>
        /// <param name="keyPrefix">Prefix for cache key</param>
        /// <param name="id">ID value to be appended to cache key</param>
        protected static void RemoveObjectFromCache(string keyPrefix, int id)
        {
            RemoveObjectFromCache(CacheFactory.GetCache(CacheHelper.GetCacheType()), keyPrefix, id);
        }

        protected static void RemoveObjectFromCache(ICachable cache, string keyPrefix, int id)
        {
            string key = GetKey(keyPrefix, id);
            cache.Remove(key);
        }

        private static string GetKey(string prefix, int id)
        {
            return string.Format("{0}_{1}", prefix, id);
        }
    }
}
