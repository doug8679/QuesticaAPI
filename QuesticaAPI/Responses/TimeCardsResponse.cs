using System.Collections.Generic;
using QuesticaAPI.Models;

namespace QuesticaAPI.Responses
{
    public class TimeCardsResponse : BaseResponse
    {
        public List<TimeCardModel> TimeCards { get; set; }
    }
}