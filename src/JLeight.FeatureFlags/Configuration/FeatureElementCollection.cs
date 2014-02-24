using System.Configuration;

namespace JLeight.FeatureFlags.Configuration
{
    public class FeatureElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FeatureElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FeatureElement)element).Name;
        }
    }
}
