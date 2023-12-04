using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTInTem.ClassT
{
   public class IntemPhuEntity
    {
        public string Barcode { get; set; }
        public string ActiveCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Component { get; set; }
        public string Quantitative { get; set; }
        public string Usermanual { get; set; }
        public string Note { get; set; }
        public string Preservation { get; set; }
        public string DayProduce { get; set; }
        public string ExpiredDate { get; set; }
        public string Origin { get; set; }
        public string Vendor { get; set; }
        public string AddressVendor { get; set; }
        public string Distributor { get; set; }
        public string AddressDistributor { get; set; }
        public string PhoneDistributor { get; set; }
        public string PubliccationNo { get; set; }

        public string ProductCode { get; set; }
        public string ImgProductCode { get; set; }

        public float FontSize { get; set; }
    }
    public class IntemPhuExcel
    {
        public string Barcode { get; set; }
        public string ActiveCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Component { get; set; }
        public string Quantitative { get; set; }
        public string Usermanual { get; set; }
        public string Note { get; set; }
        public string Preservation { get; set; }
        public string DayProduce { get; set; }
        public string ExpiredDate { get; set; }
        public string Origin { get; set; }
        public string Vendor { get; set; }
        public string AddressVendor { get; set; }
        public string Distributor { get; set; }
        public string AddressDistributor { get; set; }
        public string PhoneDistributor { get; set; }
        public string PubliccationNo { get; set; }
        public int QTY { get; set; }
        public string ProductCode { get; set; }

        public float FontSize { get; set; }
    }
}
