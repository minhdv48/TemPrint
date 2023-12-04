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
using PTInTem.Helper.SQLite;

namespace PTInTem.Form
{
    public partial class FrmTemplateMenuAdd : DevExpress.XtraEditors.XtraForm
    {
        ConnectionAccess Conn = new ConnectionAccess();
        FunctionCtrl fun = new FunctionCtrl();
        public FrmTemplateMenuAdd()
        {
            InitializeComponent();
        }
        bool IsNew = true;
        int _Id;
        public FrmTemplateMenuAdd(int Id)
            : this()
        {
            IsNew = false;
            _Id = Id;
            lookupMenu.Properties.ReadOnly = true;
            lookupTem.Properties.ReadOnly = true;
            var response_templatemenu = new TemplateMenuSQLite().SearchQuerryDB(_Id);
            if(response_templatemenu != null && response_templatemenu.Count > 0)
            {
                lookupMenu.EditValue = response_templatemenu.First().Menu;// Conn.GiaTriString("select Menu from TemplateMenu where ID=" + Id);
                lookupTem.EditValue = response_templatemenu.First().ID;// Conn.GiaTriString("select TemplateId from TemplateMenu where ID=" + Id);
                txtFont.Text = response_templatemenu.First().Font.ToString();// Conn.GiaTriString("select [Font] from TemplateMenu where ID=" + Id);
                txtSize.Text = response_templatemenu.First().Size;// Conn.GiaTriString("select [Size] from TemplateMenu where ID=" + Id);
            }
           
        }
        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (lookupMenu.EditValue == null || lookupTem.EditValue== null || txtFont.Text=="" || txtSize.Text=="")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập dữ liệu !", "Thông báo");
                return;
            }

            if (IsNew)
            {
                var response = new TemplateMenuSQLite().SearchQuerryDB();
                if(response.Where(x => x.Menu == lookupMenu.EditValue.ToString() && x.TemplateID.ToString() == lookupTem.EditValue.ToString()).Count() > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Dữ liệu này đã tồn tại !", "Thông báo");
                    return;
                }
                var input = new TemplateMenuModel()
                {
                     ID = response.Count() == 0 ? 1 : response.Max(x => x.ID) + 1,
                     Menu = lookupMenu.EditValue.ToString(),
                     TemplateID = Convert.ToInt32(lookupTem.EditValue.ToString()),
                     Font = txtFont.Text,
                     Size = txtSize.Text
                };
                // Conn.ThucThi("Insert Into TemplateMenu ([Menu],[TemplateId],[Font],[Size]) values ('" + lookupMenu.EditValue.ToString() + "','" + lookupTem.EditValue.ToString() + "','" + txtFont.Text + "','" + txtSize.Text + "')");
                var response_insert = new TemplateMenuSQLite().Insert(input);
                if (response_insert)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm bản ghi thành công !");
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm bản ghi thất bại !");
            }
            else
            {
                // Conn.ThucThi("Update TemplateMenu set [Font]='" + txtFont.Text + "' ,[Size]='"+txtSize.Text+"' where [ID]=" + _Id);
                var input = new TemplateMenuModel()
                {
                    ID = _Id,
                    Font = txtFont.Text,
                    Size = txtSize.Text
                };
                var response_update = new TemplateMenuSQLite().Update(input);
                if (response_update)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Cập nhật bản ghi thành công !");
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Cập nhật bản ghi thất bại !");
            }
            DialogResult = DialogResult.OK;
        }

        private void FrmTemplateAdd_Load(object sender, EventArgs e)
        {
            lookupMenu.Properties.DataSource = new FunctionTypeSQLite().SearchQuerryDB() ;//Conn.XuatDL("Select * from Menu");
            lookupTem.Properties.DataSource = new TemplateSQLite().SearchQuerryDB(); ;//Conn.XuatDL("Select * from TbTemplate");
            fun.FomartNumNer(txtFont);

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}