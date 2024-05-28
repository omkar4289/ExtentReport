using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Runtime.Remoting.Contexts;
using TechTalk.SpecFlow;
using UnitTestProject1.Forms;
using OpenQA.Selenium;
using MongoDB.Driver.Core.Operations;

namespace UnitTestProject1
{
    [Binding]
    public class Feature1StepDefinitions : SessionInit
    {
       // public static int count=1;
        [Given(@"User opened Calculator app")]
        public void GivenUserOpenedCalculatorApp()
        {
            Operation.stSession();
        }
    

        [When(@"user entered first number")]
        public void WhenUserEnteredFirstNumber()
        {
            var Two = session.FindElementByName("Calculator").FindElementByName("Two");
            Two.Click();
        }

        [When(@"user entered second number")]
        public void WhenUserEnteredSecondNumber()
        {
           
            var Three = session.FindElementByName("Calculator").FindElementByName("Three");
            Three.Click();
        }

        [When(@"Addition performed")]
        public void WhenAdditionPerformed()
        {
            session.FindElementByName("Calculator").FindElementByName("Plus").Click();

            
           // Assert.IsTrue(false);
        }

      
        [When(@"Subtraction performed")]
        public void WhenSubtractionPerformed()
        {
            session.FindElementByName("Calculator").FindElementByName("Minus").Click();
        }

        [When(@"Multiplication performed")]
        public void WhenMultiplicationPerformed()
        {
            session.FindElementByName("Calculator").FindElementByName("Multiply by").Click();
        }

        [When(@"Division performed")]
        public void WhenDivisionPerformed()
        {
            session.FindElementByName("Calculator").FindElementByName("Divide by").Click();
            Assert.IsTrue(false);
        }



        [Then(@"User pressed Equals")]
        public void ThenUserPressedEquals()
        {
            session.FindElementByName("Calculator").FindElementByName("Equals").Click();
           // GetScreenshot(session);
            String result = session.FindElementByAccessibilityId("CalculatorResults").Text;
            Console.WriteLine(result);

        }

        //public static void GetScreenshot(string filename, WindowsDriver<WindowsElement> session)
        //{
        //    try
        //    {
                
        //            var screenshot = session.GetScreenshot();

        //        // string folderPath = @"\whatever\path";
        //        //  Directory.CreateDirectory(folderPath);

        //        var filePath = "C:\\Users\\omkarp\\source\\repos\\OPautomation\\UnitTestProject1\\TestResults\\FailedTest\\screen "+filename+".png";
        //        Console.WriteLine("................ screenshot path"+filePath);
        //        count++;

        //            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        //        Console.WriteLine("Screenshot capture ....................");
                
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Line Failed: " + e.Message);
        //        Console.WriteLine("** COULD NOT GET SCREENSHOT ***");
        //    }

        //}

    }
}
