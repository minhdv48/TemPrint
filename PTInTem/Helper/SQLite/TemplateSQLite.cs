using PTIntem.SQLite;
using PTInTem.ClassT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTInTem.Helper.SQLite
{
    public class TemplateSQLite
    {
     

        public List<TbTemplate> SearchQuerryDB(int? ID = null)
        {
            try
            {
                var result = new List<TbTemplate>();
                var param = string.Empty;
                if (ID != null)
                {
                    param = " and ID = " + ID;
                }
                var querry = @"SELECT * FROM " + (TableSQLite.Template).GetDescription() + " where 1 = 1 " + param;
                var response = SQLiteService.ReadData<TbTemplate>(querry);
                if (response != null && response.Count > 0)
                {
                    result = response;
                }
                return result.OrderBy(x => x.ID).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return new List<TbTemplate>();
            }


        }

        public bool Insert(TbTemplate inputmenu)
        {
            try
            {

                var param = string.Format("{0},'{1}'", inputmenu.ID, inputmenu.Name);
                var querry = string.Format("INSERT INTO {0} (ID,Name) VALUES ({1});", (TableSQLite.Template).GetDescription(), param);
                SQLiteService.ExcuteQuerry(querry);

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return false;
            }
        }

        public bool Update(TbTemplate inputmenu)
        {
            try
            {
                var querry = string.Format("Update {0} set Name = '{1}' where ID = {2}", (TableSQLite.Template).GetDescription(), inputmenu.Name, inputmenu.ID);
                SQLiteService.ExcuteQuerry(querry);
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return false;
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                var querry = string.Format("Delete from {0} where ID = {1}", (TableSQLite.Template).GetDescription(), ID);
                SQLiteService.ExcuteQuerry(querry);
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return false;
            }
        }
    }
}
