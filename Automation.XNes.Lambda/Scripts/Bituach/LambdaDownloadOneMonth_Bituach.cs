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

namespace Automation.XNes.Lambda.Scripts.Bituach
{
    public class LambdaDownloadOneMonth_Bituach : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public string monthStart { get; set; } = "1";
        public string monthEnd { get; set; } = "12";
        public bool isFullDetails { get; set; }
        public string newFolderPath { get; set; }
        protected FileSystemWatcher watcher;
        public static int currect = 0;
        public static string[] undownloadfiles = new string[100];

        FileSystemEventHandler fileSystemEventHandler;

        public LambdaDownloadOneMonth_Bituach(IWebDriver d, LambdaSetting s, string month, string year, bool isFullDetails, FileSystemEventHandler afileSystemEventHandler) : base(d, s)
        {
            fileSystemEventHandler = afileSystemEventHandler;
            setting = s;
            driver = d;
            this.year = year;
            this.month = month;
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

            GoToUrl("baseBituchUrl");
            ElementButton.Get(setting, "bituach-Btn-knisa").Click();
            Wait(1500);
            ElementButton.Get(setting, "bituach-Select-All-Kupot").Click();
            Wait(1500);
            ElementButton.Get(setting, "bituach-Btn-Add").Click();
            Wait(1500);
            ElementButton.Get(setting, "bituach-Btn-Download-Xml").Click();

            GoToUrl("BituachPopingWindow");
            string s = driver.Url.ToString();
            Console.WriteLine(s);
            Thread.Sleep(1000);
            Wait(1000);
            if (isFullDetails)
            {
                ElementSelect.Get(setting, "bituach-Select-From-Month").SelectByValue(month);
                ElementSelect.Get(setting, "bituach-Select-From-Year").SelectByValue(year);
                ElementSelect.Get(setting, "bituach-Select-Until-Month").SelectByValue(month);
                ElementSelect.Get(setting, "bituach-Select-Until-Year").SelectByValue(year);
            }
            else
            {
                ElementSelect.Get(setting, "bituach-Select-From-Month").SelectByValue(monthStart);
                ElementSelect.Get(setting, "bituach-Select-From-Year").SelectByValue(year);
                ElementSelect.Get(setting, "bituach-Select-Until-Month").SelectByValue(monthEnd);
                ElementSelect.Get(setting, "bituach-Select-Until-Year").SelectByValue(year);
            }

            if (isFullDetails)
            {
                ElementButton.Get(setting, "bituach-Radio-PerutMale").Click();
            }
            ElementButton.Get(setting, "bituach-Btn-Confirm").Click();
            Thread.Sleep(5000);

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

                    if (bool.Parse(base.setting.lambdaConfig["IsFullDetails"]))
                    {
                        infos[0].MoveTo(this.Config["bituach_New_Driver_Path"] + "\\" + "BITUACH_NETUNIM " + base.setting.lambdaConfig.Params["Year"].ToString() + "_" + base.setting.lambdaConfig.Params["Month"].ToString() + ".xml");
                    }
                    else
                    {
                        infos[0].MoveTo(this.Config["bituach_New_Driver_Path_Chevrot"] + "\\" + "BITUACH_CHEVROT " + base.setting.lambdaConfig.Params["Year"].ToString().ToString() + ".xml");
                    }                    

                }
                else if (infos.Length == 0)
                {
                    Thread.Sleep(1500);
                    LambdaDownloadOneMonth_Bituach lambda = new LambdaDownloadOneMonth_Bituach(this.driver, this.setting, this.month, this.year, this.isFullDetails, this.fileSystemEventHandler);
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
