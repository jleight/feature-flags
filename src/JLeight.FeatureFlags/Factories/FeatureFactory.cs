using JLeight.FeatureFlags.Attributes;
using JLeight.FeatureFlags.Exceptions;

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
    }
}
