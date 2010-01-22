/**********************************************************************
* Description:  Abstracts Current Person logic away from database.
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/9/2009
*
* $Workfile: ArenaPersonFactory.cs $
* $Revision: 4 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/ArenaPersonFactory.cs   4   2010-01-11 14:36:25-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/ArenaPersonFactory.cs $
*  
*  Revision: 4   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 3   Date: 2010-01-11 21:25:07Z   User: JasonO 
*  
*  Revision: 2   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-12-10 00:12:32Z   User: JasonO 
**********************************************************************/

using Arena.Core;
using Arena.Custom.Cccev.FrameworkUtils.Entity;

namespace Arena.Custom.Cccev.FrameworkUtils.Util
{
    public class ArenaPersonFactory : IPersonFactory
    {
        public Person GetCurrentPerson()
        {
            return ArenaContext.Current.Person;
        }
    }
}
