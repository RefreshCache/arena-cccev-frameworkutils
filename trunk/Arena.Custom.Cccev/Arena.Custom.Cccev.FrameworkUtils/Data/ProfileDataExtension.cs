/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: ProfileDataExtension.cs $
* $Revision: 2 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/ProfileDataExtension.cs   2   2011-11-10 17:12:58-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/ProfileDataExtension.cs $
*  
*  Revision: 2   Date: 2011-11-11 00:12:58Z   User: JasonO 
*  Adding support for passing in multiple campus ids. 
*  
*  Revision: 1   Date: 2010-07-21 22:19:20Z   User: JasonO 
*  Refactoring generic arena-specific code into FrameworkUtils assembly. 
*  
*  Revision: 6   Date: 2010-07-21 15:43:52Z   User: JasonO 
*  Adding support for more optimized stored procedure. 
*  
*  Revision: 5   Date: 2010-07-14 22:43:15Z   User: JasonO 
*  Adding support for campuses 
*  
*  Revision: 4   Date: 2010-01-27 22:00:24Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-03-17 00:10:53Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-03-10 20:42:05Z   User: JasonO 
**********************************************************************/

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Arena.Custom.Cccev.DataUtils;
using Arena.DataLib;

namespace Arena.Custom.Cccev.FrameworkUtils.Data
{
    public class ProfileDataExtension : SqlData
    {
        [Obsolete]
        public SqlDataReader GetEventProfilesByTopicMonthAndParentID(int parentID, DateTime startDate, DateTime endDate, string topicAreas)
        {
            return GetEventProfilesByTopicMonthAndParentID(parentID, startDate, endDate, topicAreas, Constants.NULL_INT);
        }

        public SqlDataReader GetEventProfilesByTopicMonthAndParentID(int parentID, DateTime startDate, DateTime endDate, string topicAreas, int campusID)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@ParentID", parentID));
            list.Add(new SqlParameter("@StartDate", startDate));
            list.Add(new SqlParameter("@EndDate", endDate));
            list.Add(new SqlParameter("@TopicAreas", topicAreas));
            list.Add(new SqlParameter("@CampusID", campusID));

            try
            {
                return ExecuteSqlDataReader("cust_cccev_webu_sp_get_eventsByMonthTopicAndParentID", list);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        [Obsolete]
        public SqlDataReader GetEventProfilesByDateRangeTopicsAndCampus(DateTime startDate, DateTime endDate, string topicAreas, int campusID)
        {
            return GetEventProfilesByDateRangeTopicsAndCampus(startDate, endDate, topicAreas, campusID.ToString());
        }

        public SqlDataReader GetEventProfilesByDateRangeTopicsAndCampus(DateTime startDate, DateTime endDate, string topicAreas, string campusIDs)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@StartDate", startDate));
            list.Add(new SqlParameter("@EndDate", endDate));
            list.Add(new SqlParameter("@TopicAreas", topicAreas));
            list.Add(new SqlParameter("@CampusIDs", campusIDs));

            try
            {
                return ExecuteSqlDataReader("cust_cccev_webu_sp_get_eventsByDateRangeTopicAndCampus", list);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns a sub set of profile data for the given organizationID, name and/or description.  If
        /// the profileType is 'personal' then the only profiles with owner matching
        /// the given personID are returned.
        /// </summary>
        /// <param name="organizationID">The organizationID to limit the search.</param>
        /// <param name="profileTypeID">The ID of the ProfileType enum.</param>
        /// <param name="personID">The person performing the search.</param>
        /// <param name="name">A partial text string; used to search the profile name field.</param>
        /// <param name="description">A partial text string; used to search the profile description and notes field.</param>
        /// <param name="includeInactive">Boolean indicating whether to include inactive records in the search.</param>
        /// <returns></returns>
        public DataTable GetProfileByFilter_DT(int organizationID, int profileTypeID, int personID, string name, string description, bool includeInactive)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@OrganizationId", organizationID));
            lst.Add(new SqlParameter("@ProfileType", profileTypeID));
            lst.Add(new SqlParameter("@PersonID", personID));
            lst.Add(new SqlParameter("@Name", name));
            lst.Add(new SqlParameter("@Description", description));
            lst.Add(new SqlParameter("@IncludeInactive", includeInactive));

            try
            {
                return this.ExecuteDataTable("cust_cccev_profile_sp_get_profileByFilter", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        /// <summary>
        /// Get a datatable of all people for a given organization and profile.
        /// </summary>
        /// <param name="organizationID">The organizationID to limit the search.</param>
        /// <param name="profileID">The ID of the profile to find subscribers for.</param>
        /// <returns></returns>
        public DataTable GetProfileSubscribers_DT(int organizationID, int profileID)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@OrganizationId", organizationID));
            lst.Add(new SqlParameter("@ProfileID", profileID));

            try
            {
                return this.ExecuteDataTable("cust_cccev_profile_sp_get_subscribers", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }
    }
}
