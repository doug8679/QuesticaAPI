using System;
using Questica.Model;

namespace QuesticaAPI.Responses
{
    public abstract class BaseResponse
    {
        public Guid response_guid { get; set; }
        public DateTime respnse_timestamp { get; set; }
        public bool success { get; set; }
        public string error { get; set; }

        protected BaseResponse()
        {
            response_guid = Guid.NewGuid();
            respnse_timestamp = DateTime.UtcNow;
            success = true;
            error = string.Empty;
        }
    }
}
