using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace SampleAppTests
{
    public class ContactPage
    {
        private IWebDriver driver;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);           
        }

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement lastName { get; set; }

        [FindsBy(How = How.Id, Using = "EmailAddress")]
        private IWebElement emailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "Age")]
        private IWebElement Age { get; set; }

        [FindsBy(How = How.Id, Using = "State")]
        private IWebElement State { get; set; }

        [FindsBy(How = How.Id, Using = "County")]
        private IWebElement County { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn")]
        public IWebElement formSubmit { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".field-validation-error")]
        public IWebElement Errors { get; set; }

        [FindsBy(How = How.Name, Using = "data-valmsg-for ='FirstName'")]
        public IWebElement firstNameErrors { get; set; }

        public ContactPage typeFirstName(string firstname)
        {
            FirstName.SendKeys(firstname);
            return this;
        }

        public ContactPage typeLastName (string lastname)
        {
            lastName.SendKeys(lastname);
            return this;    
        }

        public ContactPage typeAge (int age)
        {
            Age.SendKeys(age.ToString());
            return this;
        }

        public ContactPage typeEmailAddress(string email)
        {
            emailAddress.SendKeys(email);
            return this;
        }

        public ContactPage selectState(string state)
        {
            SelectElement selector = new SelectElement(State);
            selector.SelectByText(state);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var e = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.Id("County"), "--Select"));
            return this;
        }

        public ContactPage selectCounty(string county)
        {
            SelectElement selector = new SelectElement(County);
            selector.SelectByText(county);
            return this;
        }

        public ThankYouPage submitFormSuccess()
        {
            formSubmit.Submit();
            return new ThankYouPage(driver);
        }

        public ContactPage submitFormFailure()
        {
            formSubmit.Submit();
            return new ContactPage(driver); 
        }

        public ContactPage findFirstNameErrors()
        {
            firstNameErrors.ToString();
            return this;
        }
        
        public ThankYouPage submitTrueContactAs()
        {
            return submitFormSuccess();
        }

        public ContactPage submitBadContactAs()
        {
           return submitFormFailure();
        }

    }
}
