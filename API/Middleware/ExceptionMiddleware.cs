namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _delegate;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate delegate, ILogger<ExceptionMiddleware> logger)
        {
            
        }
    }
}
