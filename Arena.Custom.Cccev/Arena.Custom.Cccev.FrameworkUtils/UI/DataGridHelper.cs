/**********************************************************************
* Description:  Encapsulates additional support for Arena Data Grid
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/15/2009
*
* $Workfile: DataGridHelper.cs $
* $Revision: 1 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/DataGridHelper.cs   1   2009-12-15 14:42:38-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/DataGridHelper.cs $
*  
*  Revision: 1   Date: 2009-12-15 21:42:38Z   User: JasonO 
**********************************************************************/

using System;

namespace Arena.Custom.Cccev.FrameworkUtils.UI
{
    public static class DataGridHelper
    {
        /// <summary>
        /// A method must be supplied for the ArenaDataGrid's Rebind event.
        /// Even if there's nothing going on within the event itself, or there
        /// is no need, the ArenaDataGrid requires one to be supplied, or it
        /// will throw a NullReferenceException.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">EventArgs e</param>
        public static void EmptyEvent(object sender, EventArgs e) { }
    }
}
