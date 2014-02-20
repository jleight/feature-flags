using JLeight.FeatureFlags.Attributes;
using JLeight.FeatureFlags.Exceptions;
using JLeight.FeatureFlags.Factories;
using Xunit;

namespace JLeight.FeatureFlags.Tests
{
    public class FeatureFactoryFacts
    {
        [Fact]
        public void EnabledAttributeFeatureIsEnabled()
        {
            var feature = FeatureFactory.From("Feature", new EnabledAttribute());
            Assert.True(feature.IsEnabled);
        }

        [Fact]
        public void DisabledAttributeFeatureIsDisabled()
        {
            var feature = FeatureFactory.From("Feature", new DisabledAttribute());
            Assert.False(feature.IsEnabled);
        }

        [Fact]
        public void AppSettingsEnabledFeatureIsEnabled()
        {
            var feature = FeatureFactory.FromAppSettings("Feature", "feature:EnabledFeature");
            Assert.True(feature.IsEnabled);
        }

        [Fact]
        public void AppSettingsDisabledFeatureIsDisabled()
        {
            var feature = FeatureFactory.FromAppSettings("Feature", "feature:EnabledFeature");
            Assert.True(feature.IsEnabled);
        }

        [Fact]
        public void AppSettingsInvalidFeatureThrowsException()
        {
            Assert.Throws<FeatureException>(() => FeatureFactory.FromAppSettings("Feature", "feature:InvalidFeature"));
            Assert.Throws<FeatureNotConfiguredException>(() => FeatureFactory.FromAppSettings("Feature", "feature:NonexistentFeature"));
        }
    }
}
