using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Rosetta.Framework;
using Rosetta.Framework.Pages;

namespace Rosetta.Tests.SimpleTests
{
    [TestFixture]
    public class Hote_WriteReviewAndVerifyInvoice : TestBase
    {
        [Test]
        public void WriteReviewAndCheckInvoiceForHotel()
        {
	        const string userName = "user@phptravels.com";
	        const string password = "demouser";
			const string swissotelLePlazaBasel = "Swissotel Le Plaza Basel";
			string expectedDepositNow = "USD $11";
	        string expectedTaxVat = "USD $10";
	        string expectedTotalAmount = "USD $110";
			Dictionary<string, string> raitingData = new Dictionary<string, string> { { "Clean", "10" }, { "Staff", "2" } };
	        string comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

	        Initialize();
			Pages.HomePage.Login(userName, password);

			// Select Invoice for 'Swissotel Le Plaza Basel' and compare Deposit, Tax and Total prices;
			Pages.PageMyAccount.SelectInvoice(swissotelLePlazaBasel);
	        string depositeNowprice =  Pages.PageInvoice.PriceTable.GetCellFromTable(0, 0);
			string taxVatprice = Pages.PageInvoice.PriceTable.GetCellFromTable(0, 1);
			string totalAmountprice = Pages.PageInvoice.PriceTable.GetCellFromTable(0, 2);
			Assert.AreEqual(expectedDepositNow, depositeNowprice);
			Assert.AreEqual(expectedTaxVat, taxVatprice);
			Assert.AreEqual(expectedTotalAmount, totalAmountprice);

			// Find "Swissotel Le Plaza Basel" Hotel > Write Review and rate Clean and Staff options;
			Pages.PageHotels.Goto();
			Pages.PageHotels.SelectHotel(swissotelLePlazaBasel);
			//var clearRaiting = Pages.PageHotelDetails.GetRaiting(RaitingItems.Clean);
			//var staffRaiting = Pages.PageHotelDetails.GetRaiting(RaitingItems.Staff);

			Pages.PageHotelDetails.WriteReview("Diana", "mail@test.com", comment, raitingData);

	        TestFixtureTearDown();
        }
    }
}
