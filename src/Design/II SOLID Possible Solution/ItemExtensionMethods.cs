// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    using System;

    public static class ItemExtensionMethods
    {
        /// <summary>
        /// Determines if <paramref name="item"/> is a subtype of T.
        /// </summary>
        public static bool IsA<T>(this Item item)
            where T : class
        {
            return item.GetType() == typeof(T);
        }

        /// <summary>
        /// Converts <paramref name="item"/> to its subtype of T.
        /// </summary>
        public static T As<T>(this Item item)
            where T : class
        {
            var subtype = item as T;

            if (subtype == null)
            {
                throw new ArgumentException($"item ({item.GetType()}) is not a subtype of {typeof(T)}.");
            }

            return subtype;
        }
    }
}
