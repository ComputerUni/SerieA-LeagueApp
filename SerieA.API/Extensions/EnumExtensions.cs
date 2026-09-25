using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SerieA.API.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>()
                ?.Name ?? enumValue.ToString();
        }
    }
}
