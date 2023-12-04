using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using System.Linq;
using System.Reflection;
using System.IO;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Management;
using System.Diagnostics;
using PTInTem.ClassT;
using PTInTem.Helper.SQLite;
using PTInTem.Helper;
using PTIntem.SQLite;

namespace PTInTem
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public List<SYS_MENU_Model> lstSYS_MENU = new List<SYS_MENU_Model>();
        public FrmMain()
        {
           
            try
            {
                InitializeComponent();
                SQLiteService.CreateDatabase();
                lstSYS_MENU = new MenuSQLite().SearchQuerryDB();
                if (lstSYS_MENU != null && lstSYS_MENU.Count() > 0)
                {
                    // LOAD MENU
                    foreach (SYS_MENU_Model m in lstSYS_MENU.Where(n => string.IsNullOrEmpty(n.Parent_ID) && n.IsActive == true).OrderBy(n => n.STT).ToList())
                    {
                        NavBarGroup g = new NavBarGroup();
                        g.Caption = m.CAPTION_VN;
                        g.Name = m.ID;
                        g.SmallImage = imageCollection1.Images[m.ICON];
                        List<SYS_MENU_Model> list_Item = lstSYS_MENU.Where(n => n.Parent_ID == m.ID && n.IsActive == true && n.STT != null).OrderBy(o => o.STT).ToList();
                        foreach (SYS_MENU_Model chil in list_Item)
                        {
                            NavBarItem it = new NavBarItem();
                            // LOAD MENU CON
                            if (chil.TYPE == 1)
                            {
                                it.Caption = chil.CAPTION_VN;
                                it.Name = chil.ID;
                                it.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
                                it.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                                it.LinkClicked += new NavBarLinkEventHandler(Parent_LinkClicked);
                                it.SmallImage = imageCollection1.Images[chil.ICON];
                                g.ItemLinks.Add(it);
                                bool _flag = false;
                                foreach (SYS_MENU_Model children in lstSYS_MENU.Where(n => n.Parent_ID == chil.ID && n.IsActive == true).OrderBy(o => o.STT).ToList())
                                {
                                    NavBarItem item = new NavBarItem();
                                    item.Caption = "    " + children.CAPTION_VN;
                                    item.Name = children.ID;

                                    if (item.Visible) _flag = true;
                                    item.Tag = children.TypeShow;
                                    item.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F);
                                    item.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                                    item.LinkClicked += new NavBarLinkEventHandler(it_LinkClicked);
                                    item.SmallImage = imageCollection1.Images[children.ICON];
                                    g.ItemLinks.Add(item);
                                }
                                it.Visible = _flag;
                            }
                            else
                            {
                                //LOAD MENU CHA
                                it.Caption = chil.CAPTION_VN;
                                it.Name = chil.ID;
                                it.Tag = chil.TypeShow;
                                it.AppearanceHotTracked.BackColor = Color.Red;
                                it.SmallImage = imageCollection1.Images[chil.ICON];
                                it.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F);
                                it.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                                it.LinkClicked += new NavBarLinkEventHandler(it_LinkClicked);
                                g.ItemLinks.Add(it);
                            }
                        }
                        navBarControl1.Groups.Add(g);
                        g.Expanded = true;
                    }
                    foreach (NavBarGroup navg in navBarControl1.Groups)
                    {
                        if (navg.Name == "02")
                        {
                            navBarControl1.ActiveGroup = navg;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        public void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                navBarControl1.PaintStyleName = "SkinNav:Blue";
                lbTime.Text = "Công Ty Cổ Phần Phúc Thành Việt Nam  |  Ngày làm việc : " + DateTime.Today.ToShortDateString();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }


        }
        bool IsYet = true;
        void Parent_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                NavBarItem navItem = sender as NavBarItem;
                foreach (NavBarGroup g in navBarControl1.Groups)
                {
                    foreach (NavBarItemLink item in navBarControl1.Groups[g.Name].ItemLinks)
                    {
                        if (item.ItemName != navItem.Name && item.ItemName.Contains(navItem.Name))
                        {
                            item.Visible = !IsYet;
                        }
                    }
                }
                IsYet = !IsYet;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        // SỰ KIỆN CLICK LOAD FORM
        void it_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                NavBarItem it = sender as NavBarItem;
                foreach (System.Windows.Forms.Form f in this.MdiChildren)
                {
                    if (f.Name == it.Name)
                    {
                        f.Activate();
                        return;
                    }
                }
                SYS_MENU_Model menu = lstSYS_MENU.FirstOrDefault(n => n.ID == it.Name);
                Type formType = typeof(System.Windows.Forms.Form);
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (formType.IsAssignableFrom(type))
                    {
                        if (type.FullName.ToUpper() == menu.RunForm.ToUpper())
                        {
                            System.Windows.Forms.Form frm = (System.Windows.Forms.Form)Activator.CreateInstance(type);
                            frm.Name = it.Name;
                            frm.Text = it.Caption;
                            if ((bool)it.Tag)
                            {
                                frm.MdiParent = this;
                                frm.Show();
                            }
                            else frm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            panel1.Visible = false;
        }
        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            try
            {
                if (e.Page.TabControl.PageCount == 0)
                    panel1.Visible = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.L)
                    Application.Restart();
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)
                {

                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    for (int i = 0; i < xtraTabbedMdiManager1.Pages.Count; i++)
                    {
                        if (xtraTabbedMdiManager1.SelectedPage == xtraTabbedMdiManager1.Pages[i])
                        {
                            if (i + 1 == xtraTabbedMdiManager1.Pages.Count)
                                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[0];
                            else
                                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[i + 1];
                            break;
                        }
                    }
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    for (int i = 0; i < xtraTabbedMdiManager1.Pages.Count; i++)
                    {
                        if (xtraTabbedMdiManager1.SelectedPage == xtraTabbedMdiManager1.Pages[i])
                        {
                            if (i - 1 < 0)
                                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1];
                            else
                                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[i - 1];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}