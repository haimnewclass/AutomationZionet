using AutomationZionet.Base.Scripts;
using AutomationZionet.Projects.Practice.Scripts.Gmail;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Projects.Practice.Scripts.GalerU
{
    public abstract class Script : ScriptBase
    {
        public Script(IWebDriver d) : base(d)
        {
            base.Config = new GalerUConfig();
            base.URLs = new GalerUURL();
        }
    }
}