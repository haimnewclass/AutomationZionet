using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Base.WebElements
{
    public class ElementSelect : ElementBase, IElement
    {
        public ElementSelect(Setting s, string name) : base(s, name)
        {

        }

        public static ElementSelect Get(Setting s, string name)
        {

            return new ElementSelect(s, name);
        }

        //public override IWebElement WebElement
        //{
        //        get
        //        {
        //                    IWebElement ret = null;

        //                    ret = Setting.Finder.Find(Name);


        //                            return ret;
        //        }
        //}

        //public SelectElement SelectElement
        //{
        //    get
        //    {
        //SelectElement select1 = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 2)).Until(driver => driver.FindElement(By.XPath("//*[@id='selXMLHodashimMe']"))));
        //select1.SelectByValue(month);

        //    }
        //}
        //public override string Name => base.Name;
        public bool SelectByValue(string keys, bool wait = false)
        {

            if (!ExistsS)
                return false;

            SelectElementS.SelectByValue(keys);

            return true;
        }
    }
}
