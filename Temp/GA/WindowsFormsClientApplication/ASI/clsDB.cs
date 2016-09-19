using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsClientApplication
{
    /// <summary>
    /// Provides Methods for Executing SQL Statements with a Database
    /// </summary>
    public class clsDB
    {

        public string connStr;

        public clsDB()
        {
        }
        public clsDB(string connectionString)
        {
            this.connStr = connectionString;

        }

        public  void ExecuteNonQuery(string SQL)
        {
            SqlConnection cn = new SqlConnection(connStr);
            cn.Open();
            SqlCommand cmd = new SqlCommand(SQL, cn);
            cmd.CommandTimeout = 5000;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

        public int ExecuteScalar_Int(string sql1)
        {
            int retValue = -9999999;
            SqlConnection conn = new SqlConnection(this.connStr);
            SqlCommand myCommand = new SqlCommand(sql1, conn);

            try
            {
                conn.Open();
                
                myCommand.CommandTimeout = 0;

                retValue = System.Convert.ToInt32(myCommand.ExecuteScalar());
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return retValue;
        }

        public double ExecuteScalar_Double(string sql1)
        {
            double retValue = -9999999.0;
            SqlConnection conn = new SqlConnection(this.connStr);

            try
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand(sql1, conn);
                retValue = System.Convert.ToDouble(myCommand.ExecuteScalar());
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return retValue;
        }

        public string ExecuteScalar_String(string sql1)
        {
            string retValue = "";
            SqlConnection conn = new SqlConnection(this.connStr);

            try
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand(sql1, conn);
                retValue = System.Convert.ToString(myCommand.ExecuteScalar());
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return retValue;
        }

        public DateTime ExecuteScalar_DateTime(string sql1)
        {
            DateTime retValue = DateTime.Now;
            SqlConnection conn = new SqlConnection(this.connStr);

            try
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand(sql1, conn);
                retValue = System.Convert.ToDateTime(myCommand.ExecuteScalar());
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return retValue;
        }

        public DataTable GetTable(string SQL)
        {

            SqlConnection cn = new SqlConnection(this.connStr);
            SqlCommand sqlCmd = new SqlCommand(SQL);
            sqlCmd.CommandTimeout = 600;
            sqlCmd.Connection = cn;

            DataTable dt = new DataTable();
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sqlCmd);
                myDataAdapter.Fill(dt);
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }

            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message + "\n" + e1.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }

            return dt;
        }
        public DataSet GetDataSet(string SQL)
        {

            SqlConnection cn = new SqlConnection(this.connStr);
            SqlCommand sqlCmd = new SqlCommand(SQL);
            sqlCmd.CommandTimeout = 600;
            sqlCmd.Connection = cn;

            DataSet ds = new DataSet();
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sqlCmd);
                myDataAdapter.Fill(ds);
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }

            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message + "\n" + e1.Source, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }

            return ds;
        }
        public DataSet GetDataSetSP(string spName)
        {
            SqlConnection cn = new SqlConnection(this.connStr);
            SqlCommand sqlCmd = new SqlCommand(spName,cn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 600;
            sqlCmd.Connection = cn;

            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sqlCmd);
                myDataAdapter.Fill(ds);
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }

            }
            catch (Exception e1)
            {

                System.Windows.Forms.MessageBox.Show(e1.Message + "\n" + e1.Source);

            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }

            return ds;
        }
        public DataTable GetDataTableSP(string spName)
        {
            SqlConnection cn = new SqlConnection(this.connStr);
            SqlCommand sqlCmd = new SqlCommand(spName, cn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 600;
            sqlCmd.Connection = cn;

            DataTable dt = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sqlCmd);
                myDataAdapter.Fill(dt);
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }

            }
            catch (Exception e1)
            {

                System.Windows.Forms.MessageBox.Show(e1.Message + "\n" + e1.Source);

            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }

            return dt;
        }

        public double SP_WithParam_ExecuteScalar(string spName, SqlParameter[] parameters)
        {
            SqlConnection cn = new SqlConnection(this.connStr);
            SqlCommand sqlCmd = new SqlCommand(spName, cn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 600;
            sqlCmd.Connection = cn;
            sqlCmd.Parameters.Add(parameters);

            double retValue = -1;
            try
            {
                cn.Open();
                retValue = System.Convert.ToDouble(sqlCmd.ExecuteScalar());
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }


            }
            catch (Exception e1)
            {

                System.Windows.Forms.MessageBox.Show(e1.Message + "\n" + e1.Source);

            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }

            return retValue;
        }

    }
}
