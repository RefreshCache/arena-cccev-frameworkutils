using System;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public class EventProfileViewModel
    {
        public int ProfileID { get; set; }
        public int OccurrenceID { get; set; }
        public DateTime OccurrenceStart { get; set; }

        public EventProfileViewModel()
        {
        }

        public EventProfileViewModel(int profileID, int occurrenceID, DateTime occurrenceStart)
        {
            ProfileID = profileID;
            OccurrenceID = occurrenceID;
            OccurrenceStart = occurrenceStart;
        }
    }
}
