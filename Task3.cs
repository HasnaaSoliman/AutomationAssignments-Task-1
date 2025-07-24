using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V136.Network;
using OpenQA.Selenium.Support.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProject1
{
    public class LoginTests1
    {
        WebDriver driver;
        WebDriverWait wait;
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
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
        }

        [Test]
        public void ValidLogin()
        {
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Logged In Successfully", driver.FindElement(By.ClassName("post-title")).Text, "Login was not successful.");

        }

        [Test]
        public void inValidUsername()

        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.Id("username")).SendKeys("student33");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();

            string errormessage =driver.FindElement(By.Id("error")).Text;
            wait.Until(drv => drv.FindElement(By.Id("error")).Displayed);

            Assert.That(errormessage, Is.EqualTo("Your username is invalid!"));

            //Assert.IsTrue(errorMessage.Contains("Your username is invalid!"), "Expected error message not found.");

        }

        [Test]
        public void inValidPassword()
        {
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("Test123");
            driver.FindElement(By.Id("submit")).Click();

            string expectedUrl = "https://practicetestautomation.com/practice-test-login/";
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
        [OneTimeTearDown]
        public void oneTimeTeardown()
        {
            driver.Quit();
        }

    }
}