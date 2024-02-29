using TradeAPI.Middlewares;

namespace TradeAPI
{
    public static class Startup
    {
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {

            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
