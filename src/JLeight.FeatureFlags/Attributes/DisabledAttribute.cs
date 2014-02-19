using System;

namespace JLeight.FeatureFlags.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DisabledAttribute
        : Attribute, IFeatureAttribute
    {
    }
}
