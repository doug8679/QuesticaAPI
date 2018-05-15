using System.Collections.Generic;
using QuesticaAPI.Models;

namespace QuesticaAPI.Responses
{
    public class JobCodesResponse : BaseResponse
    {
        public JobCodesResponse()
        {
            JobCodes = new List<HourTypeModel>();
        }

        public List<HourTypeModel> JobCodes { get; set; }
    }
}