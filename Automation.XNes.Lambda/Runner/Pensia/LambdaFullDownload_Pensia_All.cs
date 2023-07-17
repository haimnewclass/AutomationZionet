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
using System.Linq.Expressions;

namespace Automation.XNes.Lambda.Runner.Pensia
{
    public class LambdaFullDownload_Pensia_All : LambdaScriptBase
    {
        ScriptState ret = ScriptState.NotStarted;
        LambdaFullDownload_Pensia lambdaFullDownload_Pensia;
        IWebDriver WebDriver;
        bool IsRunning = false;
        public LambdaFullDownload_Pensia_All(IWebDriver webDriver, LambdaSetting s, bool isFullDetails, string newFolderPath) : base(webDriver, s)
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


                    base.setting.lambdaConfig["Year"] = j.ToString();

                    lambdaFullDownload_Pensia = new LambdaFullDownload_Pensia(WebDriver, base.setting, this.afterFileCreated);
                    IsRunning = true;
                    lambdaFullDownload_Pensia.Run();
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
