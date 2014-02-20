using System;
using System.Runtime.Serialization;

namespace JLeight.FeatureFlags.Exceptions
{
    [Serializable]
    public class FeatureNotConfiguredException
        : FeatureException
    {
        public string FeatureName { get; private set; }

        public override string Message
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.FeatureName))
                    return base.Message;
                return base.Message +
                    Environment.NewLine +
                    "Feature name: " +
                    this.FeatureName;
            }
        }


        public FeatureNotConfiguredException()
            : base("Feature configuration could not be found.")
        {
        }

        public FeatureNotConfiguredException(string name)
            : this()
        {
            this.FeatureName = name;
        }

        public FeatureNotConfiguredException(string name, string message)
            : base(message)
        {
            this.FeatureName = name;
        }

        public FeatureNotConfiguredException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected FeatureNotConfiguredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
