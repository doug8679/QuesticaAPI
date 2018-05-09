using QuesticaAPI.Models;

namespace QuesticaAPI.Responses
{
    public class TimeEntryResponse : BaseResponse
    {
        public TimeCardEntryModel TimeEntry { get; set; }
    }
}
