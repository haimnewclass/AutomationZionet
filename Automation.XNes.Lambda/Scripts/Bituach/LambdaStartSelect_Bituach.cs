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

namespace Automation.XNes.Lambda.Scripts.Bituach
{
    public class LambdaStartSelect_Bituach : LambdaScriptBase
    {
        public LambdaSetting setting { get; set; }
        public IWebDriver driver { get; set; }
        public int year_from;
        public int year_to;
        public string month;
        public bool isFullDetails;
        public string newFolderPath { get; set; }
        public LambdaStartSelect_Bituach(IWebDriver d, LambdaSetting s, bool isFullDetails) : base(d, s)
        {
            setting = s;
            driver = d;
            year_from = int.Parse(this.Config["bituach_Year_from"]);
            year_to = int.Parse(this.Config["bituach_Year_to"]);
            this.isFullDetails = isFullDetails;
            this.newFolderPath = base.setting.lambdaConfig.Params["DestFolder"];

        }
        public override ScriptState Run()
        {
            var before = Directory.GetFiles(this.Config["bituach_Driver_Path"]);
            base.State = ScriptState.Started;

            GoToUrl("baseBituchUrl");
            ElementButton.Get(setting, "bituach-Btn-knisa").Click();
            Wait(1500);
            ElementButton.Get(setting, "bituach-Select-All-Kupot").Click();
            Wait(1500);
            ElementButton.Get(setting, "bituach-Btn-Add").Click();
            Wait(1500);
            ElementButton.Get(setting, "bituach-Btn-Download-Xml").Click();
            for (int j = year_from; j < year_to; j++)
            {
                for (int i = 1; i < 13; i++)
                {

                    DirectoryInfo d = new DirectoryInfo(this.Config["bituach_Driver_Path"]);

                    d.GetFiles().All(x => { x.Delete(); return true; });

                    if (i < 10)
                        month = i.ToString();
                    else
                        month = i.ToString();

                    GoToUrl("BituachPopingWindow");
                    string s = driver.Url.ToString();
                    Console.WriteLine(s);
                    Thread.Sleep(1000);
                    Wait(1000);
                    ElementSelect.Get(setting, "bituach-Select-From-Month").SelectByValue(month);
                    ElementSelect.Get(setting, "bituach-Select-From-Year").SelectByValue(year_from.ToString());
                    ElementSelect.Get(setting, "bituach-Select-Until-Month").SelectByValue(month);
                    ElementSelect.Get(setting, "bituach-Select-Until-Year").SelectByValue(year_to.ToString());
                    if (isFullDetails)
                    {
                        ElementButton.Get(setting, "bituach-Radio-PerutMale").Click();
                    }
                    else
                    {

                    }
                    ElementButton.Get(setting, "bituach-Btn-Confirm").Click();

                    Thread.Sleep(5000);



                }
            }

            return base.State;
        }

    }
}
