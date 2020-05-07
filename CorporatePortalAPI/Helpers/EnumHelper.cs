using System;
using System.ComponentModel;

namespace CorporatePortalAPI.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription<TEnum>(TEnum enumValue)  where TEnum : struct
        {
            var t = typeof(TEnum);
            if (!t.IsEnum)
            {
                throw new ArgumentException("Is not enum", nameof(enumValue));
            }

            var fi = t.GetField(enumValue.ToString());

            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return string.Empty;
        }
    }
}