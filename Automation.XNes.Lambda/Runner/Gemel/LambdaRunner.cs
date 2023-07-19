//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Automation.XNes.Lambda.Scripts.Gemel;
//using AutomationZionet.Base.Driver;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace Automation.XNes.Lambda.Runner.Gemel
//{
//    public class LambdaRunner
//    {
//        //the local path of the project
//        const string path = @"C:\projects_excellence\Automation_New\dwonloadedFiles\gemel";
//        public LambdaStartSelect script1;
//        public LambdaDownloadOneMonth script2;
//        public LambdaDownloadBetYears script3;


//        //get all the gemel files
//        public static void startRun()
//        {  
//            ChromeOptions chromeOptions = new ChromeOptions();
//            chromeOptions.AddUserProfilePreference("download.default_directory",path);
//            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
//            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
//            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
//            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
//            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);

//            //using (IWebDriver driver = new ChromeDriver("Driver_Path", chromeOptions))
//            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
//            {
//                LambdaStartSelect startRun = new LambdaStartSelect(driver, new LambdaSetting(driver, new LambdaFinder(driver),path));

//                startRun.Run();
//            }

//        }

//        //get gemel file by month and year
//        public void SelectMonthRun(string month, string year, bool isFullDetail)
//        {
//            Guid guid = Guid.NewGuid();
//            string newFolderPath = path + guid.ToString();

//            //create new folder with the new guid name
//            if (!System.IO.Directory.Exists(newFolderPath))
//                System.IO.Directory.CreateDirectory(newFolderPath);

//            //the defulte folder of download
//            ChromeOptions chromeOptions = new ChromeOptions();
//            chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);
//            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
//            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
//            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
//            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
//            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);

//            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
//            {
//                //in the new LambdaSetting saving the new path with the new folder
//                script2  = new LambdaDownloadOneMonth(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath),month,year,isFullDetail, afterFileCreated);

//                script2.Run();
//            }
//        }
//        //get gemel files between the currect years
//        public void SelectYearsRun(string startYear, string endYear, bool isFullDetail)
//        {
//            Guid guid = Guid.NewGuid();
//            string newFolderPath = path + guid.ToString();

//            //create new folder with the new guid name
//            if (!System.IO.Directory.Exists(newFolderPath))
//                System.IO.Directory.CreateDirectory(newFolderPath);

//            ChromeOptions chromeOptions = new ChromeOptions();
//            chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);
//            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
//            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
//            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
//            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
//            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);

//            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
//            {
//                script3 = new LambdaDownloadBetYears(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), startYear, endYear, isFullDetail, afterFileCreated);

//                script3.Run();
//            DirectoryInfo d = new DirectoryInfo(newFolderPath);
//            d.Delete();
//            }

//        }
//        public void afterFileCreated(object sender, FileSystemEventArgs e)
//        {
//            if (script2 != null)
//                script2.CopyCompleatedFileToTargetFolder();
//            if (script3 != null)
//                script3.oneMonth.CopyCompleatedFileToTargetFolder();
//        }
//    }
//}
