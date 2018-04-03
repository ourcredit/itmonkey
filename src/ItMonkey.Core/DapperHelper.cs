using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace ItMonkey
{
    /// <summary>
    /// dapper helpoer
    /// </summary>
   public static class DapperHelper
   {
       public static string Host { get; } =
           "Data Source=103.45.102.47;port=3306;Initial Catalog=itmonkey;uid=root;password=Dizhu2017;Charset=utf8;";
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <returns></returns>
       public  static  void Execute(string sql)
        {
            using (MySqlConnection conn=new MySqlConnection(Host))
            {
                 conn.Execute(sql);
            }
        }
   }
}
