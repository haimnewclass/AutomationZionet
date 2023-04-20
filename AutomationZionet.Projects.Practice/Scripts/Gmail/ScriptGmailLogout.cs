using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Base.WebElements;
using AutomationZionet.Base;
namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    public class ScriptGmailLogout:Script
    {
        public ScriptGmailLogout(IWebDriver d) : base(d) { }
        public override ScriptState Run()
        {
            Setting setting = Setting.Init(driver, new FinderGmail(driver));
            base.State = ScriptState.Started;

            GoToUrl("baseUrl");

            bool sentKey = ElementInput.Get(setting, "Input-User").SendKeys("haim");


            
            base.State = ScriptState.Success;

            return base.State;
        }
    }
}
