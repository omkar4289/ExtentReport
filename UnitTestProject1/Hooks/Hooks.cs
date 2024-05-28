using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UnitTestProject1.Utility;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using OpenQA.Selenium.Appium.Windows;
using System.IO;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;

namespace UnitTestProject1.Hooks
{

    [Binding]
    public sealed class Hooks : ExtentReport
    {
        private readonly IObjectContainer _container;
        

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
           
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
           // ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            String _fea = featureContext.FeatureInfo.Title;
            _feature = _extentReports.CreateTest<Feature>(_fea).AssignAuthor("Omkar");
                  //   _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
          //  Console.WriteLine("****Before feature : "+_fea);
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running after feature...");
            
        }

        [BeforeScenario("@ta")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in specflow");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running before scenario...");
            
            string scena = scenarioContext.ScenarioInfo.Title;
           // Console.WriteLine("************ Scenario is : "+scena);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title).AssignAuthor("Sachin").AssignCategory("Smoke").AssignCategory("Regression");
            //_feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Running after scenario...");
            _extentReports.Flush();
            
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");

            _feature.Pass("Login successfull");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
           // Console.WriteLine("******** stepType: "+stepType);
            string stepName = scenarioContext.StepContext.StepInfo.Text;
          //  Console.WriteLine("********* StepName: "+stepName);
            string[] s = {" "};
            String[] sarr = stepName.Split(s,StringSplitOptions.RemoveEmptyEntries);
            String sout = "";
            foreach(string a in sarr)
            {
                sout = sout + a;
            }

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message);
                }
            }



        }

    }
}
