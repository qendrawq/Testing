using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestingSeleniumProject
{
    [TestClass]
    public class UnitTest1
    {
        protected const string PATH_TO_DRIVER = @"D:\Downloads\chromedriver_win32";
        private readonly string[] inputNames = new []
        {
            "https://uk-ua.facebook.com/",
            "firstname",
            "lastname",
            "reg_email__",
            "reg_email_confirmation__",
            "reg_passwd__",
            "birthday_day",
            "birthday_month",
            "birthday_year",
            "sex",
            "websubmit",
            "#u_x_i > div:nth-child(5) > div > div.rfloat._ohf > a",
            "<a role=\"button\" class=\"_42ft _4jy0 _4jy4 _517h _51sy mls\" href=\"#\" ajaxify=\"/cancel_soft_cliff/\" rel=\"async-post\">Не зараз</a>",
            "//*[@id=\"u_fetchstream_3_b\"]",
            "//*[@id=\"facebook\"]/body/div[4]/div[2]/div/div/div/div[3]/a[1]"

        };

        [TestMethod]
        public void Authorization()
        {
            RemoteWebDriver driver = new ChromeDriver(PATH_TO_DRIVER);
            driver.Navigate().GoToUrl(inputNames[0]);

            IWebElement[] elements =
            {
                driver.FindElementByName("firstname"),
                driver.FindElementByName("lastname"),
                driver.FindElementByName("reg_email__"),
                driver.FindElementByName("reg_passwd__"),
                driver.FindElementByName("sex"),
                driver.FindElementByName("websubmit")
            };

            elements[0].SendKeys("Firstname");
            elements[1].SendKeys("Lastname");
            elements[2].SendKeys("andrii.zahoruiko@nure.ua");
            Thread.Sleep(1000);
            driver.FindElementById("reg_email_confirmation__").SendKeys("andrii.zahoruiko@nure.ua");
            elements[3].SendKeys("Password1001!!!");
            elements[4].Click();
            elements[5].Click();
        }

    }


    [Serializable]
    public class Message
    {
        public string Sender { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }

        public string ToXml()
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stringwriter, this);
                return stringwriter.ToString();
            };
        }
    }
}

//protected readonly string[] SEARCH_TYPE_ELEMENTS = new[]
//{
//    "//a[starts-with(@title, 'Интернет')]",
//    "//a[starts-with(@title, 'Байнет')]",
//    "//a[starts-with(@title, 'Новости TUT.BY')]",
//    "//a[starts-with(@title, 'Адреса')]",
//    "//a[starts-with(@title, 'Каталог компаний TAM.BY')]",
//    "//a[starts-with(@title, 'Магазины')]",
//    "//a[starts-with(@title, 'Картинки')]"
//};

//[TestMethod]
//public void SearchFieldTest()
//{
//    RemoteWebDriver driver = new ChromeDriver(PATH_TO_DRIVER);

//    foreach (var el in SEARCH_TYPE_ELEMENTS)
//    {
//        driver.Navigate().GoToUrl(@"https://tut.by/");

//        var searchBox = driver.FindElementById("search_from_str");

//        searchBox.Click();
//        searchBox.SendKeys("systems");

//        driver.FindElementByXPath(el).Click();
//        driver.FindElementByName("search").Click();

//        var searchResults = driver.FindElementByTagName("body");
//        Assert.IsTrue(searchResults.Text.Contains("systems"));
//    }

//}

//[TestMethod]
//public void OutputToConsole()
//{
//    #region Authorization
//    RemoteWebDriver driver = new ChromeDriver(PATH_TO_DRIVER);
//    driver.Navigate().GoToUrl(@"http://mail.tut.by/");

//    var userNameField = driver.FindElementById("Username");
//    var userPassField = driver.FindElementById("Password");

//    userNameField.Clear();
//    userNameField.SendKeys("andrii.zahoruiko");

//    userPassField.Clear();
//    userPassField.SendKeys("andriizahoruiko");

//    var loginBtn = driver.FindElementByClassName("loginButton");
//    loginBtn.Click();

//    #endregion

//    #region If new exists convert to xml and output
//    Thread.Sleep(10000);

//    var messagesArea = driver.FindElementByClassName("ns-view-messages-list-box");
//    try
//    {
//        driver.FindElementByXPath("//span[starts-with(@title, 'Отметить как прочитанное')]");
//        Console.WriteLine("«+++ NEW +++»");

//        List<IWebElement> names = driver.FindElements(By.XPath("//span[@class='mail-MessageSnippet-FromText']")).ToList();
//        List<IWebElement> titles = driver.FindElements(By.XPath("//span[@class='mail-MessageSnippet-Item mail-MessageSnippet-Item_subject']")).ToList();
//        List<IWebElement> dates = driver.FindElements(By.XPath("//span[@class='mail-MessageSnippet-Item_dateText']")).ToList();

//        StringBuilder xmlMessages = new StringBuilder();
//        for (int i = 0; i < names.Count; ++i)
//        {
//            Message message = new Message()
//            {
//                Sender = names[i].Text,
//                Title = titles[i].FindElement(By.TagName("span")).Text,
//                Date = dates[i].Text
//            };
//            xmlMessages.Append(message.ToXml());
//        }

//        Console.WriteLine(xmlMessages.ToString());

//    }
//    catch
//    {
//        Console.WriteLine("«No new messages»");
//    }
//    #endregion
//}

//[TestMethod]
//public void Open_Login_DeleteMessages()
//{
//    RemoteWebDriver driver = new ChromeDriver(PATH_TO_DRIVER);
//    driver.Navigate().GoToUrl(@"http://mail.tut.by/");

//    #region Authorization

//    var userNameField = driver.FindElementById("Username");
//    var userPassField = driver.FindElementById("Password");

//    userNameField.Clear();
//    userNameField.SendKeys("andrii.zahoruiko");

//    userPassField.Clear();
//    userPassField.SendKeys("andriizahoruiko");

//    var loginBtn = driver.FindElementByClassName("loginButton");
//    loginBtn.Click();

//    #endregion

//    #region Put checked and delete

//    Thread.Sleep(10000);

//    var ratios = driver.FindElementByClassName("checkbox_view");
//    ratios.Click();

//    var deleteBtn = driver.FindElementByClassName("ns-view-toolbar-button-delete");
//    deleteBtn.Click();

//    #endregion

//    //js - user - picture
//}