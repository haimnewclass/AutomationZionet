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
        public string newFolderPath { get; set; }
        public LambdaStartSelect_Bituach(IWebDriver d, LambdaSetting s) : base(d, s)
        {
            setting = s;
            driver = d;
            year_from = int.Parse(this.Config["Year_from"]);
            year_to = int.Parse(this.Config["Year_to"]);
            this.newFolderPath = base.setting.lambdaConfig.Params["DestFolder"];

        }
        public override ScriptState Run()
        {
            var before = Directory.GetFiles(this.Config["Driver_Path"]);
            base.State = ScriptState.Started;

            GoToUrl("baseGemelUrl");
            System.Threading.Thread.Sleep(3000);
            ElementButton.Get(setting, "Btn-knisa").Click();
            ElementButton.Get(setting, "Select-All-Kupot").Click();
            ElementButton.Get(setting, "Btn-Add").Click();
            ElementButton.Get(setting, "Btn-Download-Xml").Click();
            for (int j = year_from; j < year_to; j++)
            {
                for (int i = 1; i < 13; i++)
                {

                    DirectoryInfo d = new DirectoryInfo(this.Config["Driver_Path"]);

                    d.GetFiles().All(x => { x.Delete(); return true; });

                    if (i < 10)
                        month = "0" + i.ToString();
                    else
                        month = i.ToString();

                    ElementSelect.Get(setting, "Select-one").SelectByValue(month);
                    ElementSelect.Get(setting, "Select-two").SelectByValue(j.ToString());
                    ElementSelect.Get(setting, "Select-three").SelectByValue(month);
                    ElementSelect.Get(setting, "Select-four").SelectByValue(j.ToString());

                    ElementButton.Get(setting, "Radio-PerutMale").Click();
                    ElementButton.Get(setting, "Btn-Confirm").Click();
                    Thread.Sleep(3000);

                  

                }
            }

            return base.State;
        }

    }
}
