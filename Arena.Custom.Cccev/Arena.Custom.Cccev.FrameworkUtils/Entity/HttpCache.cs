/**********************************************************************
* Description:	Concrete implementation of ICachable that utilizes the Application Cache
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	7/6/2009
*
* $Workfile: HttpCache.cs $
* $Revision: 12 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/HttpCache.cs   12   2010-01-12 09:00:46-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/HttpCache.cs $
*  
*  Revision: 12   Date: 2010-01-12 16:00:46Z   User: JasonO 
*  
*  Revision: 11   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 10   Date: 2010-01-11 21:29:11Z   User: JasonO 
*  
*  Revision: 9   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 8   Date: 2010-01-11 21:10:04Z   User: JasonO 
*  
*  Revision: 7   Date: 2010-01-07 22:04:10Z   User: JasonO 
*  
*  Revision: 6   Date: 2010-01-06 21:32:20Z   User: JasonO 
*  
*  Revision: 5   Date: 2009-10-22 16:57:25Z   User: JasonO 
*  
*  Revision: 4   Date: 2009-10-22 16:57:03Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-08-18 15:29:36Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-07-06 21:12:15Z   User: JasonO 
*  Adding more common interface elements to caching contracts. 
*  
*  Revision: 1   Date: 2009-07-06 18:50:52Z   User: JasonO 
*  Abstracting caching. 
**********************************************************************/

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using Arena.Custom.Cccev.FrameworkUtils.FrameworkConstants;
using Arena.Custom.Cccev.FrameworkUtils.Util;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public sealed class HttpCache : ICachable
    {
        private static volatile HttpCache instance;

        /// <summary>
        /// Static implementation to limit how Cache is accessed.
        /// </summary>
        public static HttpCache Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpCache();
                }

                return instance;
            }
        }

        public object Cache
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    throw new NullReferenceException(
                        "If using this functionality outside of ASP.NET, set the CacheType of the caller to CacheType.Dictionary.");
                }

                return HttpContext.Current.Cache;
            }
        }

        private Cache AppCache
        {
            get { return (Cache) Cache; }
        }

        public int Count
        {
            get { return AppCache.Count; }
        }

        public object Get(string key)
        {
            return AppCache.Get(key);
        }

        public void Insert(string key, object value)
        {
            AppCache.Add(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                CacheHelper.GetTimeToLive(), CacheItemPriority.Normal, OnItemRemoved);
        }

        public void Remove(string key)
        {
            AppCache.Remove(key);
        }

        public void Clear()
        {
            List<object> keys = new List<object>();
            var enumerator = AppCache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().Contains(ArenaConstants.CENTRAL_ORG_CODE))
                {
                    keys.Add(enumerator.Key);
                }
            }

            foreach (var key in keys)
            {
                Remove(key.ToString());
            }
        }

        private HttpCache()
        {
        }

        private static void OnItemRemoved(string key, object value, CacheItemRemovedReason reason)
        {
        }
    }
}
