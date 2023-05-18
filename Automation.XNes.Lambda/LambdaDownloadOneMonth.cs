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

            ElementSelect.Get(setting, "Select-one").SelectByValue(month);
            ElementSelect.Get(setting, "Select-two").SelectByValue(year);
            ElementSelect.Get(setting, "Select-three").SelectByValue(month);
            ElementSelect.Get(setting, "Select-four").SelectByValue(year);

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

            if (infos.Length>0)
            {
            infos[0].MoveTo(this.Config["New_Driver_Path"] + "\\" +"GEMEL "+ year.ToString() + "_" + month.ToString() + ".xml");
                infos = null;
            }


            //infos[0].Delete();  
            //delete folder
            //d.Delete();
            
        }

    }


}
