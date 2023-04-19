using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationZionet.Projects.Practice.Scripts.Gmail
{
    public class FinderGmail
    {
        public static FinderGmail Create(IWebDriver d)
        {
            return new FinderGmail(d);
        }

        IWebDriver driver;
        public FinderGmail(IWebDriver d)
        {
            driver = d;    
        }


        

    }
}
