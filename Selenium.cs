using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.IO;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.ObjectModel;
namespace seleniumTest1
{
    class Selenium
    {
        public static void switchWindow(IWebDriver driver)
        {
            Thread.Sleep(3000);
            var handles = driver.WindowHandles;
            //尋覽至最後一個
            foreach (var handle in handles)
            {
                driver.SwitchTo().Window(handle);
            }
        }//切換至另一視窗

        public static void implicitWait(IWebDriver driver)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(3000);//1sec
            driver.Manage().Timeouts().ImplicitWait = timeout;
        }//整個程式的預設等待，只要有任何東西找不到就自動等待

        public static void explicitWait1sec(IWebDriver driver, string element, string elementType)
        {
            //教學https://www.youtube.com/watch?v=0eSORVemv80&list=PL6tu16kXT9PoIHrwaqkBitAmjlrG1Bgxp&index=3
            //the timeout to wait
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);//1sec
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            if (elementType == "Id")
            {
                wait.Until(ExpectedConditions
                .ElementToBeClickable(By.Id(element)));
            }
            if (elementType == "Name")
            {
                wait.Until(ExpectedConditions
                   .ElementToBeClickable(By.Name(element)));
            }
            if (elementType == "LinkText")
            {
                wait.Until(ExpectedConditions
                .ElementToBeClickable(By.LinkText(element)));
            }
            if (elementType == "ClassName")
            {
                wait.Until(ExpectedConditions
                .ElementToBeClickable(By.ClassName(element)));
            }
            if (elementType == "XPath")
            {
                wait.Until(ExpectedConditions
                .ElementToBeClickable(By.XPath(element)));
            }
            else
            {
                Console.WriteLine("Element Type not include !");
            }
        }//Id, XPath, ClassName, LinkText, Name

        public static void clickElement(IWebDriver driver, string element, string elementType)
        {
            if (elementType == "Id")
            {
                IWebElement menuTerminal = driver.FindElement(By.Id(element));
                menuTerminal.Click();
            }
            if (elementType == "Name")
            {
                IWebElement menuTerminal = driver.FindElement(By.Name(element));
                menuTerminal.Click();
            }
            if (elementType == "LinkText")
            {
                IWebElement menuTerminal = driver.FindElement(By.LinkText(element));
                menuTerminal.Click();
            }
            if (elementType == "ClassName")
            {
                IWebElement menuTerminal = driver.FindElement(By.ClassName(element));
                menuTerminal.Click();
            }
            if (elementType == "XPath")
            {
                IWebElement menuTerminal = driver.FindElement(By.XPath(element));
                menuTerminal.Click();
            }
        }//Id, XPath, ClassName, LinkText, Name
    }
}
