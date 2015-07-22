using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Blowing.MoveHouse.Common
{
    //用静态方法调用时候不用创建SqlHelper的实例

    public class DbHelperSql
    {
        //public static string ConnStr = "server=.;database=itcastcn;uid=sa;pwd=123;";
        //
        public static readonly string _ConnStr = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;

        /// <summary>
        /// 执行NonQuery命令
        /// </summary>
        /// <param name="cmdTxt">命令的SQL update userinfo set ID=@ID</param>
        /// <param name="parames">传入参数</param>
        /// <returns>影响的行数</returns>
        public static int ExcuteNonQuery(string cmdTxt, params SqlParameter[] parames)
        {
            //判断脚本是否为空，为空直接返回0
            if (string.IsNullOrEmpty(cmdTxt))
            {
                return 0;
            }

            using (SqlConnection conn = new SqlConnection(_ConnStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = cmdTxt;
                    //处理参数为空的情况
                    if (parames != null)
                    {
                        cmd.Parameters.AddRange(parames);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExcuteScalar(string cmdTxt, CommandType commdType, params SqlParameter[] parames)
        {
            if (string.IsNullOrEmpty(cmdTxt))
            {
                return null;
            }
            using (SqlConnection conn = new SqlConnection(_ConnStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdTxt;
                    cmd.CommandType = commdType;
                    if (parames != null)
                    {
                        cmd.Parameters.AddRange(parames);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

     

        public static T ExcuteScalar<T>(string cmdTxt, params SqlParameter[] parames)
        {
            //if (string.IsNullOrEmpty(cmdTxt))
            //{
            //    return null;
            //}
            using (SqlConnection conn = new SqlConnection(_ConnStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdTxt;
                    if (parames != null)
                    {
                        cmd.Parameters.AddRange(parames);
                    }
                    conn.Open();
                    return (T)cmd.ExecuteScalar();
                }
            }
        }


        public static SqlDataReader ExcuteDataReader(string cmdTxt, params SqlParameter[] parames)
        {
            if (string.IsNullOrEmpty(cmdTxt))
            {
                return null;
            }
            #region MyRegion
            
           
            //using (SqlConnection conn = new SqlConnection(ConnStr))
            //{
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = cmdTxt;
            //        if (parames != null)
            //        {
            //            cmd.Parameters.AddRange(parames);                        
            //        }
            //        conn.Open();
            //        return cmd.ExecuteReader();//读取数据时：必须独享连接，而且连接不能关闭，保持连接
            //    }
            //}

            #endregion

            SqlConnection conn = new SqlConnection(_ConnStr);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdTxt;
                if (parames != null)
                {
                    cmd.Parameters.AddRange(parames);
                }
                conn.Open();
                //把reader 的行为加进来。当reader释放资源的时候，conn也被一块关闭
                //
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }

        }




        public static DataTable ExcuteDataTable(string cmdTxt, params SqlParameter[] parames)
        {
            if (string.IsNullOrEmpty(cmdTxt))
            {
                return null;
            }
            DataTable dt = new DataTable();
            using (SqlDataAdapter adpter = new SqlDataAdapter(cmdTxt,_ConnStr))
            {
                if (parames != null)
                {
                    adpter.SelectCommand.Parameters.AddRange(parames);
                }
                adpter.Fill(dt);
                return dt;
            }
        }
    }
}
