/**********************************************************************
* Description:  Abstracting caching of person types
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 7/10/2009
*
* $Workfile: PersonController.cs $
* $Revision: 3 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Application/PersonController.cs   3   2010-01-11 14:36:25-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Application/PersonController.cs $
*  
*  Revision: 3   Date: 2010-01-11 21:36:25Z   User: JasonO 
**********************************************************************/

using Arena.Core;
using Arena.Custom.Cccev.DataUtils;
using Arena.Custom.Cccev.FrameworkUtils.Entity;
using Arena.Custom.Cccev.FrameworkUtils.FrameworkConstants;
using Arena.Custom.Cccev.FrameworkUtils.Util;

namespace Arena.Custom.Cccev.FrameworkUtils.Application
{
    public static class PersonController
    {
        private const string PERSON_CACHE_FORMAT_STRING = "Cccev.FrameworkUtils.PersonID={0}";

        private static CacheType cacheType;

        public static CacheType CacheType
        {
            get { return cacheType; }
            set { cacheType = value; }
        }

        /// <summary>
        /// Static constructor to initialize default values for fields.
        /// </summary>
        static PersonController()
        {
            cacheType = CacheType.Http;
        }

        /// <summary>
        /// Returns an abstraction of a "cache" object to manage caching from a higher level.
        /// </summary>
        /// <returns>Arena.Custom.Cccev.FrameworkUtils.Interfaces.ICachable object to manage caching</returns>
        public static ICachable GetCache()
        {
            return CacheFactory.GetCache(cacheType);
        }

        public static Person GetPerson(int personID)
        {
            if (personID != Constants.NULL_INT)
            {
                string cacheKey = string.Format(PERSON_CACHE_FORMAT_STRING, personID);
                var cache = GetCache();

                if (cache.Get(cacheKey) != null)
                {
                    return (Person) cache.Get(cacheKey);
                }

                Person person = new Person(personID);
                cache.Insert(cacheKey, person);
                return person;
            }

            return new Person();
        }
    }
}
