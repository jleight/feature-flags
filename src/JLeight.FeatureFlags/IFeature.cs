namespace JLeight.FeatureFlags
{
    public interface IFeature
    {
        string Name { get; }
        bool IsEnabled { get; }
    }
}
