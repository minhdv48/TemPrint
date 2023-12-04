using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PTInTem.ClassT
{
   public class IntemProductCodeEntity
    {
       public string Barcode { get; set; }
       public string ProductName { get; set; }
       public string ProductBarcode{ get; set; }
       public string UrlPath { get; set; }
       public byte[] IMG { get; set; }
    }
   public class ProductBarcodeExcel
   {
       public string Barcode { get; set; }
       public string ProductName { get; set; }
       public string ProductBarcode { get; set; }
       public int QTY { get; set; }
   }
}
