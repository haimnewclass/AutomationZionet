using Automation.XNes.Lambda.Runner.Gemel;
using Automation.XNes.Lambda.Runner.Pensia;
using AutomationZionet.Base.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.XNes.Lambda.Runner.Bituach
{
    public class LambdaRunAll_Bituach
    {
        public LambdaFullDownload_Bituach_All l1;
        public void Run(string pathDest, bool isFullDetails)
        {
            string path = pathDest;
            Guid guid = Guid.NewGuid();
            string newFolderPath = path + guid.ToString();

            if (!System.IO.Directory.Exists(newFolderPath))
                System.IO.Directory.CreateDirectory(newFolderPath);

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);


            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
                l1 = new LambdaFullDownload_Bituach_All(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), isFullDetails,newFolderPath);

                l1.Run();

            }
        }

        public void RunOneMonth(int month, int year, string pathDest, bool isFullDetails)
        {
            string path = pathDest;
            Guid guid = Guid.NewGuid();
            string newFolderPath = path + guid.ToString();

            if (!System.IO.Directory.Exists(newFolderPath))
                System.IO.Directory.CreateDirectory(newFolderPath);

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);


            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
                l1 = new LambdaFullDownload_Bituach_All(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), isFullDetails, newFolderPath);

                l1.RunOneMonth(month, year);

            }
        }

        public void RunChevrot(string pathDest, bool isFullDetails)
        {
            string path = pathDest;
            Guid guid = Guid.NewGuid();
            string newFolderPath = path + guid.ToString();

            if (!System.IO.Directory.Exists(newFolderPath))
                System.IO.Directory.CreateDirectory(newFolderPath);

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", newFolderPath);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);


            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
                l1 = new LambdaFullDownload_Bituach_All(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath), isFullDetails, newFolderPath);

                l1.RunChevrot();

            }
        }
    }
}
