using PTIntem.SQLite;
using PTInTem.ClassT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTInTem.Helper.SQLite
{
    public class FunctionTypeSQLite
    {
        public List<FunctionTypeModel> SearchQuerryDB(int? ID = null)
        {
            try
            {
                var result = new List<FunctionTypeModel>();
                var param = string.Empty;
                if (ID != null)
                {
                    param = " and ID = " + ID;
                }
                var querry = @"SELECT * FROM " + (TableSQLite.FunctionType).GetDescription() + " where 1 = 1 " + param;
                var response = SQLiteService.ReadData<FunctionTypeModel>(querry);
                if (response != null && response.Count > 0)
                {
                    result = response;
                }
                return result.OrderBy(x => x.ID).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return new List<FunctionTypeModel>();
            }


        }

        public bool Insert(FunctionTypeModel inputmenu)
        {
            try
            {

                var param = string.Format("{0},'{1}'", inputmenu.ID, inputmenu.Name);
                var querry = string.Format("INSERT INTO {0} (ID,Name) VALUES ({1});", (TableSQLite.FunctionType).GetDescription(), param);
                SQLiteService.ExcuteQuerry(querry);

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return false;
            }
        }

        public bool Insert_Sample()
        {
            try
            {
                var data = new List<FunctionTypeModel>
                {
                    new FunctionTypeModel
                    {
                        ID = 2030,
                        Name = "In tem phụ-khác"

                    },
                      new FunctionTypeModel
                    {
                        ID = 202,
                        Name = "In tem phụ-Nhựa"
                    },
                        new FunctionTypeModel
                    {
                        ID = 203,
                        Name = "In tem phụ - Mỹ phẩm"
                    },
                };

                foreach(var item in data)
                {
                    Insert(item);
                }
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
