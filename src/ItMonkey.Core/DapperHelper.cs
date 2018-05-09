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
           "Data Source=103.45.8.198;port=3306;Initial Catalog=itmonkey;uid=dizhu;password=Dizhu20!&;Charset=utf8;";
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
       public static async Task ExecuteAsync(string sql)
       {
           using (MySqlConnection conn = new MySqlConnection(Host))
           {
             await  conn.ExecuteAsync(sql);
           }
       }
    }
}
