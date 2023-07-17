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
using Automation.XNes.Lambda.Runner.Gemel;

namespace Automation.XNes.Lambda
{
    public class PensiaFullDownload_Pensia_All : LambdaScriptBase
    {
        ScriptState ret = ScriptState.NotStarted;
        LambdaFullDownload_Gemel lambdaFullDownload_Gemel;
        IWebDriver WebDriver;
        bool IsRunning = false;
        public PensiaFullDownload_Pensia_All(IWebDriver webDriver, LambdaSetting s, string newFolderPath) : base(webDriver, s)
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

                for (int i = 1; i < 13; i++)
                {
                    Thread.Sleep(1500);

                    if (j == 2003 && i == 10 ||
                       j == 2004 && i == 4 ||
                       j == 2004 && i == 6 ||
                       j == 2005 && i == 7 ||
                       j == 2006 && i == 1 ||
                       j == 2006 && i == 2 ||
                       j == 2006 && i == 7 ||
                       j == 2007 && i == 5 ||
                       j == 2008 && i == 2 ||
                       j == 2008 && i == 7 ||
                       j == 2008 && i == 9 ||
                       j == 2009 && i == 11 ||
                       j == 2009 && i == 12 ||
                       j == 2010 && i == 1 ||
                       j == 2010 && i == 2 ||
                       j == 2013 && i == 6 ||
                       j == 2013 && i == 12 ||
                       j == 2015 && i == 5 ||
                       j == 2016 && i == 2 ||
                       j == 2019 && i == 4)
                    {
                        continue;
                    }

                    if (i < 10)
                        base.setting.lambdaConfig["Month"] = "0" + i.ToString();
                    else
                        base.setting.lambdaConfig["Month"] = i.ToString();

                    base.setting.lambdaConfig["Year"] = j.ToString();
                    lambdaFullDownload_Gemel = new LambdaFullDownload_Gemel(WebDriver, base.setting, this.afterFileCreated);
                    IsRunning = true;
                    lambdaFullDownload_Gemel.Run();
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
    }
}
