using System;
using System.Reflection;
using Xunit;

namespace JLeight.FeatureFlags.Tests
{
    public class FeatureFacts
    {
        [Fact]
        public void StaticEnabledFeatureIsEnabled()
        {
            var feature = new Feature("StaticEnabled", true);
            Assert.True(feature.IsEnabled);
        }

        [Fact]
        public void StaticDisabledFeatureIsDisabled()
        {
            var feature = new Feature("StaticDisabled", false);
            Assert.False(feature.IsEnabled);
        }

        [Fact]
        public void DynamicEnabledFeatureIsEnabled()
        {
            var method = typeof(FeatureFacts)
                .GetMethod("Enabled");
            var feature = new Feature("DynamicDisabled", method);
            Assert.True(feature.IsEnabled);
        }

        [Fact]
        public void DynamicDisabledFeatureIsDisabled()
        {
            var method = typeof(FeatureFacts)
                .GetMethod("Disabled");
            var feature = new Feature("DynamicEnabled", method);
            Assert.False(feature.IsEnabled);
        }

        #region Feature Methods
        public static bool Enabled()
        {
            return true;
        }

        public static bool Disabled()
        {
            return false;
        }
        #endregion
    }
}
