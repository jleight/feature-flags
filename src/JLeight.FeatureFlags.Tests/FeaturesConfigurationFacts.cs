using JLeight.FeatureFlags.Configuration;
using Xunit;

namespace JLeight.FeatureFlags.Tests
{
    public class FeaturesConfigurationFacts
    {
        [Fact]
        public void ConfigSectionEnabledElementIsEnabled()
        {
            Assert.True(FeaturesSection.Features["ConfigSectionEnabledFeature"].IsEnabled);
        }

        [Fact]
        public void ConfigSectionDisabledElementIsEnabled()
        {
            Assert.False(FeaturesSection.Features["ConfigSectionDisabledFeature"].IsEnabled);
        }
    }
}
