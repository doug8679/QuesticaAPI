using QuesticaAPI.Models;

namespace QuesticaAPI.Responses
{
    public class EmployeeResponse : BaseResponse
    {
        public EmployeeModel Employee { get; set; }
    }
}