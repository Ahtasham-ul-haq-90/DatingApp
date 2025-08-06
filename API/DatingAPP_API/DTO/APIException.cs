namespace DatingAPP_API.DTO
{
    public class APIException
    {
        public APIException(int statuscode,string message = null, string details = null) { 
        StatusCode = statuscode;
            Message = message;
            Details = details;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
