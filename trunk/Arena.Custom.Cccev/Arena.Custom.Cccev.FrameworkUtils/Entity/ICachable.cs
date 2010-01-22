/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: ICachable.cs $
* $Revision: 4 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/ICachable.cs   4   2010-01-11 14:36:25-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/ICachable.cs $
*  
*  Revision: 4   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 3   Date: 2010-01-06 21:32:20Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-07-06 21:12:15Z   User: JasonO 
*  Adding more common interface elements to caching contracts. 
*  
*  Revision: 1   Date: 2009-07-06 18:50:28Z   User: JasonO 
**********************************************************************/

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public interface ICachable
    {
        object Cache { get; }
        int Count { get; }

        object Get(string key);
        void Insert(string key, object value);
        void Remove(string key);
        void Clear();
    }
}
