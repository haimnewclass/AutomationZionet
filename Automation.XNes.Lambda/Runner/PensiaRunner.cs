using AutomationZionet.Base.Driver;
using AutomationZionet.Base.Runner;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.ServiceProcess;


namespace Automation.XNes.Lambda
{
    public class PensiaRunner : RunnerBase
    {
        
        public void Run()
        {
            
            ChromeOptions options = new ChromeOptions();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.Port =80;
            Console.WriteLine(service.ServiceUrl);

            //options.DebuggerAddress = "127.0.0.1:80";
            ChromeDriver cd = new ChromeDriver(service);
            

           

            ChromeOptions chromeOptions = new ChromeOptions();
           
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);

            Pensia pensia;
            using (IWebDriver driver = cd /*ChromeDriverBase.Get(chromeOptions).ChromeDriver*/)
            {
                pensia = new Pensia(driver, new LambdaSetting(driver, new LambdaFinder(driver)));

                pensia.Run();

            }
        }
        
    }
}
