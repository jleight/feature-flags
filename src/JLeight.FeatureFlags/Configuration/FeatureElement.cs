using System.Configuration;

namespace JLeight.FeatureFlags.Configuration
{
    public class FeatureElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("isEnabled", IsRequired = true)]
        public bool IsEnabled
        {
            get { return (bool)base["isEnabled"]; }
            set { base["isEnabled"] = value; }
        }
    }
}
