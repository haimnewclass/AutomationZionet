using System;
using System.Collections.Generic;
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


        public static void startRun()
        {  
            string path = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\files";
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
        public static void SelectMonthRun(string month, string year)
        {
            string path = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\files";

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", path);

            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
                LambdaDownloadOneMonth startSelect = new LambdaDownloadOneMonth(driver, new LambdaSetting(driver, new LambdaFinder(driver),path),month,year);

                startSelect.Run();
            }
        }
        public static void SelectYearsRun(string startYear, string endYear)
        {
            string path = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\files";

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", path);

            using (IWebDriver driver = ChromeDriverBase.Get(chromeOptions).ChromeDriver)
            {
                LambdaDownloadBetYears startSelect = new LambdaDownloadBetYears(driver, new LambdaSetting(driver, new LambdaFinder(driver),path), startYear, endYear);

                startSelect.Run();
            }
        }

    }
}
