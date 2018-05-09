using System;
using Questica.Model;
using QuesticaAPI.Models;

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

    public class HelloResponse : BaseResponse
    {
        public string response_message { get; set; }

        public HelloResponse() : base()
        {
            response_message = "Hello from Questica API.";
        }
    }

    public class EmployeeResponse : BaseResponse
    {
        public EmployeeModel Employee { get; set; }
    }

    public class EmptyResponse : BaseResponse
    {
    }
}
