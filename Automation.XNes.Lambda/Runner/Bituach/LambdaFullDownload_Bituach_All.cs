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
using Automation.XNes.Lambda.Runner.Pensia;

namespace Automation.XNes.Lambda.Runner.Bituach
{
    public class LambdaFullDownload_Bituach_All : LambdaScriptBase
    {
        ScriptState ret = ScriptState.NotStarted;
        LambdaFullDownload_Bituach lambdaFullDownload_Bituach;
        IWebDriver WebDriver;
        bool IsRunning = false;
        public LambdaFullDownload_Bituach_All(IWebDriver webDriver, LambdaSetting s, bool isFullDetails, string newFolderPath) : base(webDriver, s)
        {
            base.setting = s;
            WebDriver = webDriver;
            base.setting.lambdaConfig["DestFolder"] = newFolderPath;
            base.setting.lambdaConfig["IsFullDetails"] = isFullDetails.ToString();
        }
        public override ScriptState Run()
        {
            ret = ScriptState.Started;
            for (int j = 1999; j < 2023; j++)
            {

                for (int i = 1; i < 13; i++)
                {
                    Thread.Sleep(1500);

                    //if (j == 0 && i == 0)
                    //{
                    //    continue;
                    //}

                    if (i < 10)
                        base.setting.lambdaConfig["Month"] = i.ToString();
                    else
                        base.setting.lambdaConfig["Month"] = i.ToString();

                    base.setting.lambdaConfig["Year"] = j.ToString();
                   
                    lambdaFullDownload_Bituach = new LambdaFullDownload_Bituach(WebDriver, base.setting, this.afterFileCreated);
                    IsRunning = true;
                    lambdaFullDownload_Bituach.Run();
                    //whie IsRunning == true do nothing
                    while (IsRunning == true)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
                //TODO: change to two minutes (1000*60*2)
                System.Threading.Thread.Sleep(1000 * 10);
            }

            return ret;
        }


        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            IsRunning = false;


        }


        public ScriptState RunOneMonth(int month, int year)
        {
            ret = ScriptState.Started;
           
            Thread.Sleep(1500);

            //if (j == 0 && i == 0)
            //{
            //    continue;
            //}

            if (month < 10)
                base.setting.lambdaConfig["Month"] = month.ToString();
            else
                base.setting.lambdaConfig["Month"] = month.ToString();

            base.setting.lambdaConfig["Year"] = year.ToString();

            lambdaFullDownload_Bituach = new LambdaFullDownload_Bituach(WebDriver, base.setting, this.afterFileCreated);
            IsRunning = true;
            lambdaFullDownload_Bituach.Run();
            //whie IsRunning == true do nothing
            while (IsRunning == true)
            {
                System.Threading.Thread.Sleep(100);
            }

            return ret;
        }
    }
}
