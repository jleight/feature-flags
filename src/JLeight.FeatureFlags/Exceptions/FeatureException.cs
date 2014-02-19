using System;
using System.Runtime.Serialization;

namespace JLeight.FeatureFlags.Exceptions
{
    [Serializable]
    public class FeatureException
        : Exception
    {
        public FeatureException()
        {
        }

        public FeatureException(string message)
            : base(message)
        {
        }

        public FeatureException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected FeatureException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
