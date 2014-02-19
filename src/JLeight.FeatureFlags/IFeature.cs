using System;

namespace JLeight.FeatureFlags
{
    public interface IFeature
        : IEquatable<IFeature>, IEquatable<string>, IComparable<IFeature>, IComparable<string>
    {
        string Name { get; }
        bool IsEnabled { get; }
    }
}
