using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Sceptor.BaseClass
{
    [Binding]
    public sealed class Extent
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        static ExtentReports extent;
        static ExtentTest feature;
        static ExtentTest scenario;
        static ExtentTest scenarioStep;
        static Status testStatus;
        static Exception exception;


        [BeforeTestRun]
        public static void BeforeScenario()
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory +"Reports";

            if (System.IO.Directory.Exists(path)) {
                System.IO.Directory.Delete(path);
            }
            System.IO.Directory.CreateDirectory(path);


            var htmlReporter = new ExtentHtmlReporter(path + "\\extent.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
            
           //feature =  extent.CreateTest<Feature>("Login");
           //scenario =  feature.CreateNode<Scenario>("Admin");
            //scenario.CreateNode<Given>("Navigate");
            
        }

        [BeforeFeature]
        public static void beforeTesst()
        {
            feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }
        [BeforeScenario]
        public void BeforeScenarioa()
        {
            String title = ScenarioContext.Current.ScenarioInfo.Title;
            scenario = feature.CreateNode<Scenario>(title);
        }

        [AfterTestRun]
        public static void AfterScenario()
        {
            extent.Flush();
        }
        [BeforeStep]
        public void beforeStep()
        {

           

          

            
            
            //Console.WriteLine(step + "");
        }
        
        
        [AfterStep]
        public void afterStep()
        {
            var step = ScenarioContext.Current.StepContext.StepInfo.Text;
            var definition = ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType;



            if (definition.Equals(TechTalk.SpecFlow.Bindings.StepDefinitionType.Given))
            {
                scenarioStep = scenario.CreateNode<Given>(step);
            }
            else if (definition.Equals(TechTalk.SpecFlow.Bindings.StepDefinitionType.When))
            {
                scenarioStep =  scenario.CreateNode<When>(step);
            }
            else
            {

                scenarioStep =  scenario.CreateNode<Then>(step);
            }
            // testStatus = scenario.Status;

            if (testStatus.Equals(Status.Fail))
            {
                
                scenarioStep.Log(Status.Fail, exception.StackTrace);
                scenarioStep.Fail(exception.Source + "\n" + exception.StackTrace);
                testStatus = Status.Pass;
            }

        }
        
        internal static  void generateError(Exception e)
        {
           
            testStatus = Status.Fail;
            exception = e;
        }

        [AfterTestRun]
        public static void driverQuit() {
            SeleneseCommands.driverQuit();

        }
    }
}
