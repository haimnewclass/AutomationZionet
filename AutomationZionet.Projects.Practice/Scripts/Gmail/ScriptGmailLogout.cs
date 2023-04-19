using AutomationZionet.Base.Scripts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    public class ScriptGmailLogout:Script
    {
        public ScriptGmailLogout(IWebDriver d) : base(d) { }
        public override ScriptState Run()
        {
            base.State = ScriptState.Started;

            GoToUrl("baseUrl");


            base.State = ScriptState.Success;

            return base.State;
        }
    }
}
