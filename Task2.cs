using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProject1
{
    public class Tests2
    {
        WebDriver driver;

        [Test]
        public void Test1()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.dummyticket.com/dummy-ticket-for-visa-application/");

            // Select ticket type
            driver.FindElement(By.Id("product_551")).Click();

            // Fill traveler name
            driver.FindElement(By.Id("travname")).SendKeys("Hasnaa Ahmad");

            //Open and set travel date
            driver.FindElement(By.Id("dob")).Click();
            new SelectElement(driver.FindElement(By.ClassName("ui-datepicker-month"))).SelectByText("Jul");
            new SelectElement(driver.FindElement(By.ClassName("ui-datepicker-year"))).SelectByText("2025");
            driver.FindElement(By.XPath("//a[text()='25']")).Click();




            // Additional comments
            driver.FindElement(By.Id("order_comments")).SendKeys("Dummy ticket automation test");

            //selecting a gender and travel type
            driver.FindElement(By.Id("sex_2")).Click();
            driver.FindElement(By.Id("traveltype_2")).Click();



            // Billing info
            driver.FindElement(By.Id("billname")).SendKeys("Hasnaa Soliman");

            driver.FindElement(By.Id("billing_email")).SendKeys("hasnaa@example.com");
            driver.FindElement(By.Id("billing_phone")).SendKeys("01000000000");

            new SelectElement(driver.FindElement(By.Id("billing_country"))).SelectByText("Egypt");

            // Wait and close
            Thread.Sleep(5000);
            driver.Quit();



        }
        [Test]
        public void Test2()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");

            IWebElement button = driver.FindElement(By.CssSelector("[onclick=\"addElement()\"]"));
            Console.WriteLine("Tag Name: " + button.TagName);
            Console.WriteLine("Class: " + button.GetAttribute("class"));
            Console.WriteLine("ID: " + button.GetAttribute("id"));  // might be null
            Console.WriteLine("Location: " + button.Location);
            Console.WriteLine("Size: " + button.Size);
            Console.WriteLine("Is Enabled: " + button.Enabled);
        }
        [Test]
        public void Test3()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://aa-practice-test-automation.vercel.app/Pages/checkbox_Radio.html");

            IWebElement checkbox = driver.FindElement(By.Id("Ahly"));
            //check if checkbox is selected
            if (checkbox.Selected)
            {
                Console.WriteLine("Checkbox is selected.");
            }
            else

            {
                Console.WriteLine("Checkbox is not selected. Selecting it now.");
                checkbox.Click(); // Click to select the checkbox
            }

            driver.Quit();
        }
        [Test]
        public void Shadowdom1()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://books-pwakit.appspot.com/");
            driver.FindElement(By.CssSelector("book-app"))
                .GetShadowRoot()
                .FindElement(By.CssSelector("[aria-label=\"Search Books\"]"))
                .SendKeys("Killer Analytics");

            driver.FindElement(By.CssSelector("book-app"))
                .GetShadowRoot()
                .FindElement(By.CssSelector("[aria-label=\"Search Books\"]"))
                .Click();

            driver.Quit();
        }
        [Test]
        public void Shadowdom2()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/shadowdom");
            var ShadowHost = driver.FindElement(By.TagName("my-paragraph"));
            var shadowRoot = ShadowHost.GetShadowRoot();
            var shadowElement = shadowRoot.FindElement(By.CssSelector("[name=\"my-text\"]"));
            Console.WriteLine("Shadow DOM Text: " + shadowElement.Text);

            driver.Quit();
        }
        [Test]
        public void Shadowdom3()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://watir.com/examples/shadow_dom.html");
            var ShadowHost = driver.FindElement(By.Id("shadow_host"));
            var shadowRoot = ShadowHost.GetShadowRoot();
            shadowRoot.FindElement(By.CssSelector("[type=\"text\"]")).SendKeys("Shadow DOM");

            driver.Quit();

        }

        [Test]
        public void ExplicitWait()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
            driver.FindElement(By.CssSelector("#start button")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElement(By.Id("finish")).Displayed);
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("finish")));
            string text = driver.FindElement(By.Id("finish")).Text;
            Console.WriteLine("Text after wait: " + text);
            driver.Quit();
        }
            [Test]
        public void Window()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.FindElement(By.LinkText("Click Here")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.FindElement(By.TagName("h3"));
            Console.WriteLine("Current Window Title: " + driver.Title);

            driver.Quit();
        }

        [Test]
        public void Frames()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/nested_frames");
            driver.SwitchTo().Frame("frame-top").SwitchTo().Frame("frame-middle");
           string text= driver.FindElement(By.Id("content")).Text;
            Console.WriteLine("Text in the frame: " + text);
            driver.SwitchTo().DefaultContent(); // Switch back to the main content
            driver.Quit();
        }
    }
}