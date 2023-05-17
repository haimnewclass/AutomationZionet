using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation.XNes.Lambda
{
    public class LambdaRunner
    {
        //the local path of the project
        const string path = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\";

        //get all the gemel files
        public static void startRun()
        {  
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory",path);
            //chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            //chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            //using (IWebDriver driver = new ChromeDriver("Driver_Path", chromeOptions))
            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
                LambdaStartSelect startSelect = new LambdaStartSelect(driver, new LambdaSetting(driver, new LambdaFinder(driver),path));
               
                startSelect.Run();
            }

        }

        //get gemel file by month and year
        public static void SelectMonthRun(LambdaDownloadOneMonth s1,string month, string year, FileSystemEventHandler afterFileCreated)
        {
            Guid guid = Guid.NewGuid();
            string newFolderPath = path + guid.ToString();

            //create new folder with the new guid name
            if (!System.IO.Directory.Exists(newFolderPath))
                System.IO.Directory.CreateDirectory(newFolderPath);

            //the defulte folder of download
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);

            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
                //in the new LambdaSetting saving the new path with the new folder
                LambdaDownloadOneMonth startSelect = new LambdaDownloadOneMonth(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath),month,year, afterFileCreated);
                s1 = startSelect;
                startSelect.Run();
            }
        }
        //get gemel files between the currect years
        public static void SelectYearsRun(string startYear, string endYear)
        {
            Guid guid = Guid.NewGuid();
           string newFolderPath = path + guid.ToString();

            if (!System.IO.Directory.Exists(newFolderPath))
                System.IO.Directory.CreateDirectory(newFolderPath);

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);

            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
                LambdaDownloadBetYears startSelect = new LambdaDownloadBetYears(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), startYear, endYear);

                startSelect.Run();
            }
        }

    }
}
