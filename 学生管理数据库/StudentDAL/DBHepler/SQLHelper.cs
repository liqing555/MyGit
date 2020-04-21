using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentDAL.DBHepler
{
    class SQLHelper
    {
        static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        /// <summary>
        /// 执行增，删，改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                //计入系统日志
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 单一结果查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                return cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                //计入系统日志
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 查询结果用DataReader读取
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                //不需要手动关闭con，当DataReader关闭时，con自动跟着关闭
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                con.Close();
                //计入系统日志
                throw ex;
            }
        }
        /// <summary>
        /// 查询结果返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            DataSet set = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(set);
                return set;
            }
            catch (Exception ex)
            {
                
                //计入系统日志
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 查询结果用DataReader读取
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="parameters">SQL语句中的所有参数</param>
        /// <returns></returns>
        public static SqlDataReader GetReaderByPROC(string procName, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //调用存储过程
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);//将SQL语句中的所有参数对象接收
            }
            try
            {
                con.Open();
                //不需要手动关闭con，当DataReader关闭时，con自动跟着关闭
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                con.Close();
                //记入系统日志
                throw ex;
            }
        }
    }
}
