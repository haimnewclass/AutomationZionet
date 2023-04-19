using AutomationZionet.Base.Scripts;
using AutomationZionet.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    public class ScriptGmailLogin : Script
    {
        public ScriptGmailLogin(IWebDriver d):base(d) { }
       
        public override ScriptState Run()
        {

            return base.State;
        }
    }
}
