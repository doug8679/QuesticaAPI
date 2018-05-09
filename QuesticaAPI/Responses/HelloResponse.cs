namespace QuesticaAPI.Responses
{
    public class HelloResponse : BaseResponse
    {
        public string response_message { get; set; }

        public HelloResponse() : base()
        {
            response_message = "Hello from Questica API.";
        }
    }
}