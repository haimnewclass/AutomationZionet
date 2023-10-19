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
using Automation.XNes.Lambda.Runner.Bituach;

namespace Automation.XNes.Lambda.Runner.Gemel
{
    public class LambdaFullDownload_Gemel_All : LambdaScriptBase
    {
        ScriptState ret = ScriptState.NotStarted;
        LambdaFullDownload_Gemel lambdaFullDownload_Gemel;
        IWebDriver WebDriver;
        bool IsRunning = false;
        public LambdaFullDownload_Gemel_All(IWebDriver webDriver, LambdaSetting s, bool isFullDetails, string newFolderPath) : base(webDriver, s)
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

                    //if (CheckIfDateExitsInWeb(bool.Parse(base.setting.lambdaConfig["IsFullDetails"]), i, j))
                    //{
                    //    continue;
                    //}

                    if (i < 10)
                        base.setting.lambdaConfig["Month"] = "0" + i.ToString();
                    else
                        base.setting.lambdaConfig["Month"] = i.ToString();

                    base.setting.lambdaConfig["Year"] = j.ToString();
                    lambdaFullDownload_Gemel = new LambdaFullDownload_Gemel(WebDriver, base.setting, this.afterFileCreated);
                    IsRunning = true;
                    base.setting.lambdaConfig["IsRunning"] = "true";
                    lambdaFullDownload_Gemel.Run();
                    //whie IsRunning == true do nothing
                    while (base.setting.lambdaConfig["IsRunning"] == "true"&& IsRunning == true)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
                //TODO: change to two minutes (1000*60*2)
                System.Threading.Thread.Sleep(1000 * 10);
            }

            return ret;
        }

        public ScriptState RunOneMonth(int month, int year)
        {
            ret = ScriptState.Started;

            Thread.Sleep(1500);

            if (CheckIfDateExitsInWeb(bool.Parse(base.setting.lambdaConfig["IsFullDetails"]), month, year))
            {
                return ret;
            }

            if (month < 10)
                base.setting.lambdaConfig["Month"] = "0" + month.ToString();
            else
                base.setting.lambdaConfig["Month"] = month.ToString();

            base.setting.lambdaConfig["Year"] = year.ToString();
            lambdaFullDownload_Gemel = new LambdaFullDownload_Gemel(WebDriver, base.setting, this.afterFileCreated);
            IsRunning = true;
            lambdaFullDownload_Gemel.Run();
            //whie IsRunning == true do nothing
            while (IsRunning == true)
            {
                System.Threading.Thread.Sleep(100);
            }
        
            //TODO: change to two minutes (1000*60*2)
            System.Threading.Thread.Sleep(1000 * 10);

            return ret;
        }
        public ScriptState RunYears(int startYear,int endYear)
        {
            ret = ScriptState.Started;
            for (int j = startYear; j < endYear; j++)
            {

                for (int i = 1; i < 13; i++)
                {
                    Thread.Sleep(1500);

                    if (CheckIfDateExitsInWeb(bool.Parse(base.setting.lambdaConfig["IsFullDetails"]), i, j))
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
        public ScriptState RunChevrot()
        {
            ret = ScriptState.Started;
            for (int j = 1999; j < 2023; j++)
            {

                Thread.Sleep(1500);

                base.setting.lambdaConfig["Month"] = "0"; //will be set later in the program
                base.setting.lambdaConfig["Year"] = j.ToString();

                lambdaFullDownload_Gemel = new LambdaFullDownload_Gemel(WebDriver, base.setting, this.afterFileCreated);
                IsRunning = true;
                lambdaFullDownload_Gemel.Run();
                //whie IsRunning == true do nothing
                while (IsRunning == true)
                {
                    System.Threading.Thread.Sleep(100);
                }

                //TODO: change to two minutes (1000*60*2)
                System.Threading.Thread.Sleep(1000 * 10);
            }

            return ret;
        }

        public bool CheckIfDateExitsInWeb(bool isFullDetails, int month, int year)
        {
            if(isFullDetails)
            {
                if (year == 2003 && month == 10 ||
                    year == 2004 && month == 4 ||
                    year == 2004 && month == 6 ||
                    year == 2005 && month == 7 ||
                    year == 2006 && month == 1 ||
                    year == 2006 && month == 2 ||
                    year == 2006 && month == 7 ||
                    year == 2007 && month == 5 ||
                    year == 2008 && month == 2 ||
                    year == 2008 && month == 7 ||
                    year == 2008 && month == 9 ||
                    year == 2009 && month == 11 ||
                    year == 2009 && month == 12 ||
                    year == 2010 && month == 1 ||
                    year == 2010 && month == 2 ||
                    year == 2013 && month == 6 ||
                    year == 2013 && month == 12 ||
                    year == 2015 && month == 5 ||
                    year == 2016 && month == 2 ||
                    year == 2019 && month == 4
                    )    
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            IsRunning = false;

        }
    }
}
