using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Tests
{
    internal interface IElementable
    {
        void FindElements();
    }

    internal interface IRegistrationPage : IElementable
    {
        bool Register();
    }

    internal class RegistrationPage_Facebook : IRegistrationPage, IElementable
    {
        protected const string PATH_TO_DRIVER = @"D:\Downloads\chromedriver_win32";
        private readonly string[] inputNames = new[]
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

        private RemoteWebDriver driver;
        private IWebElement[] elements;

        public RegistrationPage_Facebook()
        {
            driver = new ChromeDriver(PATH_TO_DRIVER);
            driver.Navigate().GoToUrl(inputNames[0]);
        }

        public void FindElements()
        {
            elements = new IWebElement[]
            {
                driver.FindElementByName("firstname"),
                driver.FindElementByName("lastname"),
                driver.FindElementByName("reg_email__"),
                driver.FindElementByName("reg_passwd__"),
                driver.FindElementByXPath("//*[@id=\"u_0_a\"]"),
                driver.FindElementByName("websubmit")
            };
        }

        public bool Register()
        {
            try
            {
                elements[0].SendKeys("Firstname");
                elements[1].SendKeys("Lastname");
                elements[2].SendKeys("andrii.zahoruiko@nure.ua");
                driver.FindElementByName("reg_email_confirmation__").SendKeys("andrii.zahoruiko@nure.ua");
                elements[3].SendKeys("Password1001!!!");
                elements[4].Click();
                //elements[5].Click();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}