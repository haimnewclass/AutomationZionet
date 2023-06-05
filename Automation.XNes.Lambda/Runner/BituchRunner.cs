using Automation.XNes.Lambda.Scripts;
using AutomationZionet.Base.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.XNes.Lambda.Runner
{
    public class BituchRunner
    {
        const string path = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\DownloadFiles";
        public lambdaBituchOneMonth oneMonth;

        public void SelectMonthRun(string month, string year)
        {
            Guid guid = Guid.NewGuid();
            string newFolderPath = path + guid.ToString();

            //create new folder with the new guid name
            if (!System.IO.Directory.Exists(newFolderPath))
                System.IO.Directory.CreateDirectory(newFolderPath);

            //the defulte folder of download
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);

            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
                //in the new LambdaSetting saving the new path with the new folder
                oneMonth = new lambdaBituchOneMonth(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), month, year, afterFileCreated);
               
                oneMonth.Run();
            }
        }
        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            if (oneMonth != null)
                oneMonth.CopyCompleatedFileToTargetFolder();

        }
    }
}
