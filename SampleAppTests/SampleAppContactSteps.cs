using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace SampleAppTests
{
    [Binding]
    public class SampleAppContactSteps
    {
        ContactPage page;
        FirefoxDriver firefox; 

        [SetUp]
        public void setUp()
        {
            firefox = new FirefoxDriver();
            firefox.Navigate().GoToUrl("http://sample.com/Home/Contact");
            page = new ContactPage(firefox);
        }

        [Given(@"I have entered correct information in all fields available")]
        public void GivenIHaveEnteredCorrectInformationInAllFieldsAvailable()
        {
            setUp();                
            page.typeFirstName("Olufikunmi");
            page.typeLastName("Ajayi");
            page.typeEmailAddress("oajayi@captechconsulting.com");
            page.typeAge(22);
            page.selectState("Nawth Carolina");
            page.selectCounty("Wake");

        }
        
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            page.submitTrueContactAs();
        }
        
        [Then(@"I should see the Thank You page")]
        public void ThenIShouldSeeTheThankYouPage()
        {
            Assert.AreEqual("Thanks - My ASP.NET Application", firefox.Title);
            tearDown();
        }

        [Given(@"I have entered invalid first name")]
        public void GivenIHaveEnteredInvalidFirstName()
        {
            setUp();
            page.typeFirstName("abcdefghijklmnopqrstuvwxyza");
            page.typeLastName("Ajayi");
            page.typeEmailAddress("oajayi@captechconsulting.com");
            page.typeAge(22);
            page.selectState("Nawth Carolina");
            page.selectCounty("Wake");
        }

        [When(@"I submit invalid information")]
        public void WhenISubmitInvalidInformation()
        {
            page.submitBadContactAs();

        }

        [Then(@"I should remain on the Contact Page and see a validation error")]
        public void ThenIShouldRemainOnTheContactPageAndSeeAValidationError()
        {
            //page.findAllErrors();
            Assert.AreEqual(firefox.Title, "Contact - My ASP.NET Application");
            Assert.IsNotNull(page.firstNameErrors);
            tearDown();
        }

        [Given(@"I have entered no first name")]
        public void GivenIHaveEnteredNoFirstName()
        {
            setUp();
            page.typeFirstName("");
            page.typeLastName("Ajayi");
            page.typeEmailAddress("oajayi@captechconsulting.com");
            page.typeAge(22);
            page.selectState("Nawth Carolina");
            page.selectCounty("Wake");
        }

        [TearDown]
        public void tearDown()
        {
            firefox.Quit();
        }
    }
}
