using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Darkit.Text
{
    public static class CaseStyleExtends
    {
        public static string ToCase(this string text, CaseStyle style)
        {
            if (style == CaseStyle.RawStyle) return text;

            Regex regex = new Regex("([A-Z])");
            string temp = regex.Replace(text, "_$1");
            temp = temp.Replace('-', '_');
            string[] items = temp.Split('_').Where(i => !string.IsNullOrEmpty(i)).ToArray();
            switch(style)
            {
                case CaseStyle.CamelStyle:
                    return string.Join(string.Empty, items.Select((i, j) => j > 0 ? i.ToFirstUpperStyle() : i.ToLower()).ToArray());
                case CaseStyle.KebabStyle:
                    return string.Join("-", items.Select(i => i.ToLower()).ToArray());
                case CaseStyle.SnakeStyle:
                    return string.Join("_", items.Select(i => i.ToLower()).ToArray());
                case CaseStyle.PascalStyle:
                    return string.Join(string.Empty, items.Select(i => i.ToFirstUpperStyle()).ToArray());
            }
            throw new Exception("未知的转换风格");
        }

        /// <summary>
        /// 首字母大写并小写其他字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string ToFirstUpperStyle(this string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            char first = text[0];
            char[] data = text.ToLower().ToCharArray();
            data[0] = char.ToUpper(first);
            return new string(data);
        }
    }
}
