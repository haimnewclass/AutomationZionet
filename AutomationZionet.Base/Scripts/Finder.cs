using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationZionet.Base.Scripts
{
    public class Finder
    {
        public Finder(IWebDriver d)
        {
            driver = d;
        }
        protected IWebDriver driver;
        public ConfigParams Elements = new ConfigParams();

        public IWebElement Find(string elementName)
        {
            IWebElement element = null;

            if (!Elements.Params.ContainsKey(elementName))
                return null;
            try
            {
                element = new WebDriverWait(driver, new TimeSpan(0, 0, 1)).Until(driver => driver.FindElement(By.XPath(Elements[elementName])));
            }
            catch (OpenQA.Selenium.NoSuchElementException ex)
            {
                element = null;
            }
            catch (Exception ex)
            {
                element = null;
            }
            return element;
        }


        public SelectElement FindSelectElement(string elementName)
        {
            SelectElement element = null;
            try
            {
            if (!Elements.Params.ContainsKey(elementName))
                element = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 0, 1)).Until(driver => driver.FindElement(By.XPath(Elements[elementName]))));
            }
            catch (OpenQA.Selenium.NoSuchElementException ex)
            {
                element = null;
            }
            catch (Exception ex)
            {
                element = null;
            }

            return element;
        }
        public SelectElement FindS(string elementName)
        {

            if (!Elements.Params.ContainsKey(elementName))
                return null;

            SelectElement element = new SelectElement(new WebDriverWait(driver, new TimeSpan(0, 1, 0)).Until(driver => driver.FindElement(By.XPath(Elements[elementName]))));

            return element;

        }
        public IWebElement FindW(string elementName)
        {

            if (!Elements.Params.ContainsKey(elementName))
                return null;

            IWebElement element = new WebDriverWait(driver, new TimeSpan(0, 1, 0)).Until(driver => driver.FindElement(By.XPath(Elements[elementName])));

            return element;
            
        }

        
    }
}
