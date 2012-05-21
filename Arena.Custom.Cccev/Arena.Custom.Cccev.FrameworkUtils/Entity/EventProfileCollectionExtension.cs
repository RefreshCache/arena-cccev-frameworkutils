/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: EventProfileCollectionExtension.cs $
* $Revision: 4 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/EventProfileCollectionExtension.cs   4   2011-11-10 17:12:58-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/EventProfileCollectionExtension.cs $
*  
*  Revision: 4   Date: 2011-11-11 00:12:58Z   User: JasonO 
*  Adding support for passing in multiple campus ids. 
*  
*  Revision: 3   Date: 2010-10-14 18:48:10Z   User: JasonO 
*  Updating to 2010.1 
*  
*  Revision: 2   Date: 2010-10-14 16:21:05Z   User: JasonO 
*  Updating to 2010.1 
*  
*  Revision: 1   Date: 2010-07-21 22:19:20Z   User: JasonO 
*  Refactoring generic arena-specific code into FrameworkUtils assembly. 
*  
*  Revision: 7   Date: 2010-07-21 15:43:52Z   User: JasonO 
*  Adding support for more optimized stored procedure. 
*  
*  Revision: 6   Date: 2010-07-14 22:43:15Z   User: JasonO 
*  Adding support for campuses 
*  
*  Revision: 5   Date: 2010-01-27 22:00:24Z   User: JasonO 
*  
*  Revision: 4   Date: 2009-03-19 01:20:15Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-03-17 00:10:56Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-03-10 20:41:49Z   User: JasonO 
**********************************************************************/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Arena.Custom.Cccev.DataUtils;
using Arena.Custom.Cccev.FrameworkUtils.Data;
using Arena.Event;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public static class EventProfileCollectionExtension
    {
        [Obsolete]
        public static List<EventProfileViewModel> LoadEventProfilesByTopicMonthAndParentID(this EventProfileCollection profiles, int parentProfileID, DateTime startDate, DateTime endDate, string topicAreas)
        {
            return LoadEventProfilesByTopicMonthAndParentID(profiles, parentProfileID, startDate, endDate, topicAreas, Constants.NULL_INT);
        }

        [Obsolete]
        public static List<EventProfileViewModel> LoadEventProfilesByTopicMonthAndParentID(this EventProfileCollection profiles, int parentProfileID, DateTime startDate, DateTime endDate, string topicAreas, int campusID)
        {
            List<EventProfileViewModel> events = new List<EventProfileViewModel>();
            SqlDataReader reader = new ProfileDataExtension().GetEventProfilesByTopicMonthAndParentID(parentProfileID, startDate, endDate, topicAreas, campusID);

            while (reader.Read())
            {
                profiles.Add(new EventProfile(reader, false));
                events.Add(new EventProfileViewModel((int)reader["profile_id"], (int)reader["occurrence_id"], (DateTime)reader["start"]));
            }

            reader.Close();
            return events;
        }

        [Obsolete]
        public static List<EventProfileViewModel> LoadEventsByDateRangeTopicAndCampus(this EventProfileCollection profiles, DateTime startDate, DateTime endDate, string topicAreas, int campusID)
        {
            return LoadEventsByDateRangeTopicAndCampus(profiles, startDate, endDate, topicAreas, new[] { campusID });
        }

        public static List<EventProfileViewModel> LoadEventsByDateRangeTopicAndCampus(this EventProfileCollection profiles, DateTime startDate, DateTime endDate, string topicAreas, int[] campusIDs)
        {
            List<EventProfileViewModel> events = new List<EventProfileViewModel>();
            var data = new ProfileDataExtension();
            var campuses = string.Join(",", Array.ConvertAll(campusIDs, Convert.ToString));

            using (SqlDataReader reader = data.GetEventProfilesByDateRangeTopicsAndCampus(startDate, endDate, topicAreas, campuses))
            {
                while (reader.Read())
                {
                    profiles.Add(new EventProfile(reader, false));
                    events.Add(new EventProfileViewModel((int)reader["profile_id"], (int)reader["occurrence_id"], (DateTime)reader["occurrence_start"]));
                }
            }

            return events;
        }
    }
}
