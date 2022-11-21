using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Contexts;

namespace App_QL_ThiTracNghiem.DataProvider
{
    public class SqlProvider
    {
        private SqlConnection _connection;
        string connectionString = @"server=PHAMTUANDAT\TUANDAT;database=QL_HETHONGTHITRACNGHIEM;Integrated Security = true;uid=sa;pwd=123";
        public SqlProvider()
        {
            _connection = new SqlConnection(connectionString);
        }

        public DataTable get_data(string sql, string table_name)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, _connection);
                da.Fill(ds, table_name);
                return ds.Tables[table_name];
            }
            catch (SqlException ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }

        public void update_database(string sql, DataTable tbl_up)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, _connection);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Update(tbl_up);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int insert_update_delete(string sql)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, _connection);
                int kq = cmd.ExecuteNonQuery();
                _connection.Close();

                return kq;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    return -1;
                }
                return -2;
                throw new Exception(ex.Message);
            }
        }

        internal int get_result_int(string sql)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, _connection);
                int kq = (int)cmd.ExecuteScalar();
                _connection.Close();

                return kq;
            }
            catch (SqlException ex)
            {
                return -1;
                throw new Exception(ex.Message);
            }
        }
    }
}
