using System;
using WixSharp;

namespace SetupHiSrv
{
    internal class Program
    {
        static void Main()
        {

            var project = new Project("HiServer",
                new Dir(@"%ProgramFiles%\90k\HiServer",
                new File(@"..\..\publish\HiSrv\Debug\net7.0\HiSrv.exe"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\HiSrv.dll"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\HiSrv.pdb"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\HiDLL001.dll"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\HiDLL001.pdb"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\HiDLL002.dll"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\HiDLL002.pdb"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\Microsoft.Extensions.Configuration.Binder.dll"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\Microsoft.Extensions.Hosting.dll"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\Microsoft.Extensions.Hosting.WindowsServices.dll"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\Microsoft.Extensions.Logging.Abstractions.dll"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\Microsoft.Extensions.Options.dll"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\System.ServiceProcess.ServiceController.dll"),
                new File(@"..\..\publish\HiSrv\Debug\net7.0\HiSrv.runtimeconfig.json")
                //new Dir("runtimes",
                //    new Dir("win",
                //        new Dir("lib",
                //            new Dir("net7.0",
                //                new File(@"..\..\publish\HiSrv\Debug\net7.0\runtimes\win\lib\net7.0\System.ServiceProcess.ServiceController.dll")))))
                ));


            project.ProductId = new Guid("{995423E5-EDE5-4EF8-86AD-83D9F64242BB}");
            project.GUID = new Guid("{8B51BE59-6A3B-48C2-BCED-372936B1C1DB}");
            //project.Platform = Platform.x64;
            //project.UpgradeCode = new Guid("{83D0D771-CF71-417B-B980-94BB39AF1697}");

            //project.SourceBaseDir = "<input dir path>";
            //project.OutDir = "<output dir path>";

            project.BuildMsi();
        }
    }
}