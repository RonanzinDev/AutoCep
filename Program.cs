using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace WebScraping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o cep: ");
            int cep = int.Parse(Console.ReadLine());
            using (IWebDriver driver = new FirefoxDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
                Thread.Sleep(3000);
                driver.FindElement(By.Name("endereco"))
                .SendKeys(cep + Keys.Enter);
                Thread.Sleep(5000);
                IWebElement result = driver.FindElement(By.TagName("body"));
                Screenshot screenshot = (result as ITakesScreenshot).GetScreenshot();
                screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);

                //29182-578  
            }
        }
    }
}