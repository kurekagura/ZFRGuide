using HiDLL001;
using HiDLL002;
using Microsoft.Extensions.Hosting.WindowsServices;

namespace HiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Windowsサービス対応
            var webAppOpts = new WebApplicationOptions
            {
                ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default,
                Args = args,
            };

            var builder = WebApplication.CreateBuilder(webAppOpts);
            builder.Host.UseWindowsService();

            var app = builder.Build();

            var obj = new HiClass001();
            app.MapGet("/", () => obj.GetHi());

            app.MapGet("/api/hidll002", (HttpContext httpContext) =>
            {
                var obj = new HiClass002();
                return obj;
            });

            app.Run();
        }
    }
}