/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: IModifiable.cs $
* $Revision: 4 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/IModifiable.cs   4   2010-01-11 14:36:25-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/IModifiable.cs $
*  
*  Revision: 4   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-06-22 21:34:43Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-06-22 20:23:04Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-06-22 20:21:19Z   User: JasonO 
*  Adding encapsulated modify functionality. 
**********************************************************************/

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public interface IModifiable
    {
        bool Modified { get; }
    }
}