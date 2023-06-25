using HiDLL001;

namespace HiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var obj = new HiClass001();
            app.MapGet("/", () => obj.GetHi());

            app.Run();
        }
    }
}