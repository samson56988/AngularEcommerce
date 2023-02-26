namespace AngularEcommerce.Errors
{
    public class ApiResponse
    {

        public ApiResponse(int statusCode , string message = null) 
        { 
          StatusCode = statusCode;
          Message = message ?? GetDefaultMessageForStatusCode(statusCode);  
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int status)
        {
            return StatusCode switch
            {
                400 => "A bad request , you have made",
                401 => "Authorized , you are not",
                404 => "Resource Found, it was not",
                500 => "Error are path to dark side",
                _ => null
            };
        }
    }
}
