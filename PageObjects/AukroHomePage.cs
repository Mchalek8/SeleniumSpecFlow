using OpenQA.Selenium;
using System;

namespace PageObjects
{
    public class AukroHomePage : BasePage
    {
        private bool aukroOfferPopUpClosed;
        private IWebDriver _webDriver;
        private string _baseUrl;
        private const string PageUrl = "http://www.aukro.cz/";

        public AukroHomePage(IWebDriver webDriver, string baseUrl)
        {
            _baseUrl = baseUrl;
            _webDriver = webDriver;            
            webDriver.Url = baseUrl + PageUrl;
            webDriver.Navigate();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            if (!this.IsVisible())
            {
                throw new InvalidOperationException(String.Format("The current browser window is not on the expected page."));
            }
        }

        #region Constructors
        #endregion

        #region Public Methods
        public bool IsVisible()
        {
            return _webDriver.Url.Contains("aukro.cz");
        }

        public bool VerifyReturnMoneyAllOffers()
        {
            var allOffers = _webDriver.FindElement(By.TagName("list-view")).FindElements(By.TagName("list-card"));
            bool result = true;

            for (int i = 1; i <= allOffers.Count; i++)
            {
                if ((i == 5)||(i==45))
                    i++;
                try
                {
                    if(!aukroOfferPopUpClosed) 
                        this.CloseAukroOfferPopUpWindow();
                    if (!_webDriver.FindElement(By.CssSelector($"list-card.propagation-bold-title:nth-child({i}) > div:nth-child(1) > div:nth-child(2) > div:nth-child(6) > div:nth-child(1) > div:nth-child(4) > span:nth-child(1) > svg-icon:nth-child(1) > div:nth-child(1) > svg:nth-child(1) > circle:nth-child(2)")).Displayed)
                        throw new Exception($"Offer with index {i} does not contain money back guarantee.");
                }
                catch (Exception)
                {
                    try
                    {
                        this.CloseAukroOfferPopUpWindow();
                        if (!_webDriver.FindElement(By.CssSelector($"list-card.hot-auction:nth-child({i}) > div:nth-child(1) > div:nth-child(2) > div:nth-child(6) > div:nth-child(1) > div:nth-child(4) > span:nth-child(1) > svg-icon:nth-child(1) > div:nth-child(1) > svg:nth-child(1) > circle:nth-child(2)")).Displayed)
                            throw new Exception($"Offer with index {i} does not contain money back guarantee.");
                    }
                    catch (Exception)
                    {

                        if (!aukroOfferPopUpClosed)
                            this.CloseAukroOfferPopUpWindow();
                        if (!_webDriver.FindElement(By.CssSelector($".product-sorting > list-view:nth-child(4) > list-card:nth-child({i}) > div:nth-child(1) > div:nth-child(2) > div:nth-child(6) > div:nth-child(1) > div:nth-child(4) > span:nth-child(1) > svg-icon:nth-child(1) > div:nth-child(1) > svg:nth-child(1) > circle:nth-child(2)")).Displayed)
                            throw new Exception($"Offer with index {i} does not contain money back guarantee.");
                    }
                }
            }
            return result;
        }

        public void CloseAukroOfferPopUpWindow()
        {
            try
            {
                if (_webDriver.FindElement(By.CssSelector("i.vertical-bottom")).Displayed)
                {
                    aukroOfferPopUpClosed = true;
                    _webDriver.FindElement(By.CssSelector("i.vertical-bottom")).Click();
                }
            }
            catch (Exception)
            {

            }
        }
        public void ClickToAgreementButton()
        {
            agreementButton.Click();
        }

        public void ClickToAukroIcon()
        {
            aukroIcon.Click();
        }
        public void ClickToCategoryButton()
        {
            categoryButton.Click();
        }

        public void ClickToCollectiblesOption()
        {
            collectiblesOption.Click();
        }

        public void ClickToAntiquesAndArtOption()
        {
            antiquesAndArtOption.Click();
        }

        public void SelectReturnMoneyGuaranteeCheckbox()
        {
            var elem = _webDriver.FindElement(By.CssSelector(".filter-sidebar-wrapper > filter:nth-child(1) > parameters:nth-child(2) > filter-parameter-attribute:nth-child(3) > span:nth-child(1)"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            string title = (string)js.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
            returnMoneyGuaranteeCheckbox.Click();
        }

        public void SelectFreeShippingCheckbox()
        {
            freeShippingCheckbox.Click();
        }

        #endregion

        #region Private
        private IWebElement agreementButton { get { return _webDriver.FindElement(By.CssSelector(".fc-cta-consent")); } }
        private IWebElement aukroIcon { get { return _webDriver.FindElement(By.CssSelector("#Layer_1")); } }
        private IWebElement categoryButton { get { return _webDriver.FindElement(By.CssSelector("#ssr-done > app-header > div:nth-child(3) > div > div.display-inline-block-min-tablet > button")); } }
        private IWebElement collectiblesOption { get { return _webDriver.FindElement(By.CssSelector("div.nav-section:nth-child(4) > top-level-category:nth-child(1) > div:nth-child(1) > a:nth-child(2)")); } }
        private IWebElement antiquesAndArtOption { get { return _webDriver.FindElement(By.CssSelector("div.nav-section:nth-child(4) > top-level-category:nth-child(2) > div:nth-child(1) > a:nth-child(2)")); } }
        private IWebElement returnMoneyGuaranteeCheckbox { get { return _webDriver.FindElement(By.CssSelector("#mat-checkbox-6 > label:nth-child(1) > span:nth-child(2) > span:nth-child(2)")); } }
        private IWebElement freeShippingCheckbox { get { return _webDriver.FindElement(By.CssSelector("#mat-checkbox-7 > label:nth-child(1) > span:nth-child(2) > span:nth-child(2)")); } }
        #endregion
    }
}
