using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace PTInTem.Report
{
    public partial class XtraRp_InTemProductCode : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRp_InTemProductCode()
        {
            InitializeComponent();
        }
        public void BinData()
        {
            lbProductCode.DataBindings.Add("Text", DataSource, "ProductBarcode");

        }

    }
}
