using System;
using System.Reflection;

namespace JLeight.FeatureFlags
{
    public class Feature : IFeature
    {
        private readonly string name;
        private readonly bool? enabled;
        private readonly MethodInfo callback;


        public string Name
        {
            get { return this.name; }
        }

        public bool IsEnabled
        {
            get { return enabled ?? Callback(); }
        }


        public Feature(string name, bool enabled)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            this.name = name;
            this.enabled = enabled;
        }

        public Feature(string name, MethodInfo callback)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            this.name = name;
            this.callback = callback;
        }


        private bool Callback()
        {
            return (bool)this.callback.Invoke(null, null);
        }
    }
}
