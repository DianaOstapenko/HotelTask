using OpenQA.Selenium.Support.PageObjects;

namespace Rosetta.Framework.Pages
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        public static HomePage HomePage => GetPage<HomePage>();

		public static PageHotels PageHotels => GetPage<PageHotels>();

		public static PageMyAccount PageMyAccount => GetPage<PageMyAccount>();

		public static PageHotelDetails PageHotelDetails => GetPage<PageHotelDetails>();

		public static PageInvoice PageInvoice => GetPage<PageInvoice>();

    }
}
