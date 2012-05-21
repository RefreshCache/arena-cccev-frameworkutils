/**********************************************************************
* Description: Extension methods for collections of Prayer Activity
* Created By:   Nick Airdo @ Central Christian Church of the East Valley
* Date Created:	05/03/2009 17:42:02
*
* $Workfile: PrayerActivityCollectionExtension.cs $
* $Revision: 1 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/PrayerActivityCollectionExtension.cs   1   2010-07-21 15:19:20-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/PrayerActivityCollectionExtension.cs $
*  
*  Revision: 1   Date: 2010-07-21 22:19:20Z   User: JasonO 
*  Refactoring generic arena-specific code into FrameworkUtils assembly. 
*  
*  Revision: 2   Date: 2009-05-04 17:46:21Z   User: nicka 
*  
*  Revision: 1   Date: 2009-05-04 17:40:33Z   User: nicka 
**********************************************************************/
using System.Data.SqlClient;
using Arena.Custom.Cccev.FrameworkUtils.Data;
using Arena.DataLayer.Prayer;
using Arena.Prayer;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public static class PrayerActivityCollectionExtension
    {
		/// <summary>
		/// Load a collection of Prayer Activity for the given person.
		/// </summary>
		/// <param name="ac"></param>
		/// <param name="personID">ID of the person to fetch activity for</param>
        public static void LoadActivityByPersonID(this ActivityCollection ac, int personID )
        {
			SqlDataReader activityByPersonID = new RequestData().GetActivityByPersonID( personID );
			while ( activityByPersonID.Read() )
			{
				ac.Add( new Activity( activityByPersonID ) );
			}
			activityByPersonID.Close();
        }
    }
}