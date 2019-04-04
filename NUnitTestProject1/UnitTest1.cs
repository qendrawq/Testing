using NUnit.Framework;
using NUnit.Allure;
using System.IO;
using System;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("RegistrationTests")]
    public class Tests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            AllureExtensions.WrapSetUpTearDownParams(() => { AllureLifecycle.Instance.CleanupResultDirectory(); },
                "Cleanup Allure Results Directory");
        }

        [Test(Description = "Facebook_authorization")]
        [AllureTag("TC-1")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("unickq")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Simple")]
        public void Authorization()
        {
            RegistrationPage_Facebook page = new RegistrationPage_Facebook();
            page.FindElements();
            if (page.Register())
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Not regestrated");
            }
        }
    }
}
