using System;

namespace JLeight.FeatureFlags.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class EnabledAttribute
        : Attribute, IFeatureAttribute
    {
    }
}
