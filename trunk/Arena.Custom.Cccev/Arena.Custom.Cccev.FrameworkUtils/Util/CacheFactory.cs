/**********************************************************************
* Description:  Dynamically instantiates an ICachable object given certain criteria
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 8/18/2009
*
* $Workfile: CacheFactory.cs $
* $Revision: 8 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/CacheFactory.cs   8   2010-01-11 14:36:25-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/CacheFactory.cs $
*  
*  Revision: 8   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 7   Date: 2010-01-11 21:29:11Z   User: JasonO 
*  
*  Revision: 6   Date: 2010-01-11 21:25:07Z   User: JasonO 
*  
*  Revision: 5   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 4   Date: 2009-10-22 16:57:03Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-08-18 16:53:58Z   User: JasonO 
**********************************************************************/

using Arena.Custom.Cccev.FrameworkUtils.Entity;
using Arena.Custom.Cccev.FrameworkUtils.FrameworkConstants;

namespace Arena.Custom.Cccev.FrameworkUtils.Util
{
    public static class CacheFactory
    {
        public static ICachable GetCache(CacheType type)
        {
            switch (type)
            {
                case CacheType.Http:
                    return HttpCache.Instance;
                case CacheType.Session:
                    return SessionCache.Instance;
                case CacheType.Dictionary:
                    return DictionaryCache.Instance;
                default:
                    return null;
            }
        }
    }
}
