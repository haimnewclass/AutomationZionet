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

namespace Automation.XNes.Lambda.Scripts.Pensia
{
    public class LambdaDownloadOneMonth_Pensia : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public bool isFullDetails { get; set; }
        public string newFolderPath { get; set; }
        protected FileSystemWatcher watcher;
        public static int currect = 0;
        public static string[] undownloadfiles = new string[100];

        FileSystemEventHandler fileSystemEventHandler;

        public LambdaDownloadOneMonth_Pensia(IWebDriver d, LambdaSetting s, string monthInHebrew, string year, bool isFullDetails, FileSystemEventHandler afileSystemEventHandler) : base(d, s)
        {
            fileSystemEventHandler = afileSystemEventHandler;
            setting = s;
            driver = d;
            this.year = year;
            this.month = monthInHebrew;
            this.isFullDetails = isFullDetails;
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

            GoToUrl("basePensiaUrl");
            ElementButton.Get(setting, "pensia-Btn-knisa").Click();
            Thread.Sleep(8000);
            ElementButton.Get(setting, "pensia-Btn-options").Click();
            ElementButton.Get(setting, "pensia-Btn-All-New-Option").Click();
            driver.FindElement(By.XPath(@"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[1]/div[1]/span[1]/span/input")).Clear();
            ElementInput.Get(setting, "pensia-Input-Select-Start-Date").SendKeys(month + " " + year);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(@"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[1]/div[2]/span[1]/span/input")).Clear();
            ElementInput.Get(setting, "pensia-Input-Select-End-Date").SendKeys(month + " " + year);
            Thread.Sleep(500);
            ElementButton.Get(setting, "pensia-Btn-Download-Xml").Click();
            if (isFullDetails)
            {
                ElementButton.Get(setting, "pensia-Radio-Full-Details").Click();
            }
            else
            {
                ElementButton.Get(setting, "pensia-Radio-General-Details").Click();
            }
            
            ElementButton.Get(setting, "pensia-Btn-Dounload-Xml-File").Click();
            Thread.Sleep(3000);

            return base.State;
        }

        //after compleated to create th new file
        public async void CopyCompleatedFileToTargetFolder()
        {
            watcher.Changed -= fileSystemEventHandler;
            DirectoryInfo d = new DirectoryInfo(base.setting.lambdaConfig.Params["DestFolder"]);
            FileInfo[] infos = d.GetFiles();
            try
            {

                //check!
                if (infos.Length == 1)
                {
                    Thread.Sleep(1500);
                    infos[0].MoveTo(this.Config["pensia_New_Driver_Path"] + "\\" + "PENSIA " + base.setting.lambdaConfig.Params["Year"].ToString() + "_" + base.setting.lambdaConfig.Params["Month"].ToString() + ".xml");

                }
                else if (infos.Length == 0)
                {
                    Thread.Sleep(1500);
                    LambdaDownloadOneMonth_Pensia lambda = new LambdaDownloadOneMonth_Pensia(this.driver, this.setting, this.month, this.year, this.isFullDetails, this.fileSystemEventHandler);
                    lambda.Run();
                }
                else if (infos.Length > 1)
                {
                    throw new Exception("more than one file in folder!");
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                infos = null;

            }
 

        }

    }


}
