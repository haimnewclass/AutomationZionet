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
namespace Automation.XNes.Lambda
{
    public class LambdaDownloadOneMonth : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public string newFolderPath { get; set; }



        public LambdaDownloadOneMonth(IWebDriver d, LambdaSetting s,string month,string year) : base(d, s)
        {
            setting = s;
            driver = d;
            this.year = year;
            this.month = month;
            Guid guid = Guid.NewGuid();
            Console.WriteLine(guid.ToString());
            newFolderPath = base.setting.lambdaConfig.Params["DestFolder"].ToString() + guid.ToString();
            if (!System.IO.Directory.Exists(newFolderPath))
                System.IO.Directory.CreateDirectory(newFolderPath);
        }

        public override ScriptState Run()
        {
            var before = Directory.GetFiles(this.Config["Driver_Path"]);
            base.State = ScriptState.Started;

            GoToUrl("baseUrl");
            ElementButton.Get(setting, "Btn-knisa").Click();
            ElementButton.Get(setting, "Select-All-Kupot").Click();
            ElementButton.Get(setting, "Btn-Add").Click();
            ElementButton.Get(setting, "Btn-Download-Xml").Click();

            SelectElement select1 = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 2)).Until(driver => driver.FindElement(By.XPath("//*[@id='selXMLHodashimMe']"))));
            select1.SelectByValue(month);

            SelectElement select2 = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 2)).Until(driver => driver.FindElement(By.XPath("//*[@id='selXMLShanimMe']"))));
            select2.SelectByValue(year.ToString());

            SelectElement select3 = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 2)).Until(driver => driver.FindElement(By.XPath("//*[@id='selXMLHodashimAd']"))));
            select3.SelectByValue(month);

            SelectElement select4 = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 2)).Until(driver => driver.FindElement(By.XPath("//*[@id='selXMLShanimAd']"))));
            select4.SelectByValue(year.ToString());

            ElementButton.Get(setting, "Radio-PerutMale").Click();
            ElementButton.Get(setting, "Btn-Confirm").Click();
            Thread.Sleep(1000);

            DirectoryInfo d = new DirectoryInfo(this.Config["Driver_Path"]);
            FileInfo[] infos = d.GetFiles();
            infos[0].MoveTo(this.Config["New_Driver_Path"] + "\\" + month.ToString() + "." + year.ToString() + ".xml");
            //infos[0].Delete();
            infos =null;
            return base.State;
        }
    }
}
