/**********************************************************************
* Description:  TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: TBD
*
* $Workfile: EventProfileController.cs $
* $Revision: 10 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Application/EventProfileController.cs   10   2011-11-10 17:12:58-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Application/EventProfileController.cs $
*  
*  Revision: 10   Date: 2011-11-11 00:12:58Z   User: JasonO 
*  Adding support for passing in multiple campus ids. 
*  
*  Revision: 9   Date: 2011-04-05 22:46:07Z   User: JasonO 
*  Functionality updates for Glendale campus rollout and usability 
*  improvements. 
*  
*  Revision: 8   Date: 2010-10-14 16:21:05Z   User: JasonO 
*  Updating to 2010.1 
*  
*  Revision: 7   Date: 2010-08-17 00:25:55Z   User: JasonO 
*  Allowing more than one event profile with the same ID to be added to the 
*  list when filtering by keyword. 
*  
*  Revision: 6   Date: 2010-08-03 23:56:53Z   User: JasonO 
*  Adding ability to define topic areas on calendar pages. 
*  
*  Revision: 5   Date: 2010-07-30 00:21:44Z   User: JasonO 
*  
*  Revision: 4   Date: 2010-07-26 21:04:25Z   User: JasonO 
*  Adding Occurrence ID's to EventProfile's ForeignKey field to build dynamic 
*  URL to event details page. 
*  
*  Revision: 3   Date: 2010-07-21 23:25:00Z   User: JasonO 
*  Refactoring to make code a little cleaner 
*  
*  Revision: 2   Date: 2010-07-21 22:23:22Z   User: JasonO 
*  Refactoring web service code into controller class. 
**********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Arena.Custom.Cccev.DataUtils;
using Arena.Custom.Cccev.FrameworkUtils.Entity;
using Arena.Event;

namespace Arena.Custom.Cccev.FrameworkUtils.Application
{
    public class EventProfileController : CentralControllerBase
    {
        /// <summary>
        /// Encapsulated logic for fetching event data.
        /// </summary>
        /// <param name="start">Start of date range to search</param>
        /// <param name="end">End of date range to search</param>
        /// <param name="keywords">Keywords that may apply</param>
        /// <param name="topicIDs">Topic IDs to search</param>
        /// <param name="campusID">ID of campus to search</param>
        /// <returns>A list of EventProfiles sorted by start date, filtered by date range, keywords and campus</returns>
        [Obsolete]
        public IEnumerable<EventProfile> GetEventsByDateRangeAndCampus(DateTime start, DateTime end, string keywords, string topicIDs, int campusID)
        {
            return GetEventsByDateRangeAndCampus(start, end, keywords, topicIDs, new[] {campusID});
        }
        
        public IEnumerable<EventProfile> GetEventsByDateRangeAndCampus(DateTime start, DateTime end, string keywords, string topicIDs, int[] campusIDs)
        {
            var events = GetCalendarEvents(start, end, topicIDs, campusIDs);

            if (keywords.Trim() == Constants.NULL_STRING)
            {
                return (from e in events
                        orderby e.Start ascending
                        select e).ToList();
            }

            var filteredEvents = FilterEventsByKeyword(events, keywords);
            return (from e in filteredEvents.Distinct()
                    orderby e.Start ascending
                    select e).ToList();
        }

        private static IEnumerable<EventProfile> GetCalendarEvents(DateTime start, DateTime end, string topicIDs, int[] campusIDs) 
        {
            var events = new EventProfileCollection();
            var occurrenceEvents = events.LoadEventsByDateRangeTopicAndCampus(start, end, topicIDs, campusIDs);
            var calendarEvents = new List<EventProfile>();
            var eventProfiles = events;

            foreach (var ev in eventProfiles)
            {
                var theEvent = ev;

                if (calendarEvents.Any(e => e.ProfileID == theEvent.ProfileID))
                {
                    continue;
                }

                // Needed to differentiate when to use the event profile's start/end date and when to use the start/end dates from the event's occurrences
                // based on needs defined by Central Communications Team
                if (theEvent.Start.Date == theEvent.End.Date)
                {
                    var theEventsOccurrences = occurrenceEvents.Where(oe => oe.ProfileID == theEvent.ProfileID);
                    calendarEvents.AddRange(theEventsOccurrences.Select(
                        occurrence => new EventProfile
                        {
                            ProfileID = theEvent.ProfileID,
                            Name = theEvent.Name,
                            Summary = theEvent.Summary,
                            Start = occurrence.OccurrenceStart,
                            End = occurrence.OccurrenceStart, // Occurrence end dates not supported
                            ExternalLink = theEvent.ExternalLink,
                            Image = theEvent.Image,
                            ForiegnKey = occurrence.OccurrenceID.ToString(),
                            Campus = theEvent.Campus
                        }));
                }
                else
                {
                    var theEventsOccurrence = occurrenceEvents
                        .Where(e => e.ProfileID == theEvent.ProfileID).OrderBy(e => e.OccurrenceStart);
                    theEvent.ForiegnKey = theEventsOccurrence.First().OccurrenceID.ToString();
                    calendarEvents.Add(theEvent);
                }
            }

            return calendarEvents;
        }

        private static IEnumerable<EventProfile> FilterEventsByKeyword(IEnumerable<EventProfile> events, string keywords)
        {
            var filteredEvents = new List<EventProfile>();
            var keywordList = keywords.Split(new[] { ' ', ',', ';' });

            foreach (string k in keywordList)
            {
                string keyword = k;
                filteredEvents.AddRange(events.Where((e => e.Details.ToLower().Contains(keyword.ToLower()) ||
                                                           e.Name.ToLower().Contains(keyword.ToLower())))); //&&
                                                           //!filteredEvents.Any(fe => fe.ProfileID == e.ProfileID))));
            }

            return filteredEvents;
        }
    }
}
