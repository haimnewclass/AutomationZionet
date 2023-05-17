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
    public class LambdaDownloadOneMonth : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public string newFolderPath { get; set; }
        protected FileSystemWatcher watcher;

        FileSystemEventHandler fileSystemEventHandler;

        public LambdaDownloadOneMonth(IWebDriver d, LambdaSetting s,string month,string year, FileSystemEventHandler afileSystemEventHandler) : base(d, s)
        {
            fileSystemEventHandler = afileSystemEventHandler;
            setting = s;
            driver = d;
            this.year = year;
            this.month = month;
            this.newFolderPath = base.setting.lambdaConfig.Params["DestFolder"];
        }

        public override ScriptState Run()
        {
            var before = Directory.GetFiles(newFolderPath);
            base.State = ScriptState.Started;

            //event
            watcher = new FileSystemWatcher(base.setting.lambdaConfig.Params["DestFolder"]);
            watcher.NotifyFilter = NotifyFilters.Attributes
                                | NotifyFilters.CreationTime
                                | NotifyFilters.DirectoryName
                                | NotifyFilters.FileName
                                | NotifyFilters.LastAccess
                                | NotifyFilters.LastWrite
                                | NotifyFilters.Security
                                | NotifyFilters.Size;

            watcher.Changed += fileSystemEventHandler;
            watcher.Filter = "*.xml";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

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
          
            return base.State;
        }

        //after compleated to create th new file 
        public void CopyCompleatedFileToTargetFolder()
        {
            watcher.Changed -= fileSystemEventHandler;
            DirectoryInfo d = new DirectoryInfo(base.setting.lambdaConfig.Params["DestFolder"]);
            FileInfo[] infos = d.GetFiles();
            infos[0].MoveTo(this.Config["New_Driver_Path"] + "\\" +"GEMEL "+ year.ToString() + "_" + month.ToString() + ".xml");
            //infos[0].Delete();
            //delete folder
              d.Delete();
            infos = null;
        }

    }


}
