/**********************************************************************
* Description:  Abstraction to allow Core.Person to be a little bit more decoupled from Arena db
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/9/2009
*
* $Workfile: IPersonFactory.cs $
* $Revision: 2 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/IPersonFactory.cs   2   2010-01-11 14:36:25-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/IPersonFactory.cs $
*  
*  Revision: 2   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-12-10 00:12:32Z   User: JasonO 
**********************************************************************/

using Arena.Core;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public interface IPersonFactory
    {
        Person GetCurrentPerson();
    }
}
