using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using PTInTem.Helper;

namespace PTInTem.ClassT
{
    public class ImportExcelCtrl
    {
        HSSFWorkbook hssfWorkbook;
        XSSFWorkbook xssfWorkbook;

        public bool InitializeWorkbook(string path)
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            try
            {
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                if (file.Name.EndsWith("xls"))
                {
                    hssfWorkbook = new HSSFWorkbook(file);
                }
                else
                {
                    xssfWorkbook = new XSSFWorkbook(file);

                }
                return true;
            }
            catch(Exception e) { MessageBox.Show("Không thể thao tác:\n\t" + e.Message); return false; }
        }



        public object ConvertToDataTable(string _name, string filename, ref string message)
        {
            object ob = null;
            try
            {
                ISheet sheet;
                if (filename.EndsWith("xlsx"))
                {
                    sheet = xssfWorkbook.GetSheetAt(0);
                }
                else
                {
                    sheet = hssfWorkbook.GetSheetAt(0);
                }

                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                bool isGoOn = true;
                int stt = 0;
                switch (_name)
                {

                    case "INTEM":
                        {
                            List<IntemNhanExcel> productsList = new List<IntemNhanExcel>();
                            List<IntemEntity> matchList = new List<IntemEntity>();
                            while (rows.MoveNext())
                            {
                                stt++;
                                if (stt == 1) { continue; }
                                if (!isGoOn) break;
                                IRow row;
                                if (filename.EndsWith("xls")) { row = (HSSFRow)rows.Current; }
                                else { row = (XSSFRow)rows.Current; }

                                IntemNhanExcel product = new IntemNhanExcel();
                                //if ((row.Count() - 1) != (int)EnumRowExcell.Intem)
                                //    message = "File import không chính xác";

                                // sl cot cua doi tuong Product
                                int count = (int)EnumRowExcell.Intem;

                                for (int i = 0; i < count; i++)
                                {
                                    ICell cell = row.GetCell(i);
                                    string obj = null;
                                    if (cell != null) obj = cell.ToString();
                                    if (i == 0) { product.STT = obj; }
                                    else if (i == 1) { product.Barcode = obj; }
                                    else if (i == 2) { product.ProductName = obj; }
                                    else if (i == 3) { product.DVT = obj; }
                                    else if (i == 4) { try { product.Price = obj == null ? 0 : decimal.Parse(obj); } catch { product.QTY = 0; } }
                                    else if (i == 5) { try { product.QTY = obj == null ? 0 : int.Parse(obj); } catch { product.QTY = 0; } }
                                }
                                productsList.Add(product);
                            }
                            foreach (var item in productsList.Where(n => n.Barcode != "" || n.Barcode != null || n.QTY > 0).ToList())
                            {
                                for (int i = 0; i < item.QTY; i++)
                                {
                                    matchList.Add(new IntemEntity()
                                    {
                                        STT = item.STT,
                                        Barcode = item.Barcode,
                                        ProductName = item.ProductName,
                                        DVT = "VND/" + item.DVT,
                                        Price = string.Format("{0:n0}", item.Price)
                                    });
                                }

                            }
                            ob = matchList;
                            break;
                        }


                    case "INTEMPHU_MP":
                        {
                            List<IntemPhuExcel> productsList = new List<IntemPhuExcel>();
                            List<IntemPhuEntity> matchList = new List<IntemPhuEntity>();

                            // lấy dữ liệu từ file excell => object
                            while (rows.MoveNext())
                            {
                                stt++;
                                if (stt == 1) { continue; }
                                if (!isGoOn) break;
                                IRow row;
                                if (filename.EndsWith("xls")) { row = (HSSFRow)rows.Current; }
                                else { row = (XSSFRow)rows.Current; }

                                //if ((row.Count() - 1) != (int)EnumRowExcell.intemphu_MP)
                                //    message = "File import không chính xác";

                                // sl cot cua doi tuong Product
                                int count = (int)EnumRowExcell.intemphu_MP;

                                IntemPhuExcel product = new IntemPhuExcel();
                                for (int i = 0; i < count; i++)
                                {
                                    ICell cell = row.GetCell(i);
                                    string obj = null;
                                    if (cell != null) obj = cell.ToString();
                                    if (i == 0) { product.Barcode = obj; }
                                    else if (i == 1) { product.ActiveCode = obj; }
                                    else if (i == 2) { product.ProductName = obj; }
                                    else if (i == 3) { product.Description = obj; }
                                    else if (i == 4) { product.Component = obj; }
                                    else if (i == 5) { product.Quantitative = obj; }
                                    else if (i == 6) { product.Usermanual = obj; }
                                    else if (i == 7) { product.Note = obj; }
                                    else if (i == 8) { product.Preservation = obj; }
                                    else if (i == 9) { product.DayProduce = obj; }
                                    else if (i == 10) { product.ExpiredDate = obj; }
                                    else if (i == 11) { product.Origin = obj; }
                                    else if (i == 12) { product.Vendor = obj; }
                                    else if (i == 13) { product.AddressVendor = obj; }
                                    else if (i == 14) { product.Distributor = obj; }
                                    else if (i == 15) { product.AddressDistributor = obj; }
                                    else if (i == 16) { product.PhoneDistributor = obj; }
                                    else if (i == 17) { product.PubliccationNo = obj; }
                                    else if (i == 18) { try { product.QTY = obj == null ? 0 : int.Parse(obj); } catch { product.QTY = 0; } }
                                    //else if (i == 19) { product.ProductCode = obj; }
                                    else if (i == 19) { try { product.FontSize = obj == null ? 0 : float.Parse(obj); } catch { product.FontSize = 0; } }
                                }
                                productsList.Add(product);
                            }

                            // tạo template hiển thị lên lưới
                            foreach (var item in productsList.Where(n => n.Barcode != "" || n.Barcode != null).ToList())
                            {
                                string SoCongBo = "";
                                if (item.PubliccationNo != "")
                                { SoCongBo = "</br><b>*Số tiếp nhận công bố:</b> " + item.PubliccationNo; }

                                var itemPhu_template = new IntemPhuEntity()
                                {
                                    Barcode = item.Barcode,
                                    ProductName = item.ProductName,
                                    Description = "<html>"
                                                        + "<body>"
                                                        + "<span  style=" + "font-size:" + item.FontSize + "; text-align: justify;" + ">" + "<b>*Mã sản phẩm:</b> " + item.Barcode
                                                        + "</br><b>*Mô tả:</b> " + item.Description
                                                        + "</br><b>*Thành phần:</b> " + item.Component
                                                        + "</br><b>*HDSD:</b> " + item.Usermanual
                                                        + "</br><b>*Lưu ý:</b> " + item.Note
                                                        + "</br><b>*Bảo quản:</b> " + item.Preservation
                                                        + "</br><b>*Định lượng:</b> " + item.Quantitative
                                                        + "</br><b>*Ngày SX:</b> " + item.DayProduce
                                                        + "&emsp; <b>HSD:</b> " + item.ExpiredDate
                                                        + "</br><b>*Xuất xứ:</b> " + item.Origin
                                                        + "</br><b>*Nhà sản xuất:</b> " + item.Vendor
                                                        + "</br>ĐC: " + item.AddressVendor
                                                        + "</br><b>*NK & PP:</b> " + item.Distributor
                                                        + "</br>ĐC : " + item.AddressDistributor
                                                        + "</br>Điện thoại: " + item.PhoneDistributor
                                                        + SoCongBo
                                                         + "</span>"
                                                         + "</body>"
                                                         + "</html>",
                                    ProductCode = string.IsNullOrEmpty(item.ProductCode) ? item.ProductCode : item.ProductCode.Replace("'", ""),
                                    ActiveCode = string.IsNullOrEmpty(item.ActiveCode) ? item.ActiveCode : item.ActiveCode.Replace("'", ""),
                                    //Description = "<html>"
                                    //                    + "<body>"
                                    //                   //+ "<span style='" + "font-size:" + (item.FontSize + 1) + "; text-align: justify;" + "'><strong>Tên sản phẩm: Chảo sứ 7 lớp </strong>"
                                    //                   //+ "<br/><strong>Chameleon thượng hạng Hàn Quốc</strong></span>"
                                    //                   + "<br/><span style=" + "font-size:" + item.FontSize + "; text-align: justify;" + "><strong>Mã hàng hoá: </strong>KR-WOKPAN-IH-28cm"
                                    //                   + "<br/><strong>Chất liệu: </strong>Chảo làm bằng Nhôm đúc nguyên khối, tráng sứ (ceramic) chống dính cac cấp, đặc biệt sử dụng vật liệu cảm biến nhiệt thế hệ mới thân thiện với môi trường, thay đổi màu khi có tác dụng của nhiệt (Đã được Hoa Kỳ chứng nhận không gây độc hại), tay cầm bằng nhựa."
                                    //                   + "<br/><strong>Sử dụng: </strong>Với bếp từ, bếp gas, bếp hồng ngoại."
                                    //                   + "<br/><strong>Kích thước:</strong><br/>(Đáy x miệng x cao = 15,6 x 28 x 11 cm)."
                                    //                     + "<br/><strong>Xuất xứ : </strong>Hàn Quốc."
                                    //                     + "<br/><strong>NK & PP bởi:</strong><br/>Công ty Phúc Thành Việt Nam."
                                    //                      + "<br/><strong>Địa chỉ:</strong> Số 4 ngõ 141 Trương Định, phường Trương Định, Quận Hai Bà Trưng, Hà Nội.</span>"
                                    //                      + "</body>"
                                    //                     + "</html>",
                                    //ProductCode = "8809300940139"
                                };


                                matchList.AddRange(Enumerable.Repeat(itemPhu_template, item.QTY == 0? 1: item.QTY).ToList());
                            }
                            ob = matchList;


                            break;
                        }



                    case "INTEMPHU_N":
                        {
                            List<IntemPhuExcel> productsList = new List<IntemPhuExcel>();
                            List<IntemPhuEntity> matchList = new List<IntemPhuEntity>();

                            // lấy dữ liệu từ file excell => object
                            while (rows.MoveNext())
                            {
                                stt++;
                                if (stt == 1) { continue; }
                                if (!isGoOn) break;
                                IRow row;
                                if (filename.EndsWith("xls")) { row = (HSSFRow)rows.Current; }
                                else { row = (XSSFRow)rows.Current; }
                                //if ((row.Count() - 1) != (int)EnumRowExcell.intemphu_N)
                                //    message = "File import không chính xác";
                                // sl cot cua doi tuong Product
                                int count = (int)EnumRowExcell.intemphu_N;

                                IntemPhuExcel product = new IntemPhuExcel();
                                for (int i = 0; i < count; i++)
                                {
                                    ICell cell = row.GetCell(i);
                                    string obj = null;
                                    if (cell != null) obj = cell.ToString();
                                    if (i == 0) { product.Barcode = obj; }
                                    else if (i == 1) { product.ProductName = obj; }
                                    else if (i == 2) { product.Description = obj; }
                                    else if (i == 3) { product.Component = obj; }
                                    else if (i == 4) { product.Quantitative = obj; }
                                    else if (i == 5) { product.Origin = obj; }
                                    else if (i == 6) { product.Vendor = obj; }
                                    else if (i == 7) { product.AddressVendor = obj; }
                                    else if (i == 8) { product.Distributor = obj; }
                                    else if (i == 9) { product.AddressDistributor = obj; }
                                    else if (i == 10) { product.PhoneDistributor = obj; }
                                    else if (i == 11) { product.PubliccationNo = obj; }
                                    else if (i == 12) { try { product.QTY = obj == null ? 0 : int.Parse(obj); } catch { product.QTY = 0; } }
                                    else if (i == 13) { product.ProductCode = obj; }
                                    else if (i == 14) { try { product.FontSize = obj == null ? 0 : float.Parse(obj); } catch { product.FontSize = 0; } }
                                }
                                productsList.Add(product);
                            }

                            // tạo template hiển thị lên lưới
                            foreach (var item in productsList.Where(n => n.Barcode != "" || n.Barcode != null || n.QTY > 0).ToList())
                            {
                                string SoCongBo = "";
                                if (!string.IsNullOrEmpty(item.PubliccationNo))
                                {
                                    SoCongBo = "</br><b>*Số tiếp nhận công bố:</b> " + item.PubliccationNo;
                                }

                                var itemPhu_template = new IntemPhuEntity()
                                {
                                    Barcode = item.Barcode,
                                    ProductName = item.ProductName,
                                    Description = "<html>"
                                                        + "<body>"
                                                        + "<span id=\"test\" text-align=" + "justify" + " style=" + "font-size:" + item.FontSize + ";" + ">" + "<b>*Mã sản phẩm:</b> " + item.Barcode
                                                        + "</br><b>*Mô tả:</b> " + item.Description
                                                        + "</br><b>*Thành phần:</b> " + item.Component
                                                        + "</br><b>*Kích thước:</b> " + item.Quantitative
                                                        + "</br><b>*Xuất xứ:</b> " + item.Origin
                                                        + "</br><b>*Nhà sản xuất:</b> " + item.Vendor
                                                        + "</br>ĐC: " + item.AddressVendor
                                                        + "</br><b>*NK & PP:</b> " + item.Distributor
                                                        + "</br>ĐC : " + item.AddressDistributor
                                                        + "</br>Điện thoại: " + item.PhoneDistributor
                                                        + SoCongBo
                                                        + "</span>"
                                                         + "</body>"
                                                         + "</html>",
                                    ProductCode = string.IsNullOrEmpty(item.ProductCode) ? item.ProductCode : item.ProductCode.Replace("'", ""),
                                };
                                matchList.AddRange(Enumerable.Repeat(itemPhu_template, item.QTY).ToList());
                            }
                            ob = matchList;
                            break;
                        }



                    case "INTEMPHU_K":
                        {
                            List<IntemPhuExcel> productsList = new List<IntemPhuExcel>();
                            List<IntemPhuEntity> matchList = new List<IntemPhuEntity>();
                            while (rows.MoveNext())
                            {
                                stt++;
                                if (stt == 1) { continue; }
                                if (!isGoOn) break;
                                IRow row;
                                if (filename.EndsWith("xls")) { row = (HSSFRow)rows.Current; }
                                else { row = (XSSFRow)rows.Current; }
                                var temp = row.Count();
                                //if ((row.Count() - 1) != (int)EnumRowExcell.intemphu_K)
                                //    message = "File import không chính xác";
                                IntemPhuExcel product = new IntemPhuExcel();
                                int count = (int)EnumRowExcell.intemphu_K;// sl cot cua doi tuong Product
                                for (int i = 0; i < count; i++)
                                {
                                    ICell cell = row.GetCell(i);
                                    string obj = null;
                                    if (cell != null) obj = cell.ToString();
                                    if (i == 0) { product.Barcode = obj; }
                                    else if (i == 1) { product.ProductName = obj; }
                                    else if (i == 2) { product.Description = obj; }
                                    else if (i == 3) { product.Component = obj; }
                                    else if (i == 4) { product.Quantitative = obj; }
                                    else if (i == 5) { product.Origin = obj; }
                                    else if (i == 6) { product.Vendor = obj; }
                                    else if (i == 7) { product.AddressVendor = obj; }
                                    else if (i == 8) { product.Distributor = obj; }
                                    else if (i == 9) { product.AddressDistributor = obj; }
                                    else if (i == 10) { product.PhoneDistributor = obj; }
                                    else if (i == 11) { product.PubliccationNo = obj; }
                                    else if (i == 12) { product.DayProduce = obj; }
                                    else if (i == 13) { product.ExpiredDate = obj; }
                                    else if (i == 14) { try { product.QTY = obj == null ? 0 : int.Parse(obj); } catch { product.QTY = 0; } }
                                    else if (i == 15) { product.ProductCode = obj; }
                                    else if (i == 16) { try { product.FontSize = obj == null ? 0 : float.Parse(obj); } catch { product.FontSize = 0; } }
                                }
                                productsList.Add(product);
                            }
                            foreach (var item in productsList.Where(n => n.Barcode != "" || n.Barcode != null || n.QTY > 0).ToList())
                            {
                                string SoCongBo = "";
                                if (!string.IsNullOrEmpty(item.PubliccationNo))
                                { SoCongBo = "</br><b>*Số tiếp nhận công bố:</b> " + item.PubliccationNo; }
                                var itemPhu_template = new IntemPhuEntity()
                                {
                                    Barcode = item.Barcode,
                                    ProductName = item.ProductName,
                                    Description = "<html>"
                                                        + "<body>"
                                                        + "<span text-align=" + "justify" + " style=" + "font-size:" + item.FontSize + ";" + ">" + "<b>*Mã sản phẩm:</b> " + item.Barcode
                                                        + "</br><b>*Mô tả:</b> " + item.Description
                                                        + "</br><b>*Thành phần:</b> " + item.Component
                                                        + "</br><b>*Kích thước:</b> " + item.Quantitative
                                                        + "</br><b>*Ngày SX:</b> " + item.DayProduce
                                                        + "&emsp; <b>HSD:</b> " + item.ExpiredDate
                                                        + "</br><b>*Xuất xứ:</b> " + item.Origin
                                                        + "</br><b>*Nhà sản xuất:</b> " + item.Vendor
                                                        + "</br>ĐC: " + item.AddressVendor
                                                        + "</br><b>*NK & PP:</b> " + item.Distributor
                                                        + "</br>ĐC : " + item.AddressDistributor
                                                        + "</br>Điện thoại: " + item.PhoneDistributor
                                                        + SoCongBo
                                                        + "</span>"
                                                        + "</body>"
                                                        + "</html>",
                                    ProductCode = string.IsNullOrEmpty(item.ProductCode) ? item.ProductCode : item.ProductCode.Replace("'", ""),
                                };

                                matchList.AddRange(Enumerable.Repeat(itemPhu_template, item.QTY).ToList());

                            }
                            ob = matchList;

                            break;
                        }



                    case "INTEMPB":
                        {
                            List<ProductBarcodeExcel> productsList = new List<ProductBarcodeExcel>();
                            List<IntemProductCodeEntity> matchList = new List<IntemProductCodeEntity>();
                            while (rows.MoveNext())
                            {
                                stt++;
                                if (stt == 1) { continue; }
                                if (!isGoOn) break;
                                IRow row;
                                if (filename.EndsWith("xls")) { row = (HSSFRow)rows.Current; }
                                else { row = (XSSFRow)rows.Current; }

                                ProductBarcodeExcel product = new ProductBarcodeExcel();
                                int count = 5;// sl cot cua doi tuong Product
                                for (int i = 0; i < count; i++)
                                {

                                    ICell cell = row.GetCell(i);
                                    string obj = null;
                                    if (cell != null) obj = cell.ToString();
                                    if (i == 0) { product.Barcode = obj; }
                                    else if (i == 1) { product.ProductName = obj; }
                                    else if (i == 2) { product.ProductBarcode = obj; }
                                    else if (i == 3) { try { product.QTY = obj == null ? 0 : int.Parse(obj); } catch { product.QTY = 0; } }


                                }
                                productsList.Add(product);
                            }
                            foreach (var item in productsList.Where(n => n.Barcode != "" || n.Barcode != null || n.QTY > 0).ToList())
                            {
                                var itemPhu_template = new IntemProductCodeEntity()
                                {
                                    Barcode = item.Barcode,
                                    ProductBarcode = item.ProductBarcode,
                                    IMG = ClBarcodeToImg.BarcodeConvert(item.ProductBarcode, (int)TypeSize.Default),
                                    UrlPath = Application.StartupPath + "\\Hinh\\" + item.ProductBarcode + ".jpg"
                                };
                                matchList.AddRange(Enumerable.Repeat(itemPhu_template, item.QTY).ToList());
                            }
                            ob = matchList;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                message = "File import không chính xác";
            }


            return ob;
        }





    }

}
