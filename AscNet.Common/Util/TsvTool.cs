using System.Reflection;

namespace AscNet.Common.Util
{
    public static class TsvTool
    {
        public static string SerializeObject<T>(IEnumerable<T> objs) where T : new()
        {
            string res = string.Empty;

            Type type = typeof(T);
            var properties = type.GetProperties()
                .OrderBy(p => p.GetCustomAttribute<PropertyOrderAttribute>()?.Order ?? int.MaxValue)
                .ToList();

            res += string.Join('\t', properties.Select(x => x.Name)) + '\n';

            foreach (var obj in objs)
            {
                res += string.Join('\t', properties.Select(x => x.GetValue(obj))) + '\n';
            }

            return res;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class PropertyOrderAttribute : Attribute
    {
        public int Order { get; }

        public PropertyOrderAttribute(int order)
        {
            Order = order;
        }
    }
}
