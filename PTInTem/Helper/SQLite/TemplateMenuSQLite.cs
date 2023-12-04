using PTIntem.SQLite;
using PTInTem.ClassT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTInTem.Helper.SQLite
{
    public class TemplateMenuSQLite
    {
        public List<TemplateMenuModel> SearchQuerryDB(int? ID = null)
        {
            try
            {
                var result = new List<TemplateMenuModel>();
                var param = string.Empty;
                if (ID != null)
                {
                    param = " and t1.ID = " + ID;
                }
                var querry = @"SELECT t1.*, t2.Name as NameTem , t3.Name as NameMenu FROM " + (TableSQLite.TemplateMenu).GetDescription() + " t1 join " + (TableSQLite.Template).GetDescription() + " t2 on t1.TemplateID = t2.ID join "+ (TableSQLite.FunctionType).GetDescription() + " t3 on t1.Menu = t3.ID" + " where 1 = 1 " + param;
                var response = SQLiteService.ReadData<TemplateMenuModel>(querry);
                if (response != null && response.Count > 0)
                {
                    result = response;
                }
                return result.OrderBy(x => x.ID).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return new List<TemplateMenuModel>();
            }


        }

        public bool Insert(TemplateMenuModel inputmenu)
        {
            try
            {

                var param = string.Format("{0},'{1}',{2},'{3}','{4}'", inputmenu.ID, inputmenu.Menu, inputmenu.TemplateID, inputmenu.Size, inputmenu.Font);
                var querry = string.Format("INSERT INTO {0} (ID,Menu,TemplateID,Size,Font) VALUES ({1});", (TableSQLite.TemplateMenu).GetDescription(), param);
                SQLiteService.ExcuteQuerry(querry);

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return false;
            }
        }

        public bool Update(TemplateMenuModel inputmenu)
        {
            try
            {
                var querry = string.Format("Update {0} set Font = '{1}', Size = '{2}' where ID = {3}", (TableSQLite.TemplateMenu).GetDescription(), inputmenu.Font, inputmenu.Size, inputmenu.ID);
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
                var querry = string.Format("Delete from {0} where ID = {1}", (TableSQLite.TemplateMenu).GetDescription(), ID);
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
