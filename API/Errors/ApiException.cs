namespace API.Errors
{
    public class ApiException : ApiResponse
    {

     
        public ApiException(int statusCode, string message = null, string details = null) : base(0,message)
        {
            Details = details;
        }
        public string Details { get; set; }
    }
}
