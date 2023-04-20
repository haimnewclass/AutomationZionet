using AutomationZionet.Base.Scripts;
using AutomationZionet.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomationZionet.Base.WebElements;
using AutomationZionet.Base;

namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    public class ScriptGmailLogin : Script
    {
        public ScriptGmailLogin(IWebDriver d):base(d) { }
       
        public override ScriptState Run()
        {

            GmailSetting setting = new GmailSetting(driver, new FinderGmail(driver));
            base.State = ScriptState.Started;

            GoToUrl("baseUrl");

            ElementInput.Get(setting, "Input-User").SendKeys(setting.gmailConfig["User"]);
            ElementButton.Get(setting, "Btn-Next").Click();

            ElementInput.Get(setting, "Input-Psw").SendKeys(setting.gmailConfig["Password"]);
            ElementButton.Get(setting, "Btn-Psw-Next").Click();

            Wait(30 * 1000);
            if (ElementButton.Get(setting, "Btn-NotNow").Exists)
                ElementButton.Get(setting, "Btn-NotNow").Click();

            GoToUrl("google");
            ElementInput.Get(setting, "Input-google").SendKeys(setting.gmailConfig["SearchLogiosteam"]);
            ElementButton.Get(setting, "Btn-Google-Search").Click();
            
            base.State = ScriptState.Success;

            return base.State;
        }
    }
}
