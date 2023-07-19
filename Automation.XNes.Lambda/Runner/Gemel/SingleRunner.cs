//using AutomationZionet.Base.Driver;
//using AutomationZionet.Base.Runner;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ServiceProcess;
//using System.ServiceProcess;
//using Automation.XNes.Lambda.Scripts.Gemel;

//namespace Automation.XNes.Lambda.Runner.Gemel
//{
//    public class SingleRunner : RunnerBase
//    {
//        public LambdaDownloadOneMonth l1;
//        public void Run( string pathDest,string month,string year, bool isFullDetail)
//        {

//            ChromeOptions options = new ChromeOptions();
//            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
//            service.Port =80;
//            Console.WriteLine(service.ServiceUrl);

//            //options.DebuggerAddress = "127.0.0.1:80";
//            ChromeDriver cd = new ChromeDriver(service);
            

//            string path = pathDest;
//            Guid guid = Guid.NewGuid();
//            string newFolderPath = path + guid.ToString();

//            if (!System.IO.Directory.Exists(newFolderPath))
//                System.IO.Directory.CreateDirectory(newFolderPath);

//            ChromeOptions chromeOptions = new ChromeOptions();
//            chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);
//            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
//            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
//            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
//            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
//            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);


//            using (IWebDriver driver = cd /*ChromeDriverBase.Get(chromeOptions).ChromeDriver*/)
//            {
//                l1 = new LambdaDownloadOneMonth(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), month, year, isFullDetail, afterFileCreated);

//                l1.Run();

//            }
//        }
//        public void afterFileCreated(object sender, FileSystemEventArgs e)
//        {
//            l1.CopyCompleatedFileToTargetFolder();
//        }
//    }
//}
