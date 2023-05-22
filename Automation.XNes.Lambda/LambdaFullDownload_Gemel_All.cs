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

namespace Automation.XNes.Lambda
{
    public class LambdaFullDownload_Gemel_All: LambdaScriptBase
    {
        ScriptState ret = ScriptState.NotStarted;
        //the local path of the project
        LambdaFullDownload_Gemel lambdaFullDownload_Gemel;
        IWebDriver WebDriver;
        bool IsRunning = false;
        //get all the gemel files
        public LambdaFullDownload_Gemel_All(IWebDriver webDriver,LambdaSetting s):base(webDriver,s)
        {
            base.setting = s;
            WebDriver = webDriver;
        }
        public override ScriptState Run()
        {
            ret = ScriptState.Started;
            for (int i = 0; i < 12; i++)
            {
                
                base.setting.lambdaConfig["Month"] = "01";
                base.setting.lambdaConfig["Year"] = "2010";
                lambdaFullDownload_Gemel = new LambdaFullDownload_Gemel(WebDriver, base.setting,this.afterFileCreated);
                IsRunning = true;
                lambdaFullDownload_Gemel.Run();
                //whie IsRunning == true do nothing
                while(IsRunning==true)
                {
                    //
                    System.Threading.Thread.Sleep(100);
                }
            }

            return ret;
        }

     
        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            IsRunning = false;


        }
    }
}
