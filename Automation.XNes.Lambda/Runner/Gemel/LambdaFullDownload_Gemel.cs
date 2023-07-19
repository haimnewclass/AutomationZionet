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
using Automation.XNes.Lambda.Scripts.Gemel;

namespace Automation.XNes.Lambda.Runner.Gemel
{
    public class LambdaFullDownload_Gemel: LambdaScriptBase
    {

        public LambdaStartSelect script1;
        public LambdaDownloadOneMonth script2;
        public LambdaDownloadBetYears script3;
        ScriptState ret = ScriptState.NotStarted;
        LambdaDownloadOneMonth lambdaDownloadOneMonth;
        FileSystemEventHandler AfileSystemEventHandler;
        IWebDriver WebDriver;
        //get all the gemel files
        public LambdaFullDownload_Gemel(IWebDriver webDriver,LambdaSetting s, FileSystemEventHandler afileSystemEventHandler) :base(webDriver,s)
        {
            AfileSystemEventHandler = afileSystemEventHandler;
            base.setting = s;
            WebDriver = webDriver;
        }
        public override ScriptState Run()
        {
            ret = ScriptState.Started;

            lambdaDownloadOneMonth = new LambdaDownloadOneMonth(WebDriver, base.setting,setting.lambdaConfig["Month"], setting.lambdaConfig["Year"], bool.Parse(setting.lambdaConfig["IsFullDetails"]), this.afterFileCreated);
            lambdaDownloadOneMonth.Run();

            return ret;
        }

     
        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            AfileSystemEventHandler(sender, e);
            lambdaDownloadOneMonth.CopyCompleatedFileToTargetFolder();


        }
    }
}
