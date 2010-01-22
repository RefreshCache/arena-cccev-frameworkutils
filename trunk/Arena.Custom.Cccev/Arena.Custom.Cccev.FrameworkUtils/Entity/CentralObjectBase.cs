/**********************************************************************
* Description:  Abstract class to define common members to each domain
*               model entity class.
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/29/2009
*
* $Workfile: CentralObjectBase.cs $
* $Revision: 3 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/CentralObjectBase.cs   3   2010-01-04 15:18:11-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/CentralObjectBase.cs $
*  
*  Revision: 3   Date: 2010-01-04 22:18:11Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-12-30 15:42:32Z   User: JasonO 
**********************************************************************/

using System;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    /// <summary>
    /// Base Entity class to add common entity properties to
    /// concrete implementations.
    /// </summary>
    public abstract class CentralObjectBase
    {
        public virtual string CreatedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime DateModified { get; set; }

        /// <summary>
        /// Property that must be overridden to enforce domain-level
        /// validation.
        /// </summary>
        public abstract bool IsValid { get; }
    }
}
