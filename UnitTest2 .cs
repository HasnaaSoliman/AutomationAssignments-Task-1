using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class DummyTicketAutomation
    {
       
       
        
        [Test]
        public void Test1()
        {
            WebDriver driver;


            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.dummyticket.com/dummy-ticket-for-visa-application/");

            // Select ticket type
            driver.FindElement(By.Id("product_551")).Click();

            // Fill traveler name
            driver.FindElement(By.Id("travname")).SendKeys("Hasnaa Ahmad");

            // Open and set travel date
            driver.FindElement(By.Id("traveldate")).Click();
            new SelectElement(driver.FindElement(By.ClassName("ui-datepicker-month"))).SelectByText("Jul");
            new SelectElement(driver.FindElement(By.ClassName("ui-datepicker-year"))).SelectByText("2025");
            driver.FindElement(By.XPath("//a[text()='25']")).Click();

            // Additional comments
            driver.FindElement(By.Id("order_comments")).SendKeys("Dummy ticket automation test");

            // Billing info
            driver.FindElement(By.Id("billing_first_name")).SendKeys("Hasnaa");
            driver.FindElement(By.Id("billing_last_name")).SendKeys("Ahmad");
            driver.FindElement(By.Id("billing_email")).SendKeys("hasnaa@example.com");
            driver.FindElement(By.Id("billing_phone")).SendKeys("01000000000");

            new SelectElement(driver.FindElement(By.Id("billing_country"))).SelectByText("Egypt");

            // Wait and close
            Thread.Sleep(5000);
            driver.Quit();
        }


    }
}