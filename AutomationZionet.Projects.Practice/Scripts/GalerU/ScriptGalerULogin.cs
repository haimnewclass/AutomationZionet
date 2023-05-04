using AutomationZionet.Base.Scripts;
using AutomationZionet.Base.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Projects.Practice.Scripts.GalerU
{
    public class ScriptGalerULogin : Script
    {
        public ScriptGalerULogin(IWebDriver d) : base(d) { }

        public override ScriptState Run()
        {

            GalerUSetting setting = new GalerUSetting(driver, new FinderGalerU(driver));
            base.State = ScriptState.Started;

            GoToUrl("GalerU");

            ElementButton.Get(setting, "Btn-Login").Click();

            if (ElementInput.Get(setting, "Input-User").Exists)
            {
                ElementInput.Get(setting, "Input-User").SendKeys(setting.galerUConfig["User"]);
                ElementButton.Get(setting, "Btn-Next").Click();
            }
            else { return base.State; }

            if (ElementInput.Get(setting, "Input-Psw").Exists)
            {
                ElementInput.Get(setting, "Input-Psw").SendKeys(setting.galerUConfig["Password"]);
                ElementButton.Get(setting, "Btn-Psw-Next").Click();
            }
            else { return base.State; }

            return base.State;
            // Wait(2 * 1000);
        }
    }
}
