using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Forms
{
    
     public class Operation : SessionInit
    {
        WindowsElement app = session.FindElementByName("Calculator");
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            StartSession(context);
        }
        [TestMethod]
        public void Addition()
        {
           var Two = app.FindElementByName("Two");
            Two.Click();
            app.FindElementByName("Plus").Click();
            var Three = app.FindElementByName("Three");
            Three.Click();
            app.FindElementByName("Equals").Click();
            String result = session.FindElementByAccessibilityId("CalculatorResults").Text;
            Console.WriteLine(result);
            session.FindElementByAccessibilityId("CalculatorResults").SendKeys(Keys.Backspace);
        }
        public static void stSession()
        {
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("platformName", "Windows");
            appiumOptions.AddAdditionalCapability("app", "Root");
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");





            session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);

            // Attaching to existing Application Window
            var applicationwindow = session.FindElementByName("Calculator");
            var topLevelWindowHandle = applicationwindow.GetAttribute("NativeWindowHandle");
            Console.WriteLine("********" + topLevelWindowHandle);
            topLevelWindowHandle = int.Parse(topLevelWindowHandle).ToString("X");   // X mandatory

            appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("appTopLevelWindow", topLevelWindowHandle);
            session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);








            if (session == null)
            {
                Console.WriteLine("Session not started");
            }
            else
            {
                Console.WriteLine("Session started");
            }
        }
    }
}
