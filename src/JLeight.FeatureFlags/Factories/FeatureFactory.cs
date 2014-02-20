using JLeight.FeatureFlags.Attributes;
using JLeight.FeatureFlags.Exceptions;
using System;
using System.Configuration;

namespace JLeight.FeatureFlags.Factories
{
    internal static class FeatureFactory
    {
        public static Feature From(string name, IFeatureAttribute attribute)
        {
            if (attribute is EnabledAttribute)
                return new Feature(name, true);
            if (attribute is DisabledAttribute)
                return new Feature(name, false);
            throw new FeatureNotConfiguredException(name);
        }

        public static Feature FromAppSettings(string name, string key)
        {
            bool enabled;
            var value = ConfigurationManager.AppSettings[key];

            if (value == null)
                throw new FeatureNotConfiguredException(name);

            if (bool.TryParse(value, out enabled))
                return new Feature(name, enabled);

            var message = string.Format("Feature value is not a valid boolean: {0}", value);
            throw new FeatureException(message);
        }
    }
}
