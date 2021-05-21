using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util.Extensions
{
    public static class StrEx
    {
        public static object ToObjectValue(this string str, string typeName)
        {
            if (typeName == typeof(string).FullName)
            {
                return str;
            }
            return typeof(int).Assembly.GetType(typeName).GetMethod("Parse", new Type[1]
            {
        typeof(string)
            }).Invoke(null, new object[1]
            {
        str
            });
        }


        public static string ToCSharpTypeStr(this string str)
        {
            string empty = string.Empty;
            switch (str.ToLower())
            {
                case "int":
                    return "System.Int32";
                case "text":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "varchar":
                case "char":
                    return "System.String";
                case "bigint":
                    return "System.Int64";
                case "binary":
                    return "System.Byte[]";
                case "bit":
                    return "System.Boolean";
                case "datetime":
                case "datetime2":
                    return "System.DateTime";
                case "decimal":
                case "money":
                case "numeric":
                case "smallmoney":
                    return "System.Decimal";
                case "float":
                    return "System.Double";
                case "image":
                    return "System.Byte[]";
                case "real":
                    return "System.Single";
                case "smalldatetime":
                    return "System.DateTime";
                case "smallint":
                    return "System.Int16";
                case "timestamp":
                    return "System.DateTime";
                case "tinyint":
                    return "System.Byte";
                case "uniqueidentifier":
                    return "System.Guid";
                case "varbinary":
                    return "System.Byte[]";
                case "Variant":
                    return "System.Object";
                default:
                    return "System.String";
            }
        }


        /// <summary>
        /// 判断字符串是否为Null、空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNull(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 判断字符串是否不为Null、空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool NotNull(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 与字符串进行比较，忽略大小写
        /// </summary>
        /// <param name="s"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string s, string value)
        {
            if (string.IsNullOrEmpty(s))
                return string.IsNullOrEmpty(value);

            return s.Equals(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 首字母转小写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FirstCharToLower(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string str = s.First().ToString().ToLower() + s.Substring(1);
            return str;
        }

        /// <summary>
        /// 首字母转大写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string str = s.First().ToString().ToUpper() + s.Substring(1);
            return str;
        }

    }
}