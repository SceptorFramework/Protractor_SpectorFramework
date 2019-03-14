using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceptor.BaseClass
{

    public class SeleneseCommands : DriverInitialize
    {
        public static void NavigateUrl(String URL) {
            try
            {
                getDriver().Url = URL;
            }
            catch (Exception e)
            {
                Extent.generateError(e);

            }
        }

        public static void SetImplicitWait(TimeSpan time) {
            try
            {
                getDriver().Manage().Timeouts().ImplicitWait = time;
            }
            catch (Exception e)
            {
                Extent.generateError(e);

            }

        }

        public static void SendKeysToModel(String model, String keys) {
            try
            {
                getDriver().FindElement(NgBy.Model(model)).SendKeys(keys);
            }
            catch (Exception e)
            {
                Extent.generateError(e);

            }
        }

        public static void ClickAtButtonText(String xpath) {
            try
            {
                getDriver().FindElement(By.XPath("//*[contains(text(),'" + xpath + "')]")).Click();
            }
            catch (Exception e)
            {
                Extent.generateError(e);

            }
        }

        public static void AssertValueAtXpath(String xpath, String expected, TimeSpan time) {
            try
            {
                IWebElement element = getDriver().FindElement(By.XPath(xpath));

                WebDriverWait wait = new WebDriverWait(getDriver(), time);
                wait.Until(ExpectedConditions.TextToBePresentInElement(element, expected));
            }
            catch (Exception e) {
                Extent.generateError(e);
                throw e;

            }

        }

        public static void driverQuit() {
            getDriver().Quit();
        }
    }
}
