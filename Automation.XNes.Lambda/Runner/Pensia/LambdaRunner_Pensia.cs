//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Automation.XNes.Lambda.Scripts.Pensia;
//using AutomationZionet.Base.Driver;
//using AutomationZionet.Base.Scripts;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace Automation.XNes.Lambda.Runner.Pensia
//{
//    public class LambdaRunner_Pensia : LambdaScriptBase
//    {
//        //the local path of the project
//        const string path = @"C:\projects_excellence\Automation_New\dwonloadedFiles\pensia\";
//        const bool isFullDetails = false;
//        FileSystemEventHandler AfileSystemEventHandler;
//        ScriptState ret = ScriptState.NotStarted;

//        public LambdaStartSelect_Pensia script1;
//        public LambdaDownloadOneMonth_Pensia script2;
//        public LambdaDownloadBetYears_Pensia script3;

//        public LambdaRunner_Pensia(IWebDriver webDriver = null, LambdaSetting s = null, FileSystemEventHandler afileSystemEventHandler = null) 
//        {
//            afileSystemEventHandler = this.firstAfterFileCreated;
//            AfileSystemEventHandler = afileSystemEventHandler;
//            base.setting = s;
//        }

//        public override ScriptState Run()
//        {
//            //?
//            ret = ScriptState.Started;

//            return ret;
//        }


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
//                LambdaStartSelect_Pensia startRun = new LambdaStartSelect_Pensia(driver, new LambdaSetting(driver, new LambdaFinder(driver),path), isFullDetails);

//                startRun.Run();
//            }

//        }

//        //get gemel file by month and year
//        public void SelectMonthRun(string monthInHebrews, string year , bool isFullDetails)
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
//                base.setting.lambdaConfig.Params["Month"] = monthInHebrews;
//                base.setting.lambdaConfig.Params["Year"] = year;
//                base.setting.lambdaConfig["IsFullDetails"] = isFullDetails.ToString();
//                script2  = new LambdaDownloadOneMonth_Pensia(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), base.setting.lambdaConfig.Params["Month"], base.setting.lambdaConfig.Params["Year"], bool.Parse(base.setting.lambdaConfig["IsFullDetails"]), afterFileCreated);

//                script2.Run();
//            }
//        }
//        //get gemel files between the currect years
//        public void SelectYearsRun(string startYear, string endYear, bool isFullDetails)
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
//                script3 = new LambdaDownloadBetYears_Pensia(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), startYear, endYear, isFullDetails, afterFileCreated);

//                script3.Run();
//            DirectoryInfo d = new DirectoryInfo(newFolderPath);
//            d.Delete();
//            }

//        }

//        public void afterFileCreated(object sender, FileSystemEventArgs e)
//        {
//            if (script2 != null)
//                AfileSystemEventHandler(sender, e);
//                script2.CopyCompleatedFileToTargetFolder();
//            //if (script3 != null)
//            //    AfileSystemEventHandler(sender, e);
//            //    script3.oneMonth.CopyCompleatedFileToTargetFolder();
//        }

//        public void firstAfterFileCreated(object sender, FileSystemEventArgs e)
//        {
//            //?
//        }

//    }
//}
