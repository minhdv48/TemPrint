namespace PTInTem.Report
{
    partial class XtraRp_InTemPhu2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraRp_InTemPhu2));
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrInfo = new DevExpress.XtraReports.UI.XRRichText();
            this.lbProductName = new DevExpress.XtraReports.UI.XRLabel();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrBarCode2 = new DevExpress.XtraReports.UI.XRBarCode();
            ((System.ComponentModel.ISupportInitialize)(this.xrInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.Detail.HeightF = 172.5F;
            this.Detail.MultiColumn.ColumnSpacing = 15F;
            this.Detail.MultiColumn.ColumnWidth = 120F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            // 
            // xrPanel1
            // 
            this.xrPanel1.BorderColor = System.Drawing.Color.Silver;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.CanGrow = false;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrBarCode2,
            this.xrBarCode1,
            this.xrInfo,
            this.lbProductName});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(120F, 162.5F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.Font = new System.Drawing.Font("Times New Roman", 3F);
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(4.791577F, 143.38F);
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(86.00379F, 19.23962F);
            this.xrBarCode1.StylePriority.UseFont = false;
            this.xrBarCode1.StylePriority.UsePadding = false;
            this.xrBarCode1.Symbology = code128Generator1;
            // 
            // xrInfo
            // 
            this.xrInfo.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Top;
            this.xrInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrInfo.Font = new System.Drawing.Font("Times New Roman", 3F);
            this.xrInfo.LocationFloat = new DevExpress.Utils.PointFloat(4.999911F, 20F);
            this.xrInfo.Name = "xrInfo";
            this.xrInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 2, 100F);
            this.xrInfo.SerializableRtfString = resources.GetString("xrInfo.SerializableRtfString");
            this.xrInfo.SizeF = new System.Drawing.SizeF(105.0001F, 123.38F);
            this.xrInfo.StylePriority.UseBorders = false;
            this.xrInfo.StylePriority.UseFont = false;
            this.xrInfo.StylePriority.UsePadding = false;
            // 
            // lbProductName
            // 
            this.lbProductName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbProductName.Font = new System.Drawing.Font("Times New Roman", 4.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductName.LocationFloat = new DevExpress.Utils.PointFloat(4.999911F, 4.999998F);
            this.lbProductName.Multiline = true;
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
            this.lbProductName.SizeF = new System.Drawing.SizeF(105.0001F, 15F);
            this.lbProductName.StylePriority.UseBorders = false;
            this.lbProductName.StylePriority.UseFont = false;
            this.lbProductName.StylePriority.UsePadding = false;
            this.lbProductName.StylePriority.UseTextAlignment = false;
            this.lbProductName.Text = "GEL TẠO KIỂU TÓC SUPER HARD (Không chứa Silicon) 130G";
            this.lbProductName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 17.13699F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 6.085193F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // xrBarCode2
            // 
            this.xrBarCode2.AutoModule = true;
            this.xrBarCode2.Font = new System.Drawing.Font("Times New Roman", 3F);
            this.xrBarCode2.LocationFloat = new DevExpress.Utils.PointFloat(90.79537F, 143.38F);
            this.xrBarCode2.Module = 1F;
            this.xrBarCode2.Name = "xrBarCode2";
            this.xrBarCode2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrBarCode2.ShowText = false;
            this.xrBarCode2.SizeF = new System.Drawing.SizeF(19.20463F, 19.23962F);
            this.xrBarCode2.StylePriority.UseFont = false;
            this.xrBarCode2.StylePriority.UsePadding = false;
            this.xrBarCode2.Symbology = qrCodeGenerator1;
            this.xrBarCode2.Text = "VT 12345678";
            // 
            // XtraRp_InTemPhu2
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(31, 20, 17, 6);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportPrintOptions.DetailCountOnEmptyDataSource = 16;
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRLabel lbProductName;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule1;
        private DevExpress.XtraReports.UI.XRRichText xrInfo;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode2;
    }
}
