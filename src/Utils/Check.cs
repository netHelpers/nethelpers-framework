using netHelpers.Framework.Extensions;
using System;
using System.Collections.Generic;

namespace netHelpers.Framework.Utils
{
    public static class Check
    {
        public static T NotNull<T>(T value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static string NotNullOrEmpty(string value, string parameterName)
        {
            return value.IsNullOrEmpty()
                ? throw new ArgumentException($"{parameterName} can not be null or empty!", parameterName) 
                : value;
        }

        public static string NotNullOrWhiteSpace(string value, string parameterName)
        {
            if (value.IsNullOrWhiteSpace())
            {
                throw new ArgumentException($"{parameterName} can not be null, empty or white space!", parameterName);
            }

            return value;
        }

        public static ICollection<T> NotNullOrEmpty<T>(ICollection<T> value, string parameterName)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException(parameterName + " can not be null or empty!", parameterName);
            }

            return value;
        }

        public static void Valid(bool valid, string parameterName)
        {
            if (!valid)
            {
                throw new ArgumentException(parameterName + " is not valid!", parameterName);
            }
        }
    }
}
