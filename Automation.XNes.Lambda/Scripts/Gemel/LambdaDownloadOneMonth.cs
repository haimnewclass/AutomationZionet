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

namespace Automation.XNes.Lambda.Scripts.Gemel
{
    public class LambdaDownloadOneMonth : LambdaScriptBase
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

        public LambdaDownloadOneMonth(IWebDriver d, LambdaSetting s, string month, string year, bool isFullDetails, FileSystemEventHandler afileSystemEventHandler) : base(d, s)
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

            GoToUrl("baseGemelUrl");
            ElementButton.Get(setting, "Btn-knisa").Click();
            ElementButton.Get(setting, "Select-All-Kupot").Click();
            Thread.Sleep(1000);
            ElementButton.Get(setting, "Btn-Add").Click();
            ElementButton.Get(setting, "Btn-Download-Xml").Click();
            Thread.Sleep(3000);
            if (isFullDetails)
            {
                ElementSelect.Get(setting, "Select-one").SelectByValue(month);
                Thread.Sleep(100);
                ElementSelect.Get(setting, "Select-two").SelectByValue(year);
                Thread.Sleep(100);
                ElementSelect.Get(setting, "Select-three").SelectByValue(month);
                Thread.Sleep(100);
                ElementSelect.Get(setting, "Select-four").SelectByValue(year);
                Thread.Sleep(100);
            }
            else
            {
                ElementSelect.Get(setting, "Select-one").SelectByValue(monthStart);
                Thread.Sleep(100);
                ElementSelect.Get(setting, "Select-two").SelectByValue(year);
                Thread.Sleep(100);
                ElementSelect.Get(setting, "Select-three").SelectByValue(monthEnd);
                Thread.Sleep(100);
                ElementSelect.Get(setting, "Select-four").SelectByValue(year);
                Thread.Sleep(100);
            }
           
            if (isFullDetails)
            {
                ElementButton.Get(setting, "Radio-PerutMale").Click();
            }
            ElementButton.Get(setting, "Btn-Confirm").Click();

            Thread.Sleep(2000);
            string monthYear = base.setting.lambdaConfig.Params["Year"].ToString() + base.setting.lambdaConfig.Params["Month"].ToString();
            string erorrPage = @"https://gemelnet.cma.gov.il/tsuot/ui/tsuotHodXML.aspx?miTkfDivuach=" + monthYear + "&adTkfDivuach=" + monthYear + "&kupot=0000&Dochot=1";
            string currecturl = driver.Url.Substring(0, driver.Url.Length - 6);

            if (erorrPage == currecturl)
            {
                undownloadfiles[currect++] = monthYear;
                watcher.Changed -= fileSystemEventHandler;
            }


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
                        infos[0].MoveTo(this.Config["New_Driver_Path"] + "\\" + "GEMEL_NETUNIM " + base.setting.lambdaConfig.Params["Year"].ToString() + "_" + base.setting.lambdaConfig.Params["Month"].ToString() + ".xml");
                    }
                    else
                    {
                        infos[0].MoveTo(this.Config["New_Driver_Path"] + "\\" + "GEMEL_CHEVROT " + base.setting.lambdaConfig.Params["Year"].ToString() + "_" + base.setting.lambdaConfig.Params["Month"].ToString() + ".xml");
                    }

                }
                else if (infos.Length == 0)
                {
                    Thread.Sleep(1500);
                    LambdaDownloadOneMonth lambda = new LambdaDownloadOneMonth(this.driver, this.setting, this.month, this.year, this.isFullDetails, this.fileSystemEventHandler);
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
