using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutomationZionet.Base.WebElements;
using AutomationZionet.Base;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Automation.XNes.Lambda
{
    public class LambdaStartSelect:LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public int year_from;
        public int year_to;
        public string month;
        public string newFolderPath { get; set; }
        public LambdaStartSelect(IWebDriver d, LambdaSetting s) : base(d, s)
        {
            setting = s;
            driver = d;
            year_from = int.Parse(this.Config["Year_from"]);
            year_to = int.Parse(this.Config["Year_to"]);
            Guid guid = Guid.NewGuid();
            newFolderPath = base.Config.Params["DestFolder"] + guid.ToString();
            if (!System.IO.Directory.Exists(newFolderPath))
            System.IO.Directory.CreateDirectory(newFolderPath); 
           
        }
        public override ScriptState Run()
        {
            var before= Directory.GetFiles(this.Config["Driver_Path"]);
            base.State = ScriptState.Started;

            GoToUrl("baseUrl");
            ElementButton.Get(setting, "Btn-knisa").Click();
            ElementButton.Get(setting, "Select-All-Kupot").Click();
            ElementButton.Get(setting, "Btn-Add").Click();
            ElementButton.Get(setting, "Btn-Download-Xml").Click();
            for (int j =year_from; j < year_to; j++)
            {
                for (int i = 1; i < 13; i++)
                {
            SelectElement select1= new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 2)).Until(driver => driver.FindElement(By.XPath("//*[@id='selXMLHodashimMe']"))));
                    if (i < 10)
                         month = "0" + i.ToString();
                    else
                         month = i.ToString();

                    select1.SelectByValue(month);

            SelectElement select2 = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 2)).Until(driver => driver.FindElement(By.XPath("//*[@id='selXMLShanimMe']"))));
            select2.SelectByValue(j.ToString());

            SelectElement select3 = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 2)).Until(driver => driver.FindElement(By.XPath("//*[@id='selXMLHodashimAd']"))));
            select3.SelectByValue(month);

            SelectElement select4 = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 2)).Until(driver => driver.FindElement(By.XPath("//*[@id='selXMLShanimAd']"))));
            select4.SelectByValue( j.ToString());
                ElementButton.Get(setting, "Radio-PerutMale").Click();
                ElementButton.Get(setting, "Btn-Confirm").Click();
                 Thread.Sleep(1000);

                    DirectoryInfo d = new DirectoryInfo(this.Config["Driver_Path"]);
                    FileInfo[] infos = d.GetFiles();
                    infos[0].MoveTo(this.Config["New_Driver_Path"] +"\\"+i.ToString()+"."+ year_to + ".xml");
                    d.Delete();

                }
            }
            
            return base.State;
        }

    }
}
