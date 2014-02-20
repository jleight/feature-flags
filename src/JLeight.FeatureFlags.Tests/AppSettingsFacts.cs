using System.Configuration;
using Xunit;
namespace JLeight.FeatureFlags.Tests
{
    public class AppSettingsFacts
    {
        [Fact]
        public void AppSettingsAreReadable()
        {
            var value = ConfigurationManager.AppSettings["TestValue"];
            Assert.False(string.IsNullOrEmpty(value));
        }
    }
}
