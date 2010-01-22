/**********************************************************************
* Description:  Concrete implementation of ICachable that utilizes the current HTTP Session
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 10/21/2009
*
* $Workfile: SessionCache.cs $
* $Revision: 6 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/SessionCache.cs   6   2010-01-11 14:36:25-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/SessionCache.cs $
*  
*  Revision: 6   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 5   Date: 2010-01-11 21:29:11Z   User: JasonO 
*  
*  Revision: 4   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 3   Date: 2010-01-07 22:04:10Z   User: JasonO 
*  
*  Revision: 2   Date: 2010-01-06 21:32:20Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-10-22 16:57:01Z   User: JasonO 
**********************************************************************/

using System;
using System.Web;
using System.Web.SessionState;
using Arena.Custom.Cccev.FrameworkUtils.FrameworkConstants;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public sealed class SessionCache : ICachable
    {
        private static SessionCache instance;

        /// <summary>
        /// Singleton implementation to limit how Cache is accessed.
        /// </summary>
        public static SessionCache Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionCache();
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

                return HttpContext.Current.Session;
            }
        }

        private HttpSessionState Session
        {
            get { return (HttpSessionState) Cache; }
        }

        public int Count
        {
            get { return Session.Count; }
        }

        public object Get(string key)
        {
            return Session[key];
        }

        public void Insert(string key, object value)
        {
            Session.Add(key, value);
        }

        public void Remove(string key)
        {
            Session.Remove(key);
        }

        public void Clear()
        {
            for (int i = 0; i < Session.Keys.Count; i++)
            {
                string key = Session.Keys[i];

                if (key.Contains(ArenaConstants.CENTRAL_ORG_CODE))
                {
                    Remove(key);
                }
            }
        }

        private SessionCache()
        {
        }
    }
}
