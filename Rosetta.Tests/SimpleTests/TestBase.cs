using NUnit.Framework;
using Rosetta.Framework;

namespace Rosetta.Tests.SimpleTests
{
    [TestFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public static void Initialize()
        {
            Browser.Initialize();
        }

        [OneTimeTearDown]
        public static void TestFixtureTearDown()
        {
            Browser.Close();
        }

    }
}
