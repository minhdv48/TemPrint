using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PTInTem.ClassT;
using PTInTem.Helper.SQLite;

namespace PTInTem.Form
{
    public partial class FrmTemplateMenu : DevExpress.XtraEditors.XtraForm
    {
        public FrmTemplateMenu()
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
            var response = new TemplateMenuSQLite().SearchQuerryDB();
            // gridControl1.DataSource = Conn.XuatDL("SELECT TemplateMenu.[ID], TemplateMenu.[Menu], Menu.[Name] as NameMenu, TemplateMenu.[TemplateId], TbTemplate.[Name] as NameTem, TemplateMenu.[Font], TemplateMenu.[Size] FROM (TemplateMenu INNER JOIN Menu ON TemplateMenu.Menu = Menu.ID) INNER JOIN TbTemplate ON TemplateMenu.TemplateId = TbTemplate.ID order by Menu;");
            gridControl1.DataSource = response;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTemplateMenuAdd frm = new FrmTemplateMenuAdd();
         
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Display();
               // barButtonItem1_ItemClick(sender, e);
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int Id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                FrmTemplateMenuAdd frm = new FrmTemplateMenuAdd(Id);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Display();
                }
                   
            }
            catch { }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn chắc chắn muốn xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                    var response_delete = new TemplateMenuSQLite().Delete(Id);
                    if(response_delete)
                    {
                        Display();
                        DevExpress.XtraEditors.XtraMessageBox.Show("Xóa bản ghi thành công !");
                    }
                    else
                        DevExpress.XtraEditors.XtraMessageBox.Show("Xóa bản ghi thất bại !");
                    //  Conn.ThucThi("Delete from TbTemplate where ID=" + Id);

                }

            }
            catch { }
        }

        private void barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}