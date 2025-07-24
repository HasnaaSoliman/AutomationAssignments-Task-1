using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {
        WebDriver driver;

        [Test]
        public void Testcase()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://example.com/");
            string title = driver.Title;
            Console.WriteLine("Page title : " + title);

            string url = driver.Url;
            Console.WriteLine("Page Url: " + url);


            String pageSource = driver.PageSource;
            Console.WriteLine("Page Source: " + pageSource); // Print first 100 characters of page source

            Console.WriteLine("Window ID: " + driver.CurrentWindowHandle);

            driver.Navigate().GoToUrl("https://www.selenium.dev");
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();

            // Get and print the window size
            var size = driver.Manage().Window.Size;
            Console.WriteLine($"Window Size-width: {size.Width}, Height {size.Height} ");

            // Get and print the window position
            var position = driver.Manage().Window.Position;
            Console.WriteLine($"Window Position-X: {position.X}, Y {position.Y} ");

            // Resize the window to Width = 1024, Height = 768
            driver.Manage().Window.Size = new System.Drawing.Size(1024, 768);
            Console.WriteLine("Window resized to 1024x768.");

            // Move the window to position X = 200, Y = 150
            driver.Manage().Window.Position = new System.Drawing.Point(200, 150);
            Console.WriteLine("Window moved to position X=200, Y=150.");

            System.Threading.Thread.Sleep(3000);

            driver.Manage().Window.Maximize();
            driver.Manage().Window.FullScreen();

            driver.Close();

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://example.com/");
            Console.WriteLine("Opened Example website.");

            driver.Quit();
            Console.WriteLine("Browser session quit.");

            //driver.Quit();
        }
        public void Testcase2()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://web.facebook.com/r.php?entry_point=login&_rdc=1&_rdr#");

            Thread.Sleep(3000);

            // Locate by ID
            driver.FindElement(By.Id("u_0_b")).SendKeys("Hasnaa");
            // Locate by Name
            driver.FindElement(By.Name("lastname")).SendKeys("Soliman");
            // Locate by ClassName 
            driver.FindElement(By.ClassName("inputtext")).SendKeys("test@endava.com");


            // Locate by XPath
            driver.FindElement(By.XPath("//input[@name='reg_passwd__']")).SendKeys("Test@123");
            // Locate by CSS Selector
            driver.FindElement(By.CssSelector("select#day")).SendKeys("10"); // Day dropdown menu

            IWebElement firstInput = driver.FindElement(By.TagName("input"));
            Console.WriteLine("First input tag placeholder: " + firstInput.GetAttribute("placeholder"));

            Thread.Sleep(3000);
            driver.Quit();


        }


    }
}