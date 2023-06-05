using AutomationZionet.Base.Scripts;
using AutomationZionet.Base.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.XNes.Lambda.Scripts
{
    public class lambdaBituchOneMonth : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public string newFolderPath { get; set; }
        protected FileSystemWatcher watcher;

        FileSystemEventHandler fileSystemEventHandler;

        public lambdaBituchOneMonth(IWebDriver d, LambdaSetting s, string month, string year, FileSystemEventHandler afileSystemEventHandler) : base(d, s)
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

            GoToUrl("baseBituchUrl");
            ElementButton.Get(setting, "bituach-Btn-knisa").Click();
            ElementButton.Get(setting, "bituach-Select-All-Kupot").Click();
            Thread.Sleep(1000);
            ElementButton.Get(setting, "bituach-Btn-Add").Click();
            ElementButton.Get(setting, "bituach-Btn-Download-Xml").Click();
            GoToUrl("newPage");
            string s= driver.Url.ToString();
            Console.WriteLine(s);
            Thread.Sleep(1000);
            ElementSelect.Get(setting, "bituach-Select-From-Month").SelectByValue(month);
            ElementSelect.Get(setting, "bituach-Select-From-Year").SelectByValue(year);
            ElementSelect.Get(setting, "bituach-Select-Until-Month").SelectByValue(month);
            ElementSelect.Get(setting, "bituach-Select-Until-Year").SelectByValue(year);

            ElementButton.Get(setting, "bituach-Radio-PerutMale").Click();
            ElementButton.Get(setting, "bituach-Btn-Confirm").Click();
            return base.State;
        }

        //after compleated to create th new file 
        public void CopyCompleatedFileToTargetFolder()
        {
            watcher.Changed -= fileSystemEventHandler;
            DirectoryInfo d = new DirectoryInfo(base.setting.lambdaConfig.Params["DestFolder"]);
            FileInfo[] infos = d.GetFiles();

            if (infos.Length > 0)
            {
                infos[0].MoveTo(this.Config["New_Driver_Path"] + "\\" + "GEMEL " + base.setting.lambdaConfig.Params["Year"].ToString() + "_" + base.setting.lambdaConfig.Params["Month"].ToString() + ".xml");
                infos = null;
            }


            //infos[0].Delete();  
            //delete folder
            //d.Delete();

        }

    }
}
