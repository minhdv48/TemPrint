using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PTInTem.ClassT;
using PTInTem.Helper;
using PTInTem.Helper.SQLite;

namespace PTInTem.Form
{
    public partial class FrmTemplate : DevExpress.XtraEditors.XtraForm
    {
        public FrmTemplate()
        {
            InitializeComponent();
        }
        ConnectionAccess Conn = new ConnectionAccess();
        private void FrmTemplate_Load(object sender, EventArgs e)
        {

            Display();
        }
        public void Display()
        {
            try
            {
                var lstTemp = new TemplateSQLite().SearchQuerryDB();
                gridControl1.DataSource = lstTemp;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrmTemplateAdd frm = new FrmTemplateAdd();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Display();
                   // barButtonItem1_ItemClick(sender, e);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int Id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                FrmTemplateAdd frm = new FrmTemplateAdd(Id);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Display();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn chắc chắn muốn xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                    var response = new TemplateSQLite().Delete(Id);
                    Display();
                    if (response)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Xóa bản ghi thành công !");
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Xóa bản ghi thất bại !");
                    }
                }

            }
            catch (Exception ex)
            { LogHelper.WriteLog(ex); }
        }

        private void barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}