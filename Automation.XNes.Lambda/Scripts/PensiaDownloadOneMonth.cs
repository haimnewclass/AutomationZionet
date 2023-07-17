using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using AutomationZionet.Base.WebElements;
using OpenQA.Selenium.Chrome;

namespace Automation.XNes.Lambda
{
    public class PensiaDownloadOneMonth : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public bool isFullDetails { get; set; }



        public PensiaDownloadOneMonth(IWebDriver d, LambdaSetting s, string month, string year, bool isFullDetails) : base(d, s)
        {
            setting = s;
            driver = d;
            this.year = year;
            this.month = month;
            this.isFullDetails = isFullDetails;
        }

        public override ScriptState Run()
        {
          
            base.State = ScriptState.Started;

            GoToUrl("basePensiaUrl");
            ElementButton.Get(setting, "pensia-Btn-knisa").Click();
            Thread.Sleep(3000);
            ElementButton.Get(setting, "pensia-Btn-options").Click();
            ElementButton.Get(setting, "pensia-Btn-All-New-Option").Click();
            driver.FindElement(By.XPath(@"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[1]/div[1]/span[1]/span/input")).Clear();
            ElementInput.Get(setting, "pensia-Input-Select-Start-Date").SendKeys(month + " "+ year);
            driver.FindElement(By.XPath(@"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[1]/div[2]/span[1]/span/input")).Clear();
            ElementInput.Get(setting, "pensia-Input-Select-End-Date").SendKeys(month + " " + year);
            ElementButton.Get(setting, "pensia-Btn-Download-Xml").Click();
            if (isFullDetails)
            {
                ElementButton.Get(setting, "pensia-Radio-Full-Details").Click();
            }
            ElementButton.Get(setting, "pensia-Radio-General-Details").Click();
            ElementButton.Get(setting, "pensia-Btn-Dounload-Xml-File").Click();
            Thread.Sleep(3000);


            return base.State;

        }





    }


}
