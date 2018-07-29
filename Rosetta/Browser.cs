using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Rosetta.Framework
{
    public static class Browser
    {
        private const string BaseUrl = "https://www.phptravels.net/en";

        private static readonly ChromeOptions Options = new ChromeOptions();

		private static ChromeOptions ConfigureOptions()
		{
			Options.AddArguments("disable-extensions");
			Options.AddArguments("--start-maximized");
			Options.AddArguments("--lang=en-US");
			return Options;
		}

		public static IWebDriver WebDriver = new ChromeDriver(ConfigureOptions());

		public static void Initialize()
		{
			WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(18);
			WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			WebDriver.Navigate().GoToUrl(BaseUrl);
		}

	    public static ISearchContext Driver => WebDriver;

        public static void Close()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }

        public static void SetImplicitWait(int seconds)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
    }
}
