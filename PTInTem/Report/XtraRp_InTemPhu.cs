using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;

namespace PTInTem.Report
{
    public partial class XtraRp_InTemPhu : DevExpress.XtraReports.UI.XtraReport
    {
        private object imgBarcode;

        public XtraRp_InTemPhu()
        {
            InitializeComponent();
        }
        public void BinData()
        {
            lbProductName.DataBindings.Add("Text", DataSource, "ProductName");
            xrInfo.DataBindings.Add("Html", DataSource, "Description");
            xrBarCode1.DataBindings.Add("Text", DataSource, "ProductCode");
            xrBarCode2.DataBindings.Add("Text", DataSource, "ActiveCode");
        }
        public XRBarCode CreateQRCodeBarCode(string BarCodeText)
        {
            // Create a bar code control.
            XRBarCode barCode = new XRBarCode();

            // Set the bar code's type to QRCode.
            barCode.Symbology = new QRCodeGenerator();

            // Adjust the bar code's main properties.
            barCode.Text = BarCodeText;
            barCode.Width = 400;
            barCode.Height = 150;

            // If the AutoModule property is set to false, uncomment the next line.
            barCode.AutoModule = true;
            // barcode.Module = 3;

            // Adjust the properties specific to the bar code type.
            ((QRCodeGenerator)barCode.Symbology).CompactionMode = QRCodeCompactionMode.AlphaNumeric;
            ((QRCodeGenerator)barCode.Symbology).ErrorCorrectionLevel = QRCodeErrorCorrectionLevel.H;
            ((QRCodeGenerator)barCode.Symbology).Version = QRCodeVersion.AutoVersion;

            return barCode;
        }
    }
}
