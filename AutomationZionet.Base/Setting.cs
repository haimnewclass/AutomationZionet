using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomationZionet.Base.Scripts;

namespace AutomationZionet.Base
{
    public class Setting
    {

        public Setting(IWebDriver d, Finder f)
        {
            driver = d;
            Finder = f;
        }
        public static Setting Init(IWebDriver d,Finder f)
        {
            return new Setting(d,f);
        }

        public Finder Finder;
        public IWebDriver driver { get; }
        
    }
}
