using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PTInTem.ClassT;
namespace PTInTem.Report
{
    public partial class XtraRp_InTem : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRp_InTem()
        {
            InitializeComponent();
        }
        public void BinData()
        {
            lbProductName.DataBindings.Add("Text", DataSource, "ProductName");
            lbBarcode.DataBindings.Add("Text", DataSource, "Barcode");
            lbDVT.DataBindings.Add("Text", DataSource, "DVT");
            lbHang.DataBindings.Add("Text", DataSource, "STT");
            lbPrice.DataBindings.Add("Text", DataSource, "Price");
        }
    }
}
