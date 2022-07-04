using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LittleBitGames.QuestsModule.Extensions
{
    internal static class StringExtension
    {
        public static string KeyFormat(this string str, params Expression<Func<string, object>>[] args)
        {
            var parameters = args.ToDictionary(e => $"{{{e.Parameters[0].Name}}}",
                e => e.Compile()(e.Parameters[0].Name));

            var sb = new StringBuilder(str);

            foreach (var kv in parameters) sb.Replace(kv.Key, kv.Value != null ? kv.Value.ToString() : "");

            return sb.ToString();
        }
    }
}