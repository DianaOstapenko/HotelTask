using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Rosetta.Framework.Pages
{
	public enum RaitingItems
	{
		 Clean,
		 Comfort,
		 Location,
		 Facilities,
		 Staff
	}

	public class PageHotelDetails: BasePage
	{
		public PageHotelDetails()
		{
			TitleEng = "Swissotel Le Plaza Basel";
		}

		[FindsBy(How = How.XPath, Using = "//div[contains(@class, 'go-left')]//div[contains(@class, 'progress-bar-primary')]")]
		public IList<IWebElement> Raitings;

		[FindsBy(How = How.XPath, Using = "//button[@href='#ADDREVIEW']")]
		public IWebElement BtnWriteReview;
		[FindsBy(How = How.XPath, Using = "//input[@name='fullname']")]
		public IWebElement TxtFullName;
		[FindsBy(How = How.XPath, Using = "//input[@name='email']")]
		public IWebElement TxtEmail;
		[FindsBy(How = How.XPath, Using = "//input[@name='reviews_comments']")]
		public IWebElement TxtComment;
		[FindsBy(How = How.XPath, Using = "//select[@name='reviews_clean']")]
		public IWebElement DdlClean;
		[FindsBy(How = How.XPath, Using = "//select[@name='reviews_comfort']")]
		public IWebElement DdlComfort;
		[FindsBy(How = How.XPath, Using = "//select[@name='reviews_location']")]
		public IWebElement DdlLocation;
		[FindsBy(How = How.XPath, Using = "//select[@name='reviews_facilities']")]
		public IWebElement DdlFacilities;
		[FindsBy(How = How.XPath, Using = "//select[@name='reviews_staff']")]
		public IWebElement DdlStaff;
		[FindsBy(How = How.XPath, Using = "//button[contains(@class, 'addreview')]")]
		public IWebElement BtnSubmit;

		public string GetRaiting(RaitingItems item)
		{
			string raitingValue;
			switch (item)
			{
				case RaitingItems.Clean:
					raitingValue = Raitings[0].GetCssValue("width");
					break;
				case RaitingItems.Comfort:
					raitingValue = Raitings[1].GetCssValue("width");
					break;
				case RaitingItems.Location:
					raitingValue = Raitings[2].GetCssValue("width");
					break;
				case RaitingItems.Facilities:
					raitingValue = Raitings[3].GetCssValue("width");
					break;
				case RaitingItems.Staff:
					raitingValue = Raitings[4].GetCssValue("width");
					break;
				default:
					throw new NotImplementedException("Raiting Value for selected Item is not found: " + item);
			}
			raitingValue = raitingValue.Replace("px", "");
			//float raiting = float.Parse(raitingValue, System.Globalization.CultureInfo.CurrentCulture);
			return raitingValue;
		}

		public void WriteReview(string fullname, string email, string comment, Dictionary<string, string> raiting)
		{
			BtnWriteReview.ScrollToElement();
			BtnWriteReview.Click();

			// Fill required fields;
			TxtFullName.SendKeys(fullname);
			TxtEmail.SendKeys(email);
			TxtComment.SendKeys(comment);

			SelectElement ddlClean = new SelectElement(DdlClean);
			SelectElement ddlComfort = new SelectElement(DdlComfort);
			SelectElement ddlLocation = new SelectElement(DdlLocation);
			SelectElement ddlFacilities = new SelectElement(DdlFacilities);
			SelectElement ddlStaff = new SelectElement(DdlStaff);

			// Set Raiting;
			foreach (var raitingType in raiting)
			{
				switch (raitingType.Key)
				{
					case ("Clean"):
						ddlClean.SelectByText(raitingType.Value);
						break;
					case ("Comfort"):
						ddlComfort.SelectByText(raitingType.Value);
						break;
					case ("Location"):
						ddlLocation.SelectByText(raitingType.Value);
						break;
					case ("Facilities"):
						ddlFacilities.SelectByText(raitingType.Value);
						break;
					case ("Staff"):
						ddlStaff.SelectByText(raitingType.Value);
						break;
					default:
						throw new NotImplementedException("Raiting Value is not found: " + raitingType.Key);
				}
			}
			BtnSubmit.Click();
		}

	}
}