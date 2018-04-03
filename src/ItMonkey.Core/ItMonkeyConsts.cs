using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace ItMonkey
{
    public class ItMonkeyConsts
    {
        public const string LocalizationSourceName = "ItMonkey";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;
    }

    public class CacheConsts
    {
        public const string MessageCache = "MessageCache";
    }
    /// <summary>
    /// 家族静态帮助类
    /// </summary>
    public class FamilyConsts
    {
       
        /// <summary>
        /// 获取适当位置
        /// </summary>
        /// <param name="arra"></param>
        /// <returns></returns>
        public static int Getsuit(List<int> arra)
        {
            var list=new List<int>();
            for (int i = 1; i <= 40; i++)
            {
                list.Add(i);
            }
            var temp = list.Except(arra).ToList();
            temp.Sort();
            return temp.First();
        }
        /// <summary>
        /// 获取职称
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static string GetTitle(int level)
        {
            if (level <= 1) return "族长";
            if (level <= 4) return "三级族员";
            if (level <= 13) return "二级族员";
            return "一级族员";
        }
    }
}
