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
    /// <summary>
    /// 家族静态帮助类
    /// </summary>
    public class FamilyConsts
    {
        /// <summary>
        /// 家族树构成
        /// </summary>
        public static List<int> Array => new List<int>()
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18,
            19,
            20,
            21,
            22,
            23,
            24,
            25,
            26,
            27
        };
        /// <summary>
        /// 获取适当位置
        /// </summary>
        /// <param name="arra"></param>
        /// <returns></returns>
        public static int Getsuit(List<int> arra)
        {
            var temp = Array.Except(arra).ToList();
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
            if (level <= 1) return "组长";
            if (level <= 4) return "三级族员";
            if (level <= 13) return "二级族员";
            return "一级族员";
        }
    }
}
