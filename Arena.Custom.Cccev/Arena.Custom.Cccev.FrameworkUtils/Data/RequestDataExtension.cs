/**********************************************************************
* Description: Extension of Arena's RequestData class.
* Created By:   Nick Airdo @ Central Christian Church of the East Valley
* Date Created:	05/03/2009 17:42:02
*
* $Workfile: RequestDataExtension.cs $
* $Revision: 1 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/RequestDataExtension.cs   1   2010-07-21 15:19:20-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/RequestDataExtension.cs $
*  
*  Revision: 1   Date: 2010-07-21 22:19:20Z   User: JasonO 
*  Refactoring generic arena-specific code into FrameworkUtils assembly. 
*  
*  Revision: 2   Date: 2010-01-27 22:00:24Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-05-04 17:40:33Z   User: nicka 
**********************************************************************/
using System.Collections;
using System.Data.SqlClient;

using Arena.DataLayer.Prayer;

namespace Arena.Custom.Cccev.FrameworkUtils.Data
{
    public static class RequestDataExtension
    {
		/// <summary>
		/// Retrieve a reader containing Prayer Activity for the given person.
		/// </summary>
		/// <param name="requestData"></param>
		/// <param name="personID">ID of person to fetch activity for</param>
		/// <returns>a reader containing Prayer Activity</returns>
		public static SqlDataReader GetActivityByPersonID( this RequestData requestData, int personID )
		{
			SqlDataReader reader;
			ArrayList paramList = new ArrayList();
			paramList.Add( new SqlParameter( "@PersonID", personID ) );
			try
			{
				reader = requestData.ExecuteSqlDataReader( "cust_cccev_pryr_sp_get_activityByPersonID", paramList );
			}
			catch ( SqlException exception )
			{
				throw exception;
			}

			return reader;
		}
    }
}