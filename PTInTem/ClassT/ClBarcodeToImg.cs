using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using PTInTem.Helper;

namespace PTInTem.ClassT
{
    public class ClBarcodeToImg
    {

       


        private static BarcodeLib.Barcode b = new BarcodeLib.Barcode();


        // hoangdt - chỉnh sửa lại phần typeSize
        public static byte[] BarcodeConvert(string txtBarcode, int typeSize = (int)TypeSize.Default)
        {
            try
            {
                PictureBox pc = new PictureBox();
                pc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                GroupBox barcode = new GroupBox();
                int W = 400;
                int H = 100;
                if ((int)TypeSize.Small == typeSize)
                {
                    W = 180;
                    H = 100;
                }

                b.Alignment = BarcodeLib.AlignmentPositions.CENTER;



                BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;

                try
                {
                    if (type != BarcodeLib.TYPE.UNSPECIFIED)
                    {


                        b.IncludeLabel = false;

                        b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);
                        b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                        //label alignment and position

                        //===== Encoding performed here =====
                        barcode.BackgroundImage = b.Encode(type, txtBarcode, b.ForeColor, b.BackColor, W, H);
                        //===================================

                        pc.BackgroundImage = barcode.BackgroundImage;
                        BarcodeLib.SaveTypes savetype = BarcodeLib.SaveTypes.JPG;
                        // save pictute.

                        b.SaveImage(Application.StartupPath + "\\Hinh\\" + txtBarcode + ".jpg", savetype);
                        using (var image = Image.FromFile(Application.StartupPath + "\\Hinh\\" + txtBarcode + ".jpg"))
                        using (var newImage = ScaleImage(image, 170, 100))
                        {
                            newImage.Save(Application.StartupPath + "\\Hinh\\" + txtBarcode + "resize.jpg");
                        }
                    }//if

                    //reposition the barcode image to the middle
                    barcode.Location = new Point((barcode.Location.X + barcode.Width / 2) - barcode.Width / 2, (barcode.Location.Y + barcode.Height / 2) - barcode.Height / 2);
                }//try
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }//catch
                return ImageToByte2(pc.BackgroundImage);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return new byte[] { };
            }
            
        }
        public static byte[] ImageToByte2(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
                stream.Close();
                byteArray = stream.ToArray();
            }
            return byteArray;
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }


}
