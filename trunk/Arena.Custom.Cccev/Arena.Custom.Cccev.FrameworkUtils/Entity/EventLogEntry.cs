/**********************************************************************
* Description:  Entity object to map an event within the Arena system to the database
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 3/30/2010
*
* $Workfile: EventLogEntry.cs $
* $Revision: 3 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/EventLogEntry.cs   3   2010-03-31 09:33:21-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/EventLogEntry.cs $
*  
*  Revision: 3   Date: 2010-03-31 16:33:21Z   User: JasonO 
*  Adding object type field. 
*  
*  Revision: 2   Date: 2010-03-31 15:43:25Z   User: JasonO 
*  Adding object name field. 
*  
*  Revision: 1   Date: 2010-03-30 22:33:59Z   User: JasonO 
*  Adding server-side functionality to log application events to custom 
*  database table. 
**********************************************************************/

using System;
using System.Data.Linq.Mapping;
using Arena.Custom.Cccev.DataUtils;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    [Table(Name = "cust_cccev_core_event_log")]
    public class EventLogEntry : CentralObjectBase
    {
        [Column(Name = "event_log_id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int EventLogEntryID { get; set; }

        [Column(Name = "object_id")]
        public int ObjectID { get; set; }

        [Column(Name = "object_name")]
        public string ObjectName { get; set; }

        [Column(Name = "object_type")]
        public string ObjectType { get; set; }

        [Column(Name = "user_id")]
        public string UserID { get; set; }

        [Column(Name = "event_date")]
        public DateTime EventDate { get; set; }

        [Column(Name = "action_type")]
        public string ActionType { get; set; }

        public override bool IsValid
        {
            get { return Validate(); }
        }

        public EventLogEntry()
        {
        }

        public EventLogEntry(int objectID, string objectName, string objectType, string userID, DateTime eventDate, string actionType)
        {
            ObjectID = objectID;
            ObjectName = objectName;
            ObjectType = objectType;
            UserID = userID;
            EventDate = eventDate;
            ActionType = actionType;
        }

        private bool Validate()
        {
            return (ObjectID > Constants.ZERO && 
                    !string.IsNullOrEmpty(ObjectName) &&
                    !string.IsNullOrEmpty(ObjectType) &&
                    !string.IsNullOrEmpty(UserID) && 
                    EventDate > Constants.NULL_DATE &&
                    !string.IsNullOrEmpty(ActionType));
        }
    }
}
