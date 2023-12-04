using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PTInTem.ClassT;
using PTInTem.Helper;
using PTInTem.Helper.SQLite;

namespace PTInTem.Form
{
    public partial class FrmTemplateAdd : DevExpress.XtraEditors.XtraForm
    {
        ConnectionAccess Conn = new ConnectionAccess();
        public FrmTemplateAdd()
        {
            InitializeComponent();
        }
        bool IsNew = true;
        int _Id;
        public FrmTemplateAdd(int Id) : this()
        {
            try
            {
                IsNew = false;
                _Id = Id;
                var response = new TemplateSQLite().SearchQuerryDB(Id);
                txtTen.Text = response.FirstOrDefault().Name;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (IsNew)
            {
                var response = new TemplateSQLite().SearchQuerryDB();
                if (response.Where(x => x.Name == txtTen.Text).Count() > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Tên này đã tồn tại !", "Thông báo");
                    txtTen.Focus();
                    txtTen.SelectAll();
                    return;
                }
                var data = new TbTemplate
                {
                    ID = response.Count() == 0 ? 1 : response.Max(x => x.ID) + 1,
                    Name = txtTen.Text
                };
                var response_insert = new TemplateSQLite().Insert(data);
                if(response_insert)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm bản ghi thành công !");
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm bản ghi thất bại !");
            }
            else
            {
                var data = new TbTemplate
                {
                    ID = _Id,
                    Name = txtTen.Text
                };
               //Conn.ThucThi("Update TbTemplate set Name='" + txtTen.Text + "' where ID=" + _Id);
                var response_update = new TemplateSQLite().Update(data);
                if (response_update)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Cập nhật bản ghi thành công !");
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Cập nhật bản ghi thất bại !");
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmTemplateAdd_Load(object sender, EventArgs e)
        {

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}