using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace JLeight.FeatureFlags.Configuration
{
    public class FeaturesSection : ConfigurationSection
    {
        private static IDictionary<string, FeatureElement> features;


        internal static IDictionary<string, FeatureElement> Features
        {
            get
            {
                if (features != null)
                    return features;

                var instance = (FeaturesSection)ConfigurationManager.GetSection("features");
                features = instance.FeatureElements
                    .Cast<FeatureElement>()
                    .ToDictionary(x => x.Name, x => x);
                return features;
            }
        }

        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(FeaturesSection), AddItemName = "feature")]
        public FeatureElementCollection FeatureElements
        {
            get { return (FeatureElementCollection)this[""]; }
            set { this[""] = value; }
        }
    }
}
