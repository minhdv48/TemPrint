namespace PTInTem.Report
{
    partial class XtraRp_InTemProductCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.lbProductCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbProductCode});
            this.Detail.HeightF = 108F;
            this.Detail.MultiColumn.ColumnSpacing = 20F;
            this.Detail.MultiColumn.ColumnWidth = 140F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbProductCode
            // 
            this.lbProductCode.AutoModule = true;
            this.lbProductCode.LocationFloat = new DevExpress.Utils.PointFloat(5F, 10F);
            this.lbProductCode.Name = "lbProductCode";
            this.lbProductCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.lbProductCode.SizeF = new System.Drawing.SizeF(140F, 73F);
            this.lbProductCode.StylePriority.UseTextAlignment = false;
            code128Generator1.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.lbProductCode.Symbology = code128Generator1;
            this.lbProductCode.Text = "420M28998D8C";
            this.lbProductCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 13F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 508F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // XtraRp_InTemProductCode
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.DetailPrintCountOnEmptyDataSource = 50;
            this.Margins = new System.Drawing.Printing.Margins(22, 0, 13, 508);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "10.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRBarCode lbProductCode;
    }
}
