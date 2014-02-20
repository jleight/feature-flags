using JLeight.FeatureFlags.Attributes;
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
    }
}
