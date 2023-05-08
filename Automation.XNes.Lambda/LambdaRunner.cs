using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            using (IWebDriver driver = new ChromeDriver("Driver_Path", chromeOptions))
            {
                LambdaStartSelect startSelect = new LambdaStartSelect(driver, new LambdaSetting(driver, new LambdaFinder(driver)));
               
                startSelect.Run();
            }

        }
    }
}
