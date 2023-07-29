using HiDLL001;
using HiDLL002;
using Microsoft.Extensions.Hosting.WindowsServices;

namespace HiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting!!!!!!");
            Console.WriteLine($"{System.Diagnostics.Process.GetCurrentProcess().Id}");

            //Console.CancelKeyPress += (sender, eventArgs) =>
            //{
            //    // プログラムの終了をキャンセルし、クリーンアップ処理を行います
            //    eventArgs.Cancel = true;
            //    // ここにクリーンアップ処理を追加します

            //    // 終了メッセージを表示します
            //    Console.WriteLine("CancelKeyPress!!!!!!");
            //    eventArgs.Cancel = true;
            //    Console.WriteLine("But  set Cancel to true");
            //    Environment.Exit(0);
            //    //AppDomain.CurrentDomain.ProcessExit
            //};

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

            var outChar = "-";
            //処理ループ
            while (true)
            {
                Console.Write(outChar);   //これがメインの処理に該当

                //キー入力チェック。Eが入力されたらプログラム終了。
                if (Console.KeyAvailable)
                {
                    outChar = Console.ReadKey().Key.ToString();
                    if (outChar == "e")
                    {
                        return;
                    }
                }

            }
        }
    }
}