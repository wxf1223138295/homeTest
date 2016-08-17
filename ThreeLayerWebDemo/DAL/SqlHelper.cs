using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SqlHelper
    {
        //定义一个连接字符串
        //readonly修饰的变量，只能在初始化的时候赋值，以及在构造函数中赋值
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["MSSSqlserver"].ConnectionString;
        //1.执行增删改的方法
        //ExecuteNonQuery()
        public static DataTable ExecuteDataTable(string sql,CommandType commandtype,params SqlParameter[] pms)
        {
            DataSet ds=new DataSet();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlDataAdapter cmd=new SqlDataAdapter(sql,con))
                {
                    if (pms != null)
                    {
                        cmd.Fill(ds);   
                    }
                    con.Open();
                    dt=ds.Tables[0];
                    return dt;
                }               
            }
        }
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        //2.执行查询，返回单个值的方法
        //ExcuteScalar()
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        //3.执行查询返回多行多列的方法
        //ExecuteReader()
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    //System.Data.CommandBehavior.CloseConnection这个枚举参数表示将来使用完毕sqldatareader后，在关闭reader的同时，在sqldatareader内部会将关联的connection对象也关闭
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }

    }
}
