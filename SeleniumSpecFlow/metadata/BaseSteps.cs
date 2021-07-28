using PageObjects;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlow.metadata
{
    [Binding]
    public class BaseSteps
    {
        public BasePage CurrentPage { get; set; }

        [BeforeTestRun]
        public static void BeforeTest()
        {
            //WebDriverFactory.Initialize(BrowserType.Chrome);
            WebDriverFactory.Initialize(BrowserType.Firefox);
        }
        [AfterScenario]
        public static void AfterScenario()
        {
            //WebDriverFactory.CloseBrowser(BrowserType.Chrome);
            WebDriverFactory.CloseBrowser(BrowserType.Firefox);
        }
    }
}