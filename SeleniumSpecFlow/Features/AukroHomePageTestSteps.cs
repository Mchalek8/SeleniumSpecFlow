using PageObjects;
using TechTalk.SpecFlow;
using SeleniumSpecFlow.metadata;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumSpecFlow.Features
{
    [Binding]
    public class AukroHomePageTestSteps : BaseSteps
    {
        [Given(@"Load Current page")]
        public void GivenLoadCurrentPage()
        {
            CurrentPage = new AukroHomePage(WebDriverFactory.WebDriver, string.Empty);
        }

        [Given(@"Close pop up Agreement")]
        public void GivenClosePopUpAgreement()
        {
            if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
            ((AukroHomePage)this.CurrentPage).ClickToAgreementButton();
        }

        [Given(@"Close pop up Aukro Offer")]
        public void GivenClosePopUpAukroOffer()
        {
            if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
            ((AukroHomePage)this.CurrentPage).ClickToAukroIcon();
        }


        [When(@"I select Category Button")]
        public void WhenISelectCategoryButton()
        {
            if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
            ((AukroHomePage)this.CurrentPage).ClickToCategoryButton();
        }

        [When(@"I select ""(.*)"" Option")]
        public void WhenISelectOption(string aukroOption)
        {
            switch (aukroOption)
            {
                case "Collectibles":
                    if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
                    ((AukroHomePage)this.CurrentPage).ClickToCollectiblesOption();
                    break;
                case "AntiquesAndArt":
                    if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
                    ((AukroHomePage)this.CurrentPage).ClickToAntiquesAndArtOption();
                    break;
                default:
                    throw new Exception(string.Format("{0} not supported value.", aukroOption));
            }
        }

        [When(@"I select Parameter Options Checkboxes")]
        public void WhenISelectParameterOptionsCheckboxes(Table table)
        {
            if (table.ContainsColumn("ReturnMoneyGuarantee") && table.Rows[0]["ReturnMoneyGuarantee"].Contains("check"))
            {
                if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
                ((AukroHomePage)this.CurrentPage).SelectReturnMoneyGuaranteeCheckbox();
            }

            if (table.ContainsColumn("FreeShipping ") && table.Rows[0]["FreeShipping"].Contains("check"))
            {
                if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
                ((AukroHomePage)this.CurrentPage).SelectFreeShippingCheckbox();
            }

            if (table.ContainsColumn("PersonalTakeover ") && table.Rows[0]["PersonalTakeover"].Contains("check"))
            {
                if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
                // ToDO PersonalTakeover
            }

            if (table.ContainsColumn("TransportWithCashOnDelivery ") && table.Rows[0]["TransportWithCashOnDelivery"].Contains("check"))
            {
                if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
                // ToDO TransportWithCashOnDelivery
            }

            if (table.ContainsColumn("AukroPlus") && table.Rows[0]["AukroPlus"].Contains("check"))
            {
                if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
                // ToDO AukroPlus
            }
        }

        [Then(@"Verify that all offers include Aukro Return Money Guarantee")]
        public void ThenVerifyThatAllOffersIncludeAukroReturnMoneyGuarantee()
        {
            if (!(CurrentPage is AukroHomePage)) throw new System.Exception("Bad page");
            Assert.IsTrue(((AukroHomePage)this.CurrentPage).VerifyReturnMoneyAllOffers(), "Aukro money return guarantee is not present for all offers.");
        }
    }
}
