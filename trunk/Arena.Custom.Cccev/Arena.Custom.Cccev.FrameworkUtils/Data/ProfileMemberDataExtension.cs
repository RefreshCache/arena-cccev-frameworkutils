/**********************************************************************
* Description: Extension methods for the ProfileMemberActivityData class
* Created By:   Nick Airdo @ Central Christian Church of the East Valley
* Date Created:	08/28/2009 19:09:28
*
* $Workfile: ProfileMemberDataExtension.cs $
* $Revision: 1 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/ProfileMemberDataExtension.cs   1   2010-07-21 15:19:20-07:00   JasonO $
* 
* $Log $
**********************************************************************/
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Arena.DataLayer.Core;

namespace Arena.Custom.Cccev.FrameworkUtils.Data
{
	public static class ProfileMemberDataExtension
	{
		/// <summary>
		/// Returns all profile member activity data for the given organization and profile.
		/// </summary>
		/// <param name="organizationID">The organizationID to limit the search.</param>
		/// <param name="profileID">The ID of the Profile.</param>
		/// <returns>a DataTable of ProfileMemberActivity records</returns>
		public static DataTable GetProfileActivityDetails_DT( this ProfileMemberActivityData pmaData, int organizationID, int profileID )
		{
			DataTable table;
			ArrayList paramList = new ArrayList();
			paramList.Add( new SqlParameter( "@OrganizationID", organizationID ) );
			paramList.Add( new SqlParameter( "@ProfileID", profileID ) );

			try
			{
				table = pmaData.ExecuteDataTable( "cust_cccev_profile_sp_get_profile_member_activity_Details", paramList );
			}
			catch ( SqlException exception )
			{
				throw exception;
			}
			finally
			{
				paramList = null;
			}
			return table;
		}
	}
}
