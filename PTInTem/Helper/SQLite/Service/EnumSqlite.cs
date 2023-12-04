using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PTIntem.SQLite
{
    public enum ControllerEnum
    {
        [Description("HomeController")]
        Home = 1,
        [Description("WarehouseInput")]
        WarehouseInput = 2,
        [Description("WarehouseOutput")]
        WarehouseOutput = 3,
        [Description("WarehouseRequestOutput")]
        WarehouseRequestOutput = 4
    }

    public enum ActionEnum
    {
        [Description("Index")]
        Index = 1,
        [Description("ChangeStatus")]
        ChangeStatus = 2,
        [Description("Payment")]
        Payment = 3,
        [Description("GetPrintWarehouseOutputCommon")]
        GetPrintWarehouseOutputCommon = 4,
        [Description("SaveDebitExcell")]
        SaveDebitExcell = 5,
        [Description("ImportFileDebit")]
        ImportFileDebit = 6,
        [Description("ExportDebit")]
        ExportDebit = 7,
        [Description("CheckPermision")]
        CheckPermision = 8,
        


    }

    public enum TableSQLite
    {
        /// <summary>
        /// Bảng menu 
        /// </summary>
        [Description("Menu")]
        Menu = 1,

        /// <summary>
        /// Bảng template
        /// </summary>
        [Description("Template")]
        Template = 2,

        /// <summary>
        /// Bảng template
        /// </summary>
        [Description("FunctionType")]
        FunctionType = 3,

        [Description("TemplateMenu1")]
        TemplateMenu = 4,
    }


    public enum PartnerTypeSQLite
    {
        /// <summary>
        /// Web kho
        /// </summary>
        [Description("Warehouse Web")]
        WebWarehouse = 1,

        /// <summary>
        /// API kho
        /// </summary>
        [Description("Warehouse API")]
        WarehouseAPI = 2,

        /// <summary>
        /// Job đẩy đơn của kho sang shopviet và momart
        /// </summary>
        [Description("JobWarehouse PushOrder")]
        JobWarehouse_PushOrder = 3,

        /// <summary>
        /// Job xả combo trong kho
        /// </summary>
        [Description("JobWarehouse UnpackingCombo")]
        JobWarehouse_UnpackingCombo = 4,

        /// <summary>
        /// Web shopviet
        /// </summary>
        [Description("ShopViet Web")]
        WebShopViet = 5,
    }
}