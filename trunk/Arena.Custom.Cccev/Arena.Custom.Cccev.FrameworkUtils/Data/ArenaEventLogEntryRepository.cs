/**********************************************************************
* Description:  Manages saving event log information to Arena DB
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 3/30/2010
*
* $Workfile: ArenaEventLogEntryRepository.cs $
* $Revision: 1 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/ArenaEventLogEntryRepository.cs   1   2010-03-30 15:33:59-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/ArenaEventLogEntryRepository.cs $
*  
*  Revision: 1   Date: 2010-03-30 22:33:59Z   User: JasonO 
*  Adding server-side functionality to log application events to custom 
*  database table. 
**********************************************************************/

using System.Data.Linq;
using Arena.Custom.Cccev.FrameworkUtils.Entity;

namespace Arena.Custom.Cccev.FrameworkUtils.Data
{
    public class ArenaEventLogEntryRepository : IEventLogEntryRepository
    {
        private readonly ArenaDataContext db;

        public ArenaEventLogEntryRepository() : this(new ArenaDataContext(ArenaDataContext.CONNECTION_STRING)) { }

        public ArenaEventLogEntryRepository(DataContext dataContext)
        {
            db = dataContext as ArenaDataContext;
        }

        public void LogEntry(EventLogEntry entry)
        {
            if (entry.IsValid)
            {
                db.GetTable<EventLogEntry>().InsertOnSubmit(entry);
                db.SubmitChanges();
            }
        }
    }
}
