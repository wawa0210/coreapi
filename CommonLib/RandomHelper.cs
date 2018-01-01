using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib
{
    public static class RandomHelper
    {
        /// <summary>
        /// 生成指定长度的随机数
        /// </summary>
        /// <param name=""></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetSpecialRandomStr(this Random random, int length)
        {
            string buffer = "0123456789abcdefghijklmnopqrstuvwxyz-";// 随机字符中也可以为汉字（任何）  
            var sb = new StringBuilder();
            var r = new Random();
            int range = buffer.Length;
            for (int i = 0; i < length; i++)
            {
                sb.Append(buffer.Substring(r.Next(range), 1));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获得随机数
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string GetGuidStr(this Guid guid)
        {
            return guid.ToString("N");
        }
    }
}
