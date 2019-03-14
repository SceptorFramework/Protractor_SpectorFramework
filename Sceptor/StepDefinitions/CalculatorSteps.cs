
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Protractor;
using Sceptor.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;


namespace Sceptor.StepDefinitions
{
    [Binding]
    public sealed class CalculatorSteps 
    {
       

        
       
      

        [Given(@"The url as (.*)")]
        public void Start(String p0) {

                SeleneseCommands.NavigateUrl(p0);
                SeleneseCommands.SetImplicitWait(TimeSpan.FromSeconds(30));
            
            
        }


        [Given(@"I have entered (.*) into the element (.*) calculator")]
        public void GivenIHaveEnteredIntoTheElementFirstCalculator(int p0, String p1)
        {


            SeleneseCommands.SendKeysToModel(p1, p0 + "");
        }

       
        [When("I press (.*) button")]
        public void WhenIPressAdd(String p0)
        {
            SeleneseCommands.ClickAtButtonText(p0);
        }

        [Then("the result should be (.*) on the label (.*)")]
        public void ThenTheResultShouldBe(String result, String xpath)
        {
            SeleneseCommands.AssertValueAtXpath(xpath, result, TimeSpan.FromSeconds(10));
        }
    }
}
