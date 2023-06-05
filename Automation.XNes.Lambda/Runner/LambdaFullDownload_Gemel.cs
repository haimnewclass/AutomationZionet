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

namespace Automation.XNes.Lambda
{
    public class LambdaFullDownload_Gemel: LambdaScriptBase
    {
        //the local path of the project
        const string path = @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\DownloadFiles";
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

            lambdaDownloadOneMonth = new LambdaDownloadOneMonth(WebDriver, base.setting,setting.lambdaConfig["Month"], setting.lambdaConfig["Year"], this.afterFileCreated);
            //base.setting.lambdaConfig["DestFolder"]= @"C:\Users\user\learning\xnesLearning\xnes_react\AutomationZionet\DownloadFiles";
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
