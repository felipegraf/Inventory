using System.Reflection;

namespace InventoryManamegent.Application.Utils
{
    public static class DTOHelper
    {
        public static bool EqualsHelper(object? obj1, object? obj2)
        {
            if (obj1 == null || obj2 == null || obj1.GetType() != obj2.GetType())
            {
                return false;
            }

            PropertyInfo[] properties = obj1.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                object? value1 = property.GetValue(obj1);
                object? value2 = property.GetValue(obj2);

                if (!EqualityComparer<object?>.Default.Equals(value1, value2))
                {
                    return false;
                }
            }
            return true;
        }

        public static int GetHashCodeHelper(object obj)
        {
            unchecked
            {
                int hash = 17;
                PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo property in properties)
                {
                    hash = hash * 23 + SafeGetHashCode(property.GetValue(obj));
                }
                return hash;
            }
        }

        private static int SafeGetHashCode<T>(T obj)
        {
            return obj != null ? obj.GetHashCode() : 0;
        }
    }
}