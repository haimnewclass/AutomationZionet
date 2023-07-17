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
using Automation.XNes.Lambda.Scripts.Bituach;

namespace Automation.XNes.Lambda.Runner.Bituach
{
    public class LambdaFullDownload_Bituach : LambdaScriptBase
    {
        public LambdaStartSelect_Bituach script1;
        public LambdaDownloadOneMonth_Bituach script2;
        public LambdaDownloadBetYears_Bituach script3;
        ScriptState ret = ScriptState.NotStarted;
        LambdaDownloadOneMonth_Bituach lambdaDownloadOneMonth_Bituach;
        FileSystemEventHandler AfileSystemEventHandler;
        IWebDriver WebDriver;

        //get all the Bituach files
        public LambdaFullDownload_Bituach(IWebDriver webDriver,LambdaSetting s, FileSystemEventHandler afileSystemEventHandler) :base(webDriver,s)
        {
            AfileSystemEventHandler = afileSystemEventHandler;
            base.setting = s;
            WebDriver = webDriver;
        }
        public override ScriptState Run()
        {
            ret = ScriptState.Started;

            lambdaDownloadOneMonth_Bituach = new LambdaDownloadOneMonth_Bituach(WebDriver, base.setting,setting.lambdaConfig["Month"], setting.lambdaConfig["Year"], bool.Parse(setting.lambdaConfig["IsFullDetails"]), this.afterFileCreated);
            lambdaDownloadOneMonth_Bituach.Run();

            return ret;
        }

     
        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            AfileSystemEventHandler(sender, e);
            lambdaDownloadOneMonth_Bituach.CopyCompleatedFileToTargetFolder();


        }
    }
}
