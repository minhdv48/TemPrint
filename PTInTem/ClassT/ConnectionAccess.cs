using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Reflection;

namespace PTInTem.ClassT
{
    public class ConnectionAccess
    {
        //public OleDbConnection conn = new OleDbConnection();
        //public String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Data\\DbIntem.mdb;Persist Security Info=True";

       
        //public bool ConnectToAccess()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();

        //    } 
        //    conn.ConnectionString = connection;
            
        //    try
        //    {
        //        conn.Open();
        //        return true;
        //    }
        //    catch
        //    {
        //        DevExpress.XtraEditors.XtraMessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }
        //}
        
        //public  Single GiaTriSingLe(string sql)
        //{
        //    Single a=0;
        //    if (!ConnectToAccess()) return 0;
        //    OleDbCommand cmd = new OleDbCommand(sql, conn);
        //    a=Convert.ToSingle(cmd.ExecuteScalar());
        //    conn.Close();
        //    return a;
        //}
        //public  string GiaTriString(string sql)
        //{
        //    if (!ConnectToAccess()) return null;
        //    DataTable dt = new DataTable();
        //    OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        //    da.Fill(dt);
        //    conn.Close();
        //    if (dt.Rows.Count > 0)
        //    {
                
        //        return Convert.ToString(dt.Rows[0][0]);
        //    }
        //    return null;
        //}
        //public  DataSet XuatDataset(string sql, string tendatatable)
        //{
        //    if (!ConnectToAccess()) return null;
        //    DataSet dt = new DataSet();
        //    OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        //    da.SelectCommand.CommandTimeout = 10000;
        //    da.Fill(dt, tendatatable);
        //    conn.Close();
        //    return dt;
        //}
        //public static List<T> ConvertDataTable<T>(DataTable dt)
        //{
        //    List<T> data = new List<T>();
        //    foreach (DataRow row in dt.Rows)
        //    {

        //        T item = GetItem<T>(row);
        //        data.Add(item);
        //    }
        //    return data;
        //}
        //private static T GetItem<T>(DataRow dr)
        //{
        //    Type temp = typeof(T);
        //    T obj = Activator.CreateInstance<T>();

        //    foreach (DataColumn column in dr.Table.Columns)
        //    {
        //        foreach (PropertyInfo pro in temp.GetProperties())
        //        {
        //            if (pro.Name == column.ColumnName)
        //            {
        //                try
        //                {
        //                    pro.SetValue(obj, dr[column.ColumnName], null);
        //                }
        //                catch
        //                {
        //                }
        //            }
        //            else
        //                continue;
        //        }
        //    }
        //    return obj;
        //}
        //public DataTable XuatDL(string sql)
        //{

        //    if (!ConnectToAccess()) return null;
        //    DataTable dt = new DataTable();
        //    if (conn.State == ConnectionState.Closed) conn.Open();
        //    OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            
        //    try
        //    {
        //        da.Fill(dt);
        //        conn.Close();
        //        return dt;
        //    }
        //    catch { return null; }
        //}
        
        //public  void ThucThi(string sql)
        //{
        //    if (!ConnectToAccess()) return;
        //    if (conn.State == ConnectionState.Closed)
        //    {
        //        conn.Open();

        //    }
        //    OleDbCommand cmd = new OleDbCommand(sql, conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
        
    }
}
