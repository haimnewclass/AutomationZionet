using Automation.XNes.Lambda.Runner.Bituach;
using Automation.XNes.Lambda.Runner.Gemel;
using Automation.XNes.Lambda.Runner.Pensia;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.XNes.Lambda.Runner.General
{
    public class LambdaDownload_Gemel_Bituch_Pensia : LambdaScriptBase
    {
        ScriptState ret = ScriptState.NotStarted;
        LambdaFullDownload_Gemel lambdaFullDownload_Gemel;
        LambdaFullDownload_Bituach lambdaFullDownload_Bituach;
        LambdaFullDownload_Pensia lambdaFullDownload_Pensia;
        IWebDriver WebDriver;
        bool IsRunning = false;
        public LambdaDownload_Gemel_Bituch_Pensia(IWebDriver webDriver, LambdaSetting s, bool isFullDetails, string newFolderPath) : base(webDriver, s)
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

                for (int i = 1; i < 12; i++)
                {
                    Thread.Sleep(1500);
                    GetMonthForGemel(i);
                    base.setting.lambdaConfig["Year"] = j.ToString();
                    lambdaFullDownload_Gemel = new LambdaFullDownload_Gemel(WebDriver, base.setting, this.afterFileCreated);
                    IsRunning = true;
                    base.setting.lambdaConfig["IsRunningAll"] = "true";
                    base.setting.lambdaConfig["IsRunning"] = "true";
                    lambdaFullDownload_Gemel.Run();
                    //whie IsRunning == true do nothing
                    while (base.setting.lambdaConfig["IsRunningAll"] == "true" && base.setting.lambdaConfig["IsRunning"] == "true")
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                    GetMonthForBituch(i);
                    lambdaFullDownload_Bituach = new LambdaFullDownload_Bituach(WebDriver, base.setting, this.afterFileCreated);
                    IsRunning = true;
                    base.setting.lambdaConfig["IsRunningAll"] = "true";
                    lambdaFullDownload_Bituach.Run();
                    while (base.setting.lambdaConfig["IsRunningAll"] == "true")
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                    GetMonthForPensia(i);
                    lambdaFullDownload_Pensia = new LambdaFullDownload_Pensia(WebDriver, base.setting, this.afterFileCreated);
                    IsRunning = true;
                    base.setting.lambdaConfig["IsRunningAll"] = "true";
                    lambdaFullDownload_Pensia.Run();
                    while (base.setting.lambdaConfig["IsRunningAll"] == "true")
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            return ret;
        }
        public void GetMonthForGemel(int i)
        {
            if (i < 10)
                base.setting.lambdaConfig["Month"] = "0" + i.ToString();
            else
                base.setting.lambdaConfig["Month"] = i.ToString();

        }
        public void GetMonthForBituch(int i)
        {
            base.setting.lambdaConfig["Month"] = i.ToString();
        }
        public void GetMonthForPensia(int i)
        {
            switch (i)
            {
                case 1:
                    base.setting.lambdaConfig["Month"] = "ינואר";
                    break;
                case 2:
                    base.setting.lambdaConfig["Month"] = "פברואר";
                    break;
                case 3:
                    base.setting.lambdaConfig["Month"] = "מרץ";
                    break;
                case 4:
                    base.setting.lambdaConfig["Month"] = "אפריל";
                    break;
                case 5:
                    base.setting.lambdaConfig["Month"] = "מאי";
                    break;
                case 6:
                    base.setting.lambdaConfig["Month"] = "יוני";
                    break;
                case 7:
                    base.setting.lambdaConfig["Month"] = "יולי";
                    break;
                case 8:
                    base.setting.lambdaConfig["Month"] = "אוגוסט";
                    break;
                case 9:
                    base.setting.lambdaConfig["Month"] = "ספטמבר";
                    break;
                case 10:
                    base.setting.lambdaConfig["Month"] = "אוקטובר";
                    break;
                case 11:
                    base.setting.lambdaConfig["Month"] = "נובמבר";
                    break;
                case 12:
                    base.setting.lambdaConfig["Month"] = "דצמבר";
                    break;
                default:
                    break;
            }
        }
        public void afterFileCreated(object sender, FileSystemEventArgs e)
        {
            IsRunning = false;

        }
    }
}
