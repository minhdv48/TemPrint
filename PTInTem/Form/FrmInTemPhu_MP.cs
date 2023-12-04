using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Reflection;
using System.Net;
using PTInTem.Report;
using PTInTem.ClassT;
using DevExpress.XtraReports.UI;
using PTInTem.Helper;
using PTInTem.Helper.SQLite;

namespace PTInTem.Form
{
    public partial class FrmInTemPhu_MP : DevExpress.XtraEditors.XtraForm
    {
        private List<TbTemplate> lstTemp = new List<TbTemplate>();
        private ReportCtrl ctrl = new ReportCtrl();
        private ImportExcelCtrl Im = new ImportExcelCtrl();
        private List<IntemPhuEntity> matchList = new List<IntemPhuEntity>();
        public FrmInTemPhu_MP()
        {
            try
            {
                InitializeComponent();
                lstTemp = new TemplateSQLite().SearchQuerryDB();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            //DataTable dt = db.XuatDL("Select * from TbTemplate");
            //lstTemp = ConnectionAccess.ConvertDataTable<TbTemplate>(dt); 
        }


        private void barImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                matchList.Clear();
                openFileDialog1.Filter = "Excel file (*.xls)|*.xlsx";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Im.InitializeWorkbook(openFileDialog1.FileName)) return;
                    var message = string.Empty;
                  //  string Temp = barMau.EditValue.ToString();
                    matchList = Im.ConvertToDataTable("INTEMPHU_MP", openFileDialog1.FileName, ref message) as List<IntemPhuEntity>;
                    if (string.IsNullOrEmpty(message))
                    {

                        ctrl.LoadReport(matchList, "INTEMPHU_MP", this.Name, printControl1, barMau.EditValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show(message, "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void barDowload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SaveFileDialog op = new SaveFileDialog();
                op.Filter = "Excel file (*.xls)|*.xls";
                op.FileName = "In tem phu My Pham";
                if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string Temp = barMau.EditValue.ToString();
                    string remoteUri = "";
                    remoteUri = Application.StartupPath + "\\Template\\TemplateExcelInTemPhu_MP.xls";
                    WebClient myWebClient = new WebClient();
                    myWebClient.DownloadFile(remoteUri, op.FileName);
                    MessageBox.Show("Download Template thành công !", "Thông báo");
                }
            }
            catch (Exception ex)
            { LogHelper.WriteLog(ex); }
        }

        private void FrmInTemPhu_Load(object sender, EventArgs e)
        {
            try
            {
                if(lstTemp != null && lstTemp.Count > 0)
                {
                    CboxMau.DataSource = lstTemp.ToList();
                    barMau.EditValue = lstTemp.FirstOrDefault().ID;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void barDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DevExpress.XtraReports.UserDesigner.XRDesignForm design = new DevExpress.XtraReports.UserDesigner.XRDesignForm();
                design.OpenReport((XtraReport)printControl1.Tag);
                design.ShowDialog();
                ctrl.LoadReport(matchList, "INTEMPHU_MP", this.Name, printControl1, barMau.EditValue.ToString());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }



        private void barMau_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string Temp = barMau.EditValue.ToString();
                ctrl.LoadReport(matchList, "INTEMPHU_MP", this.Name, printControl1, Temp);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
    }
}
