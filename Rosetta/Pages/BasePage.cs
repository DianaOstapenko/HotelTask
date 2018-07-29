using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Rosetta.Framework.Pages
{
    public abstract class BasePage
    {

		[FindsBy(How = How.XPath, Using = "//div[@id='collapse']/ul[contains(@class, 'nav')]//a[contains(@title, 'Hotels')]")]
		private IWebElement hotels;

		[FindsBy(How = How.XPath, Using = "//ul[contains(@class, 'navbar-right')]/ul/li[@id='li_myaccount']/a[contains(@class, 'dropdown-toggle')]")]
		private IWebElement btnMyAccount;

		[FindsBy(How = How.XPath, Using = "//li[@class='open']/ul[@class='dropdown-menu']")]
		private IWebElement ddlMyAccount;

		[FindsBy(How = How.XPath, Using = "//input[@name='username']")]
		private IWebElement txtUserName;

		[FindsBy(How = How.XPath, Using = "//input[@name='password']")]
		private IWebElement txtPassword;

		[FindsBy(How = How.XPath, Using = "//button[contains(@class, 'loginbtn')]")]
		private IWebElement btnSubmit;

		protected string TitleUkr = null;
        protected string TitleEng = null;

	    public void Login(string username, string password)
	    {
		    btnMyAccount.Click();
		    IWebElement anchor = ddlMyAccount.FindElement(By.LinkText("Login"));
			anchor.Click();

			txtUserName.SendKeys(username);
			txtPassword.SendKeys(password);
			btnSubmit.Click();
	    }


		public void Hotels()
		{
			hotels.Click();
		}

    }
}
