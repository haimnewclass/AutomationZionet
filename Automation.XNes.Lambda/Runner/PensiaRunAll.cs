using Automation.XNes.Lambda.Runner.Gemel;
using AutomationZionet.Base.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.XNes.Lambda
{
    public class PensiaRunAll
    {
        public LambdaFullDownload_Gemel_All l1;
        public void Run(string pathDest)
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
                l1 = new LambdaFullDownload_Gemel_All(driver, new LambdaSetting(driver, new LambdaFinder(driver), newFolderPath),newFolderPath);

                l1.Run();

            }
        }
    }
}
