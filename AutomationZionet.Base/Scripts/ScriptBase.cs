using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Base.Scripts
{
    public enum ScriptState {NotStarted,Started,Warning,Success,Fail }
    public abstract class ScriptBase
    {
        public ScriptBase(IWebDriver d) {
            State= ScriptState.NotStarted;
            driver= d;
        }
        public ScriptState State { get; set; }
        public ConfigParams URLs = new ConfigParams();
        public ConfigParams Config = new ConfigParams();
        protected IWebDriver driver { get; }

        public void GoToUrl(string url,bool FromURLConfig = true)
        {
            //TODO: add to log
            if(FromURLConfig)
                driver.Navigate().GoToUrl(URLs[url]);
            else
                driver.Navigate().GoToUrl(url);
            
            WaitForLoad();
        }

        public abstract ScriptState Run();
        public virtual void ImplicitWait()
        {
            //driver.Manage().Timeouts().ImplicitWait = true;
        }
        public void WaitForLoad(int timeoutSec = 10000)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
