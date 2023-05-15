using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Base.Driver
{
    public class ChromeDriverBase:IDisposable
    {
        ChromeOptions chromeOptions;
        ChromeDriver chromeDriver;
        private bool disposedValue;

        public ChromeDriver ChromeDriver
        {
            get
            {
                return chromeDriver;
            }
        }
        public ChromeDriverBase()
        {
            chromeDriver = new ChromeDriver();
        }
        public ChromeDriverBase(ChromeOptions achromeOptions)
        {
            chromeOptions = achromeOptions;
            chromeDriver = new ChromeDriver("Driver_Path", achromeOptions);
        }

        public static ChromeDriverBase Get(ChromeOptions achromeOptions)
        {
            return new ChromeDriverBase(achromeOptions); 
        }

         void IDisposable.Dispose()
        {
           
            // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
            // ~ChromeDriverBase()
            // {
            //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            //     Dispose(disposing: false);
            // }

        }
    }
}
