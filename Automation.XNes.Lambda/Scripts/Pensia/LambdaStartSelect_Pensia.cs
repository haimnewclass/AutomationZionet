using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutomationZionet.Base.WebElements;
using AutomationZionet.Base;
using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Automation.XNes.Lambda.Scripts.Pensia
{
    public class LambdaStartSelect_Pensia : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public int year_from;
        public int year_to;
        public string month;
        public bool isFullDetails;
        public string newFolderPath { get; set; }
        public LambdaStartSelect_Pensia(IWebDriver d, LambdaSetting s, bool isFullDetails) : base(d, s)
        {
            setting = s;
            driver = d;
            year_from = int.Parse(this.Config["pensia_Year_from"]);
            year_to = int.Parse(this.Config["pensia_Year_to"]);
            this.isFullDetails = isFullDetails;
            this.newFolderPath = base.setting.lambdaConfig.Params["DestFolder"];

        }
        public override ScriptState Run()
        {
            var before = Directory.GetFiles(this.Config["pensia_Driver_Path"]);
            base.State = ScriptState.Started;

            GoToUrl("basePensiaUrl");
            ElementButton.Get(setting, "pensia-Btn-knisa").Click();
            Thread.Sleep(3000);
            ElementButton.Get(setting, "pensia-Btn-options").Click();
            ElementButton.Get(setting, "pensia-Btn-All-New-Option").Click();
            for (int j = year_from; j < year_to; j++)
            {
                for (int i = 1; i < 13; i++)
                {

                    DirectoryInfo d = new DirectoryInfo(this.Config["bituach_Driver_Path"]);

                    d.GetFiles().All(x => { x.Delete(); return true; });

                    switch (i)
                    {
                        case 1:
                            month = "ינואר";
                            break;
                        case 2:
                            month = "פברואר";
                            break;
                        case 3:
                            month = "מרץ";
                            break;
                        case 4:
                            month = "אפריל";
                            break;
                        case 5:
                            month = "מאי";
                            break;
                        case 6:
                            month = "יוני";
                            break;
                        case 7:
                            month = "יולי";
                            break;
                        case 8:
                            month = "אוגוסט";
                            break;
                        case 9:
                            month = "ספטמבר";
                            break;
                        case 10:
                            month = "אוקטובר";
                            break;
                        case 11:
                            month = "נובמבר";
                            break;
                        case 12:
                            month = "דצמבר";
                            break;
                        default:
                            break;
                    }

                    driver.FindElement(By.XPath(@"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[1]/div[1]/span[1]/span/input")).Clear();
                    ElementInput.Get(setting, "pensia-Input-Select-Start-Date").SendKeys(month + " " + year_from);
                    driver.FindElement(By.XPath(@"/html/body/main/section/div/div[2]/div[2]/div/div/div[2]/div[3]/div[1]/div[2]/span[1]/span/input")).Clear();
                    ElementInput.Get(setting, "pensia-Input-Select-End-Date").SendKeys(month + " " + year_to);
                    ElementButton.Get(setting, "pensia-Btn-Download-Xml").Click();
                    if (isFullDetails)
                    {
                        ElementButton.Get(setting, "pensia-Radio-Full-Details").Click();
                    }
                    else
                    {
                        ElementButton.Get(setting, "pensia-Radio-General-Details").Click();
                    }
                    
                    ElementButton.Get(setting, "pensia-Btn-Dounload-Xml-File").Click();
                    Thread.Sleep(3000);



                }
            }

            return base.State;
        }

    }
}
