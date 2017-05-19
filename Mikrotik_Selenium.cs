using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Collections;



static class Mikrotik_Selenium
{
    public static bool checkFirewallRuleAdd(IWebDriver driver, string ruleComment)
    {
        int count = 1;
        string comment = "", xpath;

        try
        {
            do
            {
                xpath = "//table[3]/tbody[" + count + "]/tr[1]/td[1]"; //each comment xpath
                comment = driver.FindElement(By.XPath(xpath)).GetAttribute("innerHTML");
                //Console.WriteLine(comment);
                count++;
            } while (comment != ruleComment);
            //Console.WriteLine(  "The rule has been added !"  );
            return true;
        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex.Message);
            //Console.WriteLine(  "The rule hasn't been added !"  );               
            return false;
        }
    } //Firewall Rule 已存在->true，否則->false

    public static ArrayList txtToList(string txtPlace)
    {
        StreamReader file = new StreamReader(txtPlace);  //要讀取的txt位置            
        ArrayList list = new ArrayList();
        string lineInTxt;
        //readline並依序放入list中
        while ((lineInTxt = file.ReadLine()) != null)
        {
            list.Add(lineInTxt);
        }
        return list;
    }//EX:txtPlace= "g:\\all_IP.txt";

    public static void loginListOfMikrotik(ArrayList IPlist, string name, string password)
    {
        //開啟chrome
        IWebDriver driver = new ChromeDriver();

        foreach (string Line in IPlist)
        {
            driver.Navigate().GoToUrl("http://" + Line);

            //login page-->找尋相對映的element填入值
            IWebElement elementName = driver.FindElement(By.Id("name"));
            elementName.Clear();//清除預設值admin
            elementName.SendKeys(name);

            IWebElement elementPW = driver.FindElement(By.Id("password"));
            elementPW.SendKeys(password + Keys.Enter);  //輸入完後直接Enter

            Console.ReadLine();//中斷
        }
    }//依序登入列表中Mikrotik的IP

    public static void MikrotikLogin(IWebDriver driver, string IP, string name, string password)
    {
        //連入網址            
        driver.Navigate().GoToUrl("http://" + IP);

        //login page-->找尋相對映的element填入值
        IWebElement elementName = driver.FindElement(By.Id("name"));
        elementName.Clear();//清除預設值admin
        elementName.SendKeys(name);

        IWebElement elementPW = driver.FindElement(By.Id("password"));
        elementPW.SendKeys(password + Keys.Enter);  //輸入完後直接Enter
    }

    public static void checkListOfMikrotik(ArrayList IPlist)
    {
        //開啟chrome
        IWebDriver driver = new ChromeDriver();

        //取出list中IP依序連入
        foreach (string Line in IPlist)
        {
            //連入網址
            driver.Navigate().GoToUrl("http://" + Line);
            Console.ReadLine();//中斷
        }


    }


}

