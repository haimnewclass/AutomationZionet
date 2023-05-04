using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationZionet.Projects.Practice.Scripts.GalerU;

namespace AutomationZionet.Projects.Practice.Scripts.GalerU
{
    public class Runner
    {
        public static void Run1()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                ScriptGalerULogin login = new Projects.Practice.Scripts.GalerU.ScriptGalerULogin(driver);
                login.Run();
            }
        }
    }
}