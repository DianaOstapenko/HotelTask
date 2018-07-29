using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Rosetta.Framework.Pages
{
	public class PageHotels : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//table[contains(@class, 'bgwhite')]//tr/td")]
		public IList<IWebElement> FilteredListItems;

		[FindsBy(How = How.XPath, Using = "//table[contains(@class, 'bgwhite')]")]
		public IWebElement TableHotels;

		[FindsBy(How = How.XPath, Using = "//div[contains(@class, 'g0-left')]/div[@class='row']/h4/a")]
		internal IList<IWebElement> Descriptions;

		public PageHotels()
			{
			TitleEng = "Search Results";
			}

			public void Goto()
			{
				{
					Pages.HomePage.Hotels();
				}
			}

			public void SelectHotel(string hotelname)
			{
				foreach (var hotel in Descriptions)
				{
					if (hotel.Text.Equals(hotelname))
					{
						hotel.Click();
					return;
					}
				}
				//availableListItem.GoToHotelDetails(hotelname);
			}
		//private readonly FilteredListItem availableListItem = new FilteredListItem();
	}

	//public class FilteredListItem: Container
	//{
	//	//[FindsBy(How = How.XPath, Using = "//table[contains(@class, 'bgwhite')]//tr/td")] 
	//	//public IList<IWebElement> Items;

	//	[FindsBy(How = How.XPath, Using = "//div[@class='img_list']")]
	//	internal IWebElement Image;

	//	//[FindsBy(How = How.XPath, Using = "//div[contains(@class, 'g0-left')]/div[@class='row']")]
	//	//internal IWebElement Description;

	//	[FindsBy(How = How.XPath, Using = "//div[contains(@class, 'price_tab')]")]
	//	internal IWebElement Details;

	//	[FindsBy(How = How.XPath, Using = "//h4[contains(@class,'RTL')]/a")]
	//	internal IWebElement Header;

	//	public void GoToDetails()
	//	{
	//		Details.GetAnchorElement().Click();
	//	}

	//	public void GoToHotelDetails(string hotelName)
	//	{
	//		var dd = Details.Text;
	//		//for (int i = 0; i < Items.Count; i++)
	//		//{
	//		//	if (Details.Text.Equals(hotelName))
	//		//	{
	//		//		GoToDetails();
	//		//	}
	//		//}
	//	}
	//}
}