namespace Nulab.Backlog.Api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    internal static class EnumValueCache<TEnum> where TEnum : struct
    {
        private static readonly Dictionary<TEnum, int> ToValuesCache;

        private static readonly Dictionary<TEnum, string> ToDisplayNameCache;

        static EnumValueCache()
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum) throw new TypeAccessException($"{enumType.FullName} is not enum type.");

            var fields = Enum.GetValues(enumType).OfType<TEnum>().ToArray();
            ToValuesCache = fields.ToDictionary(x => x, x => Convert.ToInt32(x));

            ToDisplayNameCache = new Dictionary<TEnum, string>();
            var members = typeof(TEnum).GetMembers().ToArray();

            foreach (var field in fields)
            {
                var fieldText = field.ToString();
                var member = members.FirstOrDefault(x => x.DeclaringType == typeof(TEnum) && x.Name == fieldText);
                if (member == null) continue;

                var display = member.GetCustomAttribute<DisplayAttribute>();
                if (display == null)
                {
                    ToDisplayNameCache.Add(field, fieldText);
                    continue;
                }

                ToDisplayNameCache.Add(field, display.Name);
            }
        }

        public static int GetValue(TEnum enumValue) => ToValuesCache[enumValue];

        public static int? GetValue(TEnum? enumValue) => enumValue.HasValue ? (int?)GetValue(enumValue.Value) : null;

        public static string GetString(TEnum enumValue) => ToDisplayNameCache[enumValue];

        public static string GetString(TEnum? enumValue) => enumValue.HasValue ? GetString(enumValue.Value) : null;
    }
}