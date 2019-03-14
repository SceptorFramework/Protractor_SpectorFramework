using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceptor.BaseClass
{
    public class DriverInitialize
    {
        static IWebDriver driver;
        static NgWebDriver ngDriver;
        private static String driverName = "Chrome";

        public void SetDriver(String driverName) {
            DriverInitialize.driverName = driverName;
        }


        private static IWebDriver StartDriver() {
            if (driverName.Contains("Chrome"))
            {
                driver = new ChromeDriver();
                return driver;
            }
            else if (driverName.Contains("Firefox"))
            {
                driver = new FirefoxDriver();
                return driver;

            }
            else {
                driver = new InternetExplorerDriver();
                return driver;
            }


        }


        private static void InitiateDriver() {
            IWebDriver driverStart = StartDriver();
            ngDriver = new NgWebDriver(driverStart);
           
        }

        public static IWebDriver getDriver() {
            if (ngDriver == null) {
                InitiateDriver();
            }
             return ngDriver;
        }
    }
}
