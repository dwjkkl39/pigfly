using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Admin_DAL
{
    public static class SQLHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["Pigfly_admin"].ConnectionString;
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] param)
        {
            //1、打开数据库   （确认身份验证）   2、创建链接--指定某一个数据库名    3、书写sql--执行sql  4、得到一个结果
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    object result = cmd.ExecuteScalar();
                    return result;
                }
            }
        }
        /// <summary>
        /// 读取SqlDataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] param)
        {
            //1、打开数据库   （确认身份验证）   2、创建链接--指定某一个数据库名    3、书写sql--执行sql  4、得到一个结果
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        //存储过程
        public static SqlDataReader Proc_ExecuteReader(string sql, params SqlParameter[] param)
        {
            //1、打开数据库   （确认身份验证）   2、创建链接--指定某一个数据库名    3、书写sql--执行sql  4、得到一个结果
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }


        public static int ExecuteNonQuery(string sql, params SqlParameter[] param)
        {
            //1、打开数据库   （确认身份验证）   2、创建链接--指定某一个数据库名    3、书写sql--执行sql  4、得到一个结果
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
