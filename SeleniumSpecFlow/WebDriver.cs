using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumSpecFlow
{
    /// <summary>
    /// Class to generate WebDriver
    /// </summary>
    public static class WebDriverFactory
    {
        private static IWebDriver _webDriver;

        public static IWebDriver WebDriver
        {
            get
            {
                return _webDriver;
            }
        }

        public static void Initialize(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    _webDriver = new ChromeDriver(options);
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions firefoxBrowser = new FirefoxOptions();
                    firefoxBrowser.AddArgument("--start-maximized");
                    _webDriver = new FirefoxDriver(firefoxBrowser);
                    break;
                default: throw new Exception("Unknown browser type");
            }            
        }
        public static void CloseBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    _webDriver.Quit();
                    break;
                case BrowserType.Firefox:
                    _webDriver.Quit();
                    break;
                default: throw new Exception("Unknown browser type");
            }
        }

    }

    public enum BrowserType
    {
        Chrome,
        Firefox
    }
}
