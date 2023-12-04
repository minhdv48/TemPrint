using PTIntem.SQLite;
using PTInTem.ClassT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTInTem.Helper.SQLite
{
    public class MenuSQLite
    {
        public bool Insert(List<SYS_MENU_Model> inputmenu)
        {
            try
            {
                foreach (var input in inputmenu)
                {
                    var param = string.Format("'{0}','{1}','{2}','{3}',{4},{5},'{6}',{7},{8}", input.ID, input.Parent_ID, input.CAPTION_VN, input.RunForm, input.TYPE, input.TypeShow, input.ICON, input.STT, input.IsActive);
                    var querry = string.Format("INSERT INTO {0} (ID,Parent_ID, CAPTION_VN, RunForm, TYPE,TypeShow,ICON , STT , IsActive) VALUES ({1});", (TableSQLite.Menu).GetDescription(), param);
                    SQLiteService.ExcuteQuerry(querry);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return false;
            }
        }

        public void InsertMenuDataPattern()
        {
            var lstSYS_MENU = DataSYS_MENU.Data();
            var result = Insert(lstSYS_MENU);
        }

        public List<SYS_MENU_Model> SearchQuerryDB()
        {
            try
            {
                var result = new List<SYS_MENU_Model>();
                var querry = @"SELECT * FROM " + (TableSQLite.Menu).GetDescription();
                result = SQLiteService.ReadData<SYS_MENU_Model>(querry);
                return result.ToList();
            }
            catch(Exception ex)
            {
                LogHelper.WriteLog(ex);
                return new List<SYS_MENU_Model>();
            }
           

        }
    }
}
