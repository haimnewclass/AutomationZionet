using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomationZionet.Base.Scripts;


namespace AutomationZionet.Base.WebElements
{
    public interface IElement
    { 
        bool Exists { get; }
        bool Hidden { get; }
    }
    
    public class ElementBase
    {
        public ElementBase(Setting s,string name)
        {
            Setting = s;
            Name = name;
        }
        public readonly string Name ;
        public Setting Setting;
        public IWebElement WebElement
        {
            get
            {
                IWebElement ret = null;

                ret = Setting.Finder.Find(Name);


                return ret;
            }
        }

        public IWebElement WebElementW
        {
            get
            {
                IWebElement ret = null;

                ret = Setting.Finder.FindW(Name);

              

                return ret;
            }
        }


        public virtual bool ExistsW
        {
            get {

                return WebElementW == null ? false : true;
            }
        }

        public virtual bool Exists
        {
            get
            {

                return WebElement == null ? false : true;
            }
        }


        public virtual bool Hidden
        {
            get { return false; }
        }



    }
}
