
using PTInTem.ClassT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PTIntem.SQLite
{
    public class LogInforSqlite
    {
        //public bool Insert(List<LoginforModel> inputLoginfor)
        //{
        //    try
        //    {
        //        foreach (var input in inputLoginfor)
        //        {
        //            input.IPAddress = string.Empty;
        //            input.LogDate = DateTime.Now.ToString();
        //            input.PartnerType = (int)PartnerTypeSQLite.WebWarehouse;
        //            var param = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}',{6}", input.Controller, input.Action, input.IDLog, input.Content, input.LogDate, input.IPAddress, input.PartnerType);
        //            var querry = string.Format("INSERT INTO {0} (Controller,Action, IDLog, Content, LogDate,IPAddress,PartnerType) VALUES ({1});", (TableSQLite.LogInfor).GetDescription(), param);
        //            SQLiteService.ExcuteQuerry(querry);
        //            if (input.IsError)
        //            {
        //                var querry1 = string.Format("INSERT INTO {0} (Controller,Action, IDLog, Content, LogDate,IPAddress,PartnerType) VALUES ({1});", (TableSQLite.LogError).GetDescription(), param);
        //                SQLiteService.ExcuteQuerry(querry1);
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logging.PutError("LogInforSqlite/Insert: Exception:", ex);
        //        return false;
        //    }

        //}

        //public List<LoginforModel> SearchQuerryDB(SearchLogInforInput input, ref int totalCount)
        //{
        //    var result = new List<LoginforModel>();
        //    var param = string.Empty;
        //    if (input.PartnerType != 0)
        //    {
        //        param += string.Format(" and PartnerType = {0}", input.PartnerType);
        //    }
        //    if (!string.IsNullOrEmpty(input.KeySearch))
        //    {
        //        param += string.Format(" and (IDLog LIKE '%{0}%' or Content LIKE '%{0}%' or IPAddress LIKE '%{0}%')", input.KeySearch);
        //    }
        //    if (input.LogType == 1) // loginfor
        //    {
        //        var querry = @"SELECT * FROM " + (TableSQLite.LogInfor).GetDescription() + " where 1=1 " + param;
        //        var response = SQLiteService.ReadData<LoginforModel>(querry);
        //        var response_fiter = response.Where(x => DateTime.Parse(x.LogDate) >= input.StartDate && DateTime.Parse(x.LogDate) <= input.EndDate.AddDays(1));
        //        totalCount = response_fiter.Count();
        //        result = response_fiter.Skip((input.PageNext - 1) * input.PageSize).Take(input.PageSize).ToList();
        //    }
        //    else
        //    {
        //        var querry = @"SELECT * FROM " + (TableSQLite.LogError).GetDescription() + " where 1=1 " + param;
        //        var response = SQLiteService.ReadData<LoginforModel>(querry);
        //        var response_fiter = response.Where(x => DateTime.Parse(x.LogDate) >= input.StartDate && DateTime.Parse(x.LogDate) <= input.EndDate.AddDays(1));
        //        totalCount = response_fiter.Count();
        //        result = response_fiter.Skip((input.PageNext - 1) * input.PageSize).Take(input.PageSize).ToList();
        //    }
        //    return result;

        //}

        //public List<SelectModel> ListPartnerTypeSQLite()
        //{
        //    return ((PartnerTypeSQLite[])Enum.GetValues(typeof(PartnerTypeSQLite))).Select(c => new SelectModel() { Value = (int)c, Text = c.GetDescription() }).ToList();
        //}

        //public void Delete()
        //{
        //    var querry_full = @"SELECT* FROM " + (TableSQLite.LogInfor).GetDescription();
        //    var response = SQLiteService.ReadData<LoginforModel>(querry_full);
        //    var response_fiter = response.Where(x => DateTime.Parse(x.LogDate) <= DateTime.Now.AddDays(-15)).ToList();
        //    var response_fiter_idlog = response_fiter.GroupBy(x => x.IDLog).Select(x => x.Key).ToList();
        //    foreach (var item in response_fiter_idlog)
        //    {
        //        var param = string.Format(" IdLog = '{0}')", item);
        //        var querry = string.Format("Delete from {0} where {1}", (TableSQLite.LogInfor).GetDescription(), param);
        //        SQLiteService.ExcuteQuerry(querry);
        //    }

        //}
    }

    public class LoginforModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string IDLog { get; set; }
        public string Content { get; set; }
        public string LogDate { get; set; }
     
        public string IPAddress { get; set; }
        public bool IsError { get; set; }
        public int PartnerType { get; set; }
        public string PartnerTypeSTR => ((PartnerTypeSQLite)PartnerType).GetDescription();
    }
    public class SearchLogInforInput
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string KeySearch { get; set; }
        public int PartnerType { get; set; }
        public int PageNext { get; set; }
        public int PageSize { get; set; }
        public int LogType { get; set; }
    }

    public class ListLoginforModelSQLite
    {
        public List<LoginforModel> data { get; set; }
        public int total { get; set; }

    }

    public class SelectModel
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }

}