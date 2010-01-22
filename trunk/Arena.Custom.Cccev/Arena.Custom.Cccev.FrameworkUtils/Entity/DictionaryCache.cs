/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: DictionaryCache.cs $
* $Revision: 6 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/DictionaryCache.cs   6   2010-01-11 14:36:25-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/DictionaryCache.cs $
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
*  Revision: 1   Date: 2009-07-07 18:12:52Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-07-06 21:46:29Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-07-06 21:12:15Z   User: JasonO 
*  Adding more common interface elements to caching contracts. 
*  
*  Revision: 1   Date: 2009-07-06 18:50:52Z   User: JasonO 
*  Abstracting caching. 
**********************************************************************/

using System.Collections.Generic;
using Arena.Custom.Cccev.FrameworkUtils.FrameworkConstants;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public class DictionaryCache : ICachable
    {
        private static volatile DictionaryCache instance;
        private static readonly object SYNC_ROOT = new object();
        private Dictionary<string, object> cache;

        /// <summary>
        /// Singleton implementation to prevent multiple cache Dictionaries from being instantiated.
        /// </summary>
        public static DictionaryCache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SYNC_ROOT)
                    {
                        if (instance == null)
                        {
                            instance = new DictionaryCache();
                        }
                    }
                }

                return instance;
            }
        }

        public object Cache
        {
            get
            {
                if (cache == null)
                {
                    cache = new Dictionary<string, object>();
                }

                return cache;
            }
        }

        private Dictionary<string, object> Dictionary
        {
            get { return (Dictionary<string, object>) Cache; }
        }

        public int Count
        {
            get { return Dictionary.Count; }
        }

        public object Get(string key)
        {
            return Dictionary.ContainsKey(key) ? Dictionary[key] : null;
        }

        public void Insert(string key, object value)
        {
            if (!Dictionary.ContainsKey(key))
            {
                Dictionary.Add(key, value);
            }
            else
            {
                Dictionary[key] = value;
            }
        }

        public void Remove(string key)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary.Remove(key);
            }
        }

        public void Clear()
        {
            List<string> keys = new List<string>();

            foreach (var i in Dictionary)
            {
                if (i.Key.Contains(ArenaConstants.CENTRAL_ORG_CODE))
                {
                    keys.Add(i.Key);
                }
            }

            foreach (var k in keys)
            {
                Remove(k);
            }
        }

        private DictionaryCache()
        {
        }
    }
}
