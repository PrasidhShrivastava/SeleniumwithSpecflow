using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class TendableSiteScenariosStepDefinitions
    {
        private IWebDriver driver;

        [Given(@"I am on Tendable home page")]
        public void GivenIAmOnTendableHomePage()
        {
           driver = new ChromeDriver();
           driver.Url = "https://www.tendable.com";
            Thread.Sleep(10000);
        }

        [Then(@"I can see ""([^""]*)"" logo on top left")]
        public void ThenICanSeeLogoOnTopLeft(string logoName)
        {
           IWebElement logo = driver.FindElement(By.XPath("//a[@class='logo']"));

           Assert.IsTrue(logo.GetAttribute("alt").ToString().Contains(logoName));
          
        }

        [When(@"I click on ""([^""]*)"" menu item")]
        public void WhenIClickOnMenuItem(string menuName)
        {
            driver.FindElement(By.XPath("//a[text()=" + menuName + "]")).Click();
        }

        [Then(@"I will land on ""([^""]*)"" page")]
        public void ThenIWillLandOnPage(string menuPath)
        {
           string currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains(menuPath));
        }

        [Then(@"I see ""([^""]*)"" button on the page")]
        public void ThenISeeRequestADemoButtonOnThePage(string buttonName)
        {
          IWebElement element =  driver.FindElement(By.XPath("//div[@class='button-links']//a[text()='Request a Demo']"));

          Assert.IsTrue(element.Text.ToString().Contains(buttonName));    
        }

        [When(@"I click on ""([^""]*)"" button")]
        public void WhenIClickOnButton(string buttonName)
        {
            driver.FindElement(By.XPath("//div[@class=\"button-links-panel\"]//a[text()=" + buttonName + "]")).Click();
        }

        [When(@"I click on Marketing contact button")]
        public void WhenIClickOnMarketingContactButton()
        {
            driver.FindElement(By.XPath("//div[2]/div/div/div[1]/div/div[2]/div[2]/button")).Click();
        }

        [When(@"I fill the Contact form")]
        public void WhenIFillTheContactForm()
        {
            driver.FindElement(By.XPath("//*[@id=\"form-input-fullName\"]")).SendKeys("TestName");
            driver.FindElement(By.XPath("//*[@id=\"form-input-organisationName\"]")).SendKeys("TestOrgName");
            driver.FindElement(By.XPath("//*[@id=\"form-input-cellPhone\"]")).SendKeys("12345678");
            driver.FindElement(By.XPath("//*[@id=\"form-input-email\"]")).SendKeys("Test@test.com");

            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("form-input-jobRole")));
            dropDown.SelectByIndex(2);

            driver.FindElement(By.XPath("//*[@id=\"form-input-consentAgreed-0\"]")).Click();
        }

        [When(@"I click on Submit button")]
        public void WhenIClickOnSubmitButton()
        {
            driver.FindElement(By.XPath("//*[@id=\"contactMarketingPipedrive-163701\"]//button[text()=\"Submit\"]")).Click();
        }

        [Then(@"I will see error message as ""([^""]*)""")]
        public void ThenIWillSeeErrorMessageAs(string expectedMessage)
        {
            IWebElement elemnt = driver.FindElement(By.XPath("//*[@id=\"contactMarketingPipedrive-163701\"]/div[1]/p"));
            if (elemnt.Displayed)
            {
                string actualMessage = elemnt.Text;
                Assert.IsTrue(expectedMessage.Contains(actualMessage));
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

    }
}
