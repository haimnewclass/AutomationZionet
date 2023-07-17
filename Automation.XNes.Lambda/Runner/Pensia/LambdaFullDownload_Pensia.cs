using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base.Driver;
using OpenQA.Selenium;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Automation.XNes.Lambda.Scripts.Pensia;

namespace Automation.XNes.Lambda.Runner.Pensia
{
    public class LambdaFullDownload_Pensia : LambdaScriptBase
    {
        public LambdaStartSelect_Pensia script1;
        public LambdaDownloadOneMonth_Pensia script2;
        public LambdaDownloadBetYears_Pensia script3;
        ScriptState ret = ScriptState.NotStarted;
        LambdaDownloadOneMonth_Pensia lambdaDownloadOneMonth_Pensia;
        FileSystemEventHandler AfileSystemEventHandler;
        IWebDriver WebDriver;

        //get all the Bituach files
        public LambdaFullDownload_Pensia(IWebDriver webDriver,LambdaSetting s, FileSystemEventHandler afileSystemEventHandler) :base(webDriver,s)
        {
            AfileSystemEventHandler = afileSystemEventHandler;
            base.setting = s;
            WebDriver = webDriver;
        }
        public override ScriptState Run()
        {
            ret = ScriptState.Started;

            lambdaDownloadOneMonth_Pensia = new LambdaDownloadOneMonth_Pensia(WebDriver, base.setting,setting.lambdaConfig["Month"], setting.lambdaConfig["Year"], bool.Parse(setting.lambdaConfig["IsFullDetails"]), this.afterFileCreated);
            lambdaDownloadOneMonth_Pensia.Run();

            return ret;
        }

     
        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            AfileSystemEventHandler(sender, e);
            lambdaDownloadOneMonth_Pensia.CopyCompleatedFileToTargetFolder();


        }
    }
}
