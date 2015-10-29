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
    public class ThankYouPage
    {
        private IWebDriver driver;

        public ThankYouPage (IWebDriver driver)
        {
            this.driver = driver;   
        }

    }
}
