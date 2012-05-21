using Arena.Custom.Cccev.FrameworkUtils.Entity;

namespace Arena.Custom.Cccev.FrameworkUtils.Data
{
    public interface IEventLogEntryRepository
    {
        void LogEntry(EventLogEntry entry);
    }
}
