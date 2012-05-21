/**********************************************************************
* Description:  Controller object to abstract interface with Arena Campus object
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 5/5/2010
*
* $Workfile: CampusController.cs $
* $Revision: 4 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Application/CampusController.cs   4   2010-10-14 09:21:05-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Application/CampusController.cs $
*  
*  Revision: 4   Date: 2010-10-14 16:21:05Z   User: JasonO 
*  Updating to 2010.1 
*  
*  Revision: 3   Date: 2010-05-19 17:53:47Z   User: JasonO 
*  Updating source control to latest versions 
*  
*  Revision: 2   Date: 2010-05-13 18:37:24Z   User: JasonO 
*  Adding check to see if new campus matches person's current campus on the 
*  server. 
*  
*  Revision: 1   Date: 2010-05-05 23:56:29Z   User: JasonO 
*  Abstracting campus specific functionality from Campus Service 
**********************************************************************/

using System.Collections.Generic;
using System.Linq;
using Arena.Core;
using Arena.Custom.Cccev.FrameworkUtils.FrameworkConstants;
using Arena.Organization;

namespace Arena.Custom.Cccev.FrameworkUtils.Application
{
    public class CampusController : CentralControllerBase
    {
        public Campus GetDefaultCampus()
        {
            var context = ArenaContext.Current;
            return context.User.Identity.IsAuthenticated ? context.Person.Campus : context.Organization.Campuses.OfType<Campus>().FirstOrDefault();
        }

        public IEnumerable<Campus> GetCampusList()
        {
            return (from c in ArenaContext.Current.Organization.Campuses.OfType<Campus>()
                    select c).ToList();
        }

        public Campus ChangeCurrentPersonCampus(int campusID)
        {
            var context = ArenaContext.Current;
            var org = context.Organization;
            var person = context.Person;

            if (person.Campus == null || person.Campus.CampusId != campusID)
            {
                var campus = org.Campuses.OfType<Campus>().Where(c => c.CampusId == campusID).FirstOrDefault();
                person.Campus = campus;
                person.Save(org.OrganizationID, context.User.Identity.Name, false);
                return campus;
            }

            return person.Campus;
        }

        public Lookup GetCampusExtendedAttributes(int campusID)
        {
            var campusType = new LookupType(SystemGuids.CAMPUS_LOOKUP_TYPE);
            return campusType.Values.OfType<Lookup>().Where(l => int.Parse(l.Qualifier) == campusID).FirstOrDefault();
        }
    }
}
