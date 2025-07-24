using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V136.Network;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProject1
{
    [SuppressMessage("Nunit.Analyzers", "Nunit1032:FieldIsNotDisposed",Justification ="driver.quit() is used for Disposal.")]
    public class LoginTests2
    {
        WebDriver driver;
        [OneTimeSetUp]
        public void oneTimeSetup()
        {
            driver = new ChromeDriver();
            Console.WriteLine("One-time setup completed.");
            // This method can be used for one-time setup if needed
        }

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
        }
        [Category("Valid")]
        [Category("Regression test")]
        [Test,Order(1)]
        public void ValidLogin()
        {
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("[type=\"submit\"]")).Click();
            // Optionally, you can add an assertion to verify successful login
            Thread.Sleep(3000);
            Assert.AreEqual("https://the-internet.herokuapp.com/secure", driver.Url, " Expected URL did not match.");

        }
        [Category("inValid")]
        [Category("Regression test")]
        [Test,Order(2)]
        public void inValidUsername()
        { 
            driver.FindElement(By.Id("username")).SendKeys("Noor");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("[type=\"submit\"]")).Click();
            string errorMessage = driver.FindElement(By.Id("flash")).Text;
            Assert.IsTrue(errorMessage.Contains("Your username is invalid!"), "Expected error message not found.");

        }
        [Category("inValid")]
        [Category("Regression test")]
        [Test, Order(3)]
        public void inValidPassword()
        {
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("Test123");
            driver.FindElement(By.CssSelector("[type=\"submit\"]")).Click();

            string expectedUrl= "https://the-internet.herokuapp.com/login";
            Assert.That(driver.Url, Is.EqualTo(expectedUrl), "Expected URL did not match after invalid password login attempt.");

        }
        [TearDown]
        public void TearDown()
        {
            // Wait for a few seconds to see the result
            Thread.Sleep(3000);
            // Close the browser
            driver.Quit();
        }
    }
}