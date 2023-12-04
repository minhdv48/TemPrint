
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using PTInTem.ClassT;
using PTInTem.Helper;
using PTInTem.Helper.SQLite;

namespace PTIntem.SQLite
{
    public static class SQLiteService
    {


        private static string SQLiteWarehouse = "SQLiteIntem.db";
        private static string SQLiteWarehousePath =  Application.StartupPath + @"\Data\" + SQLiteWarehouse;
        private static string SQLConnection = string.Format("Data Source={0}; Version = 3; New = True; Compress = True; ", SQLiteWarehousePath);
        private static SQLiteConnection sqlite_conn = new SQLiteConnection(SQLConnection);
         


        public static bool CreateDatabase()
        {
            try
            {
                using (SQLiteConnection _connection = new SQLiteConnection())
                {

                    if (!File.Exists(SQLiteWarehousePath))
                    {
                        SQLiteConnection.CreateFile(SQLiteWarehousePath);
                    }
                    CheckCreatTable();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return false;
            }
           
        }



        /// <summary>
        /// Kiểm tra bảng (nếu có) để thêm mới
        /// </summary>
        public static void CheckCreatTable()
        {
            if(!checkTableName((TableSQLite.Menu).GetDescription()))
            {
                var Createsql = "CREATE TABLE "+ (TableSQLite.Menu).GetDescription() + " (ID varchar(50), Parent_ID varchar(50),CAPTION_VN varchar(50), RunForm Nvarchar(500), TYPE Int, TypeShow bit, ICON varchar(25), STT int, IsActive bit)";
                CreateTable(Createsql);
                new MenuSQLite().InsertMenuDataPattern();
            }
            if (!checkTableName((TableSQLite.Template).GetDescription()))
            {
                var Createsql = "CREATE TABLE " + (TableSQLite.Template).GetDescription() + " (ID Int, Name varchar(250))";
                CreateTable(Createsql);
              
            }
            if (!checkTableName((TableSQLite.FunctionType).GetDescription()))
            {
                var Createsql = "CREATE TABLE " + (TableSQLite.FunctionType).GetDescription() + " (ID Int, Name varchar(250))";
                CreateTable(Createsql);
                new FunctionTypeSQLite().Insert_Sample();
            }
            if (!checkTableName((TableSQLite.TemplateMenu).GetDescription()))
            {
                var Createsql = "CREATE TABLE " + (TableSQLite.TemplateMenu).GetDescription() + " (ID Int, Menu varchar(250), TemplateID int, Size varchar(50), Font varchar(50))";
                CreateTable(Createsql);
            }

        }

        /// <summary>
        /// Tạo bảng trong sqlite
        /// </summary>
        public static void CreateTable(string Createsql)
        {
            try
            {
                using (SQLiteConnection sqlite_conn = new SQLiteConnection(SQLConnection))
                {
                    sqlite_conn.Open();
                    // tạo bảng loginfor
                    SQLiteCommand sqlite_cmd;
                    //string Createsql = @"CREATE TABLE LogInfor (Controller Nvarchar(500),idLog varchar(50), Content Nvarchar(500), LogDate varchar(50), IPAddress Nvarchar(500))";
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = Createsql;
                    sqlite_cmd.ExecuteNonQuery();
                    sqlite_conn.Close();
                    sqlite_conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
           
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của bảng trong sql
        /// </summary>
        public static bool checkTableName(string tableName)
        {
            using (SQLiteConnection sqlite_conn = new SQLiteConnection(SQLConnection))
            {
                sqlite_conn.Open();
                SQLiteCommand sqlite_cmd;
                string Createsql = @"SELECT name FROM sqlite_master WHERE type='table' AND name='" + tableName + "';";
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                SQLiteDataReader reader = sqlite_cmd.ExecuteReader();

                while (reader.Read())
                {
                    reader.Close();
                    reader.Dispose();
                    sqlite_conn.Close();
                    sqlite_conn.Dispose();
                    return true;
                }
                reader.Close();
                reader.Dispose();
                sqlite_conn.Close();
                sqlite_conn.Dispose();
                return false;
            }
        }

        /// <summary>
        /// Thêm mới data vào bảng dữ liệu
        /// </summary>
        public static void ExcuteQuerry(string querry)
        {
            try
            {
                using (SQLiteConnection sqlite_conn = new SQLiteConnection(SQLConnection))
                {
                    sqlite_conn.Open();
                    SQLiteCommand sqlite_cmd;
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = querry;
                    sqlite_cmd.ExecuteNonQuery();
                    sqlite_conn.Close();
                    sqlite_conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }

        /// <summary>
        /// Search dữ liệu table trong sqlite
        /// </summary>
        public static List<T> ReadData<T>(string querry)
        {
            var result = new List<T>();
            try
            {
                using (SQLiteConnection sqlite_conn = new SQLiteConnection(SQLConnection))
                {
                    sqlite_conn.Open();
                    SQLiteDataReader sqlite_datareader;
                    SQLiteCommand sqlite_cmd;
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = querry;
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        result.Add(sqlite_datareader.LoadAs<T>());
                    }
                    sqlite_conn.Close();
                    sqlite_conn.Dispose();

                }
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return new List<T>();
            }

        }

       

    }
}