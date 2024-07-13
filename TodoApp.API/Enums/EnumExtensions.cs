using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TodoApp.API.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumVal)
        {
            return enumVal.GetType()
                .GetMember(enumVal.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
