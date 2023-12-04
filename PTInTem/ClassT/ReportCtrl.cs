using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using PTInTem.Helper.SQLite;
using PTInTem.Report;

namespace PTInTem.ClassT
{
    public class ReportCtrl
    {
        // load in tem productCode và intem
        public void LoadReport(object ob, string _name, DevExpress.XtraPrinting.Control.PrintControl print, string Temp)
        {
            try
            {
                switch (_name)
                {
                    case "INTEM":               //In tem nhan
                        {
                            XtraRp_InTem rpt = new XtraRp_InTem();
                            rpt.Name = "XtraRp_InTem";
                            try
                            {
                                rpt.LoadLayout("Report\\XtraRp_InTem" + Temp + ".repx");
                            }
                            catch
                            { }
                            List<IntemEntity> lst = ob as List<IntemEntity>;
                            rpt.DataSource = lst.ToList();
                            rpt.BinData();
                            print.Tag = rpt;
                            print.PrintingSystem = rpt.PrintingSystem;
                            rpt.CreateDocument();
                            break;
                        }
                    case "INTEMPB":             // In tem ProductCode
                        {
                            XtraRp_InTemProductCode rpt = new XtraRp_InTemProductCode();
                            rpt.Name = "XtraRp_InTemProductCode";
                            try
                            {
                                rpt.LoadLayout("Report\\XtraRp_InTemProductCode" + Temp + ".repx");
                            }
                            catch
                            { }

                            List<IntemProductCodeEntity> lst = ob as List<IntemProductCodeEntity>;
                            rpt.DataSource = lst.ToList();
                            rpt.BinData();
                            print.Tag = rpt;
                            print.PrintingSystem = rpt.PrintingSystem;
                            rpt.CreateDocument();

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Helper.LogHelper.WriteLog(ex);
            }

        }

        // Load in tem mĩ phẩm, nhựa
        public void LoadReport(object ob, string _name, string _Menu, DevExpress.XtraPrinting.Control.PrintControl print, string TemplateId)
        {
            try
            {
                string FontMP = FunctionCtrl.Font_MP;
                string FontN = FunctionCtrl.Font_N;
                string FontK = FunctionCtrl.Font_K;
                var temp_lstTemplateMenu = new TemplateMenuSQLite().SearchQuerryDB();
                var temp = temp_lstTemplateMenu.Where(x => x.Menu == _Menu && x.TemplateID.ToString() == TemplateId).ToList();
                if (temp != null && temp.Count() > 0)
                {
                    FontK = FontN = FontMP = temp.FirstOrDefault().Font;
                }

                switch (_name)
                {

                    case "INTEMPHU_N":          // in tem phụ nhựa
                        {
                            XtraRp_InTemPhu rpt = new XtraRp_InTemPhu();
                            rpt.Name = "XtraRp_InTemPhu";
                            try
                            {
                                rpt.LoadLayout("Report\\XtraRp_InTemPhu" + TemplateId + ".repx");
                            }
                            catch
                            { }
                            List<IntemPhuEntity> lst = ob as List<IntemPhuEntity>;

                            var tolist = lst.Select(n => new
                            {
                                n.ProductName,
                                Description = n.Description.Replace("font-size:0", "font-size:" + FontMP),
                                n.ProductCode
                            }).ToList();
                            rpt.DataSource = tolist.ToList();
                            rpt.BinData();
                            print.Tag = rpt;
                            print.PrintingSystem = rpt.PrintingSystem;
                            rpt.CreateDocument();

                            break;
                        }

                    case "INTEMPHU_MP":         // in tem phụ mĩ phẩm
                        {
                            XtraRp_InTemPhu rpt = new XtraRp_InTemPhu();
                            rpt.Name = "XtraRp_InTemPhu_MP";
                            try
                            {
                                rpt.LoadLayout("Report\\XtraRp_InTemPhu_MP" + TemplateId + ".repx");
                            }
                            catch(Exception e)
                            { }
                            List<IntemPhuEntity> lst = ob as List<IntemPhuEntity>;

                            var tolist = lst.Select(n => new
                            {
                                n.ProductName,
                                Description = n.Description.Replace("font-size:0", "font-size:" + FontMP),
                                n.ProductCode,
                                n.ActiveCode
                            }).ToList();
                            rpt.DataSource = tolist.ToList();
                            rpt.BinData();
                            print.Tag = rpt;
                            print.PrintingSystem = rpt.PrintingSystem;
                            rpt.CreateDocument();
                            break;
                        }

                    case "INTEMPHU_K":          // in tem phụ khác
                        {
                            XtraRp_InTemPhu rpt = new XtraRp_InTemPhu();
                            rpt.Name = "XtraRp_InTemPhu_K";
                            try
                            {
                                rpt.LoadLayout("Report\\XtraRp_InTemPhu_K" + TemplateId + ".repx");
                            }
                            catch
                            { }
                            List<IntemPhuEntity> lst = ob as List<IntemPhuEntity>;

                            var tolist = lst.Select(n => new
                            {
                                n.ProductName,
                                Description = n.Description.Replace("font-size:0", "font-size:" + FontK),
                                n.ProductCode
                            }).ToList();
                            rpt.DataSource = tolist.ToList();
                            rpt.BinData();
                            print.Tag = rpt;
                            print.PrintingSystem = rpt.PrintingSystem;
                            rpt.CreateDocument();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Helper.LogHelper.WriteLog(ex);
            }
        }
    }
}
