using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Rosetta.Framework.Pages
{
	public class PageMyAccount: BasePage
	{
		public PageMyAccount()
		{
			TitleEng = "My Account";
		}

		[FindsBy(How = How.XPath, Using = "//div[@id='bookings']/div[@class='row']//a[@class='dark']")]
		internal IList<IWebElement> HotelTitles;

		public void SelectInvoice(string hotelName)
		{
			foreach (var hotel in HotelTitles)
			{
				if (hotel.Text == hotelName)
				{
					IWebElement parent = hotel.GetParent();
					IWebElement invoice = parent.FindElement(By.XPath("//a[contains(@class, 'btn-block')]"));
					invoice.Click();

				}
			}
		}

	}
}