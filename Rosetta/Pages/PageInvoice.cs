using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Rosetta.Framework.Pages
{
	public class PageInvoice: BasePage
	{
		public PageInvoice()
		{
			TitleEng = "Invoice";
		}

		[FindsBy(How = How.XPath, Using = "//table[contains(@class, 'table-bordered')]")]
		public IWebElement PriceTable;

	}
}