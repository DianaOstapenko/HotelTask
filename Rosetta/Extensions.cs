using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Rosetta.Framework
{
    public static class Extensions
    {

		public static IWebElement GetParent(this IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }

		public static void ScrollToElement( this IWebElement element)
		{
			IWebDriver driver = Browser.WebDriver;
			IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
			je.ExecuteScript("arguments[0].scrollIntoView(true);", element);
		}

		public static string GetCellFromTable(this IWebElement table, int rowIndex, int columnIndex)
		{
			return table.FindElements(By.XPath("./tbody/tr"))[rowIndex].FindElements(By.XPath("./td"))[columnIndex].Text;
		}

		public static List<string> GetCellsFromTable(this IWebElement table, int rowIndex, int columnIndex)
		{
			return table.FindElements(By.XPath("./tbody/tr"))[rowIndex].FindElements(By.XPath("./td")).Select(x => x.Text).ToList();
		}

    }
}
