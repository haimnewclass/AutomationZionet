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
    public class LambdaFullDownload_Gemel_All: LambdaScriptBase
    {
        ScriptState ret = ScriptState.NotStarted;
        LambdaFullDownload_Gemel lambdaFullDownload_Gemel;
        IWebDriver WebDriver;
        bool IsRunning = false;
        public LambdaFullDownload_Gemel_All(IWebDriver webDriver,LambdaSetting s,string newFolderPath) :base(webDriver,s)
        {
            base.setting = s;
            WebDriver = webDriver;
            base.setting.lambdaConfig["DestFolder"] = newFolderPath;
        }
        public override ScriptState Run()
        {
            ret = ScriptState.Started;
            for (int j = 1999; j < 2023; j++)
            {

            for (int i =1; i < 13; i++)
            {
                Thread.Sleep(1500);

                if(j==2003 && i == 10)
                    {
                        continue;
                    }

                if (i<10)
                base.setting.lambdaConfig["Month"] = "0"+i.ToString();
                else
                base.setting.lambdaConfig["Month"] = i.ToString();

                base.setting.lambdaConfig["Year"] = j.ToString();
                lambdaFullDownload_Gemel = new LambdaFullDownload_Gemel(WebDriver, base.setting,this.afterFileCreated);
                IsRunning = true;
                lambdaFullDownload_Gemel.Run();
                //whie IsRunning == true do nothing
                while(IsRunning==true)
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
            //two sec
                System.Threading.Thread.Sleep(1000*10);
            }
            
            return ret;
        }

     
        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            IsRunning = false;


        }
    }
}
