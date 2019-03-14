using Sceptor.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Sceptor.StepDefinitions
{
    [Binding]
    class CalculatorSuccess
    {
        [Given(@"I add url as (.*)")]
        public void GivenIAddUrlAsHttpJuliemr_Github_IoProtractor_Demo(String p0)
        {
            SeleneseCommands.NavigateUrl(p0);
            SeleneseCommands.SetImplicitWait(TimeSpan.FromSeconds(30));
        }

        [Given(@"I enter entered (.*) into the element (.*) calculator")]
        public void GivenIEnterEnteredIntoTheElementFirstCalculator(int p0,String p1)
        {
            SeleneseCommands.SendKeysToModel(p1, p0 + "");
        }

        

        [When(@"I give (.*) button")]
        public void WhenIGiveGoButton(String p0)
        {
            SeleneseCommands.ClickAtButtonText(p0);
        }

        [Then(@"the result must be (.*) on the label (.*)")]
        public void ThenTheResultMustBeOnTheLabelHtmlBodyDivDivFormH(String result, String xpath)
        {
            SeleneseCommands.AssertValueAtXpath(xpath, result, TimeSpan.FromSeconds(10));
        }

    }
}
