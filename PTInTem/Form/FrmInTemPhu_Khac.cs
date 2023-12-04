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
using PTInTem.Helper.SQLite;
using PTInTem.Helper;

namespace PTInTem.Form
{
    public partial class FrmInTemPhu_Khac : DevExpress.XtraEditors.XtraForm
    {

        private List<TbTemplate> lstTemp = new List<TbTemplate>();
        private ReportCtrl ctrl = new ReportCtrl();
        private ImportExcelCtrl Im = new ImportExcelCtrl();
        private List<IntemPhuEntity> matchList = new List<IntemPhuEntity>();
        public FrmInTemPhu_Khac()
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
              
        }
       
        private void barImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                matchList.Clear();
                openFileDialog1.Filter = "Excel file (*.xls)|*.xls";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Im.InitializeWorkbook(openFileDialog1.FileName)) return;
                    string Temp = barMau.EditValue.ToString();
                    var message = string.Empty;
                    matchList = Im.ConvertToDataTable("INTEMPHU_K", openFileDialog1.FileName,ref message) as List<IntemPhuEntity>;
                    if(string.IsNullOrEmpty(message))
                    {
                        ctrl.LoadReport(matchList, "INTEMPHU_K", this.Name, printControl1, Temp);
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
                op.FileName = "In tem phu khac";
                if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string Temp = barMau.EditValue.ToString();
                    string remoteUri = "";
                    remoteUri = Application.StartupPath + "\\Template\\TemplateExcelInTemPhu_Khac.xls";
                    WebClient myWebClient = new WebClient();
                    myWebClient.DownloadFile(remoteUri, op.FileName);
                    MessageBox.Show("Download Template thành công !", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void FrmInTemPhu_Load(object sender, EventArgs e)
        {
            try
            {
                CboxMau.DataSource = lstTemp.ToList();
                barMau.EditValue = lstTemp.FirstOrDefault().ID;
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
                ctrl.LoadReport(matchList, "INTEMPHU_K", this.Name, printControl1, barMau.EditValue.ToString());
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
                ctrl.LoadReport(matchList, "INTEMPHU_K", this.Name, printControl1, Temp);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            
        }
    }
}
