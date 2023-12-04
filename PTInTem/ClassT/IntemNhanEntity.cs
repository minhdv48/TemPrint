using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTInTem
{
    public class IntemNhanExcel
    {
        public string STT { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string DVT { get; set; }
        public decimal Price { get; set; }
        public int QTY { get; set; }
    }
    public class IntemEntity
    {
        public string STT { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string DVT { get; set; }
        public string Price { get; set; }
    }
}
