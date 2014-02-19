using System;
using System.Reflection;
using Xunit;

namespace JLeight.FeatureFlags.Tests
{
    public class FeatureFacts
    {
        [Fact]
        public void FeatureMustHaveName()
        {
            Assert.Throws<ArgumentNullException>(() => new Feature(null, true));
            Assert.Throws<ArgumentNullException>(() => new Feature(null, (MethodInfo)null));
            Assert.Throws<ArgumentNullException>(() => new Feature(string.Empty, true));
            Assert.Throws<ArgumentNullException>(() => new Feature(string.Empty, (MethodInfo)null));
            Assert.Throws<ArgumentNullException>(() => new Feature(" ", true));
            Assert.Throws<ArgumentNullException>(() => new Feature(" ", (MethodInfo)null));
        }

        [Fact]
        public void FeaturesWithSameNameShouldBeEqual()
        {
            var enabled = typeof(FeatureFacts)
                .GetMethod("Enabled");
            var disabled = typeof(FeatureFacts)
                .GetMethod("Disabled");
            Assert.Equal(new Feature("Feature", true), new Feature("Feature", true));
            Assert.Equal(new Feature("Feature", true), new Feature("Feature", false));
            Assert.Equal(new Feature("Feature", true), new Feature("Feature", enabled));
            Assert.Equal(new Feature("Feature", enabled), new Feature("Feature", enabled));
            Assert.Equal(new Feature("Feature", enabled), new Feature("Feature", disabled));
            Assert.True(new Feature("Feature", true).Equals(new Feature("Feature", true)));
            Assert.True(new Feature("Feature", true).Equals(new Feature("Feature", false)));
            Assert.True(new Feature("Feature", true).Equals(new Feature("Feature", enabled)));
            Assert.True(new Feature("Feature", enabled).Equals(new Feature("Feature", enabled)));
            Assert.True(new Feature("Feature", enabled).Equals(new Feature("Feature", disabled)));
        }

        [Fact]
        public void FeaturesWithDifferentNameShouldBeDifferent()
        {
            var enabled = typeof(FeatureFacts)
                .GetMethod("Enabled");
            var disabled = typeof(FeatureFacts)
                .GetMethod("Disabled");
            Assert.NotEqual(new Feature("Feature1", true), new Feature("Feature2", true));
            Assert.NotEqual(new Feature("Feature1", true), new Feature("Feature2", false));
            Assert.NotEqual(new Feature("Feature1", true), new Feature("Feature2", enabled));
            Assert.NotEqual(new Feature("Feature1", enabled), new Feature("Feature2", enabled));
            Assert.NotEqual(new Feature("Feature1", enabled), new Feature("Feature2", disabled));
            Assert.False(new Feature("Feature1", true).Equals(new Feature("Feature2", true)));
            Assert.False(new Feature("Feature1", true).Equals(new Feature("Feature2", false)));
            Assert.False(new Feature("Feature1", true).Equals(new Feature("Feature2", enabled)));
            Assert.False(new Feature("Feature1", enabled).Equals(new Feature("Feature2", enabled)));
            Assert.False(new Feature("Feature1", enabled).Equals(new Feature("Feature2", disabled)));
        }

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
