using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTInTem.ClassT
{
   public class DataSYS_MENU
    {
       public static List<SYS_MENU_Model> Data()
       {
           List<SYS_MENU_Model> lis = new List<SYS_MENU_Model>();

           SYS_MENU_Model sys = new SYS_MENU_Model();
           sys.ID = "01";
           sys.Parent_ID = null;
           sys.CAPTION_VN = "Hệ thống";
           sys.RunForm = "";
           sys.TypeShow = true;
           sys.TYPE = 0;
           sys.ICON = "system.png";
           sys.STT = 1;
           sys.IsActive = true;
           lis.Add(sys);
               sys = new SYS_MENU_Model();
               sys.ID = "0101";
               sys.Parent_ID = "01";
               sys.CAPTION_VN = "Thông tin công ty";
               sys.RunForm = "";
               sys.TypeShow = true;
               sys.TYPE = 2;
               sys.ICON = "info.png";
               sys.STT = 1;
               sys.IsActive = true;
               lis.Add(sys);

               sys = new SYS_MENU_Model();
               sys.ID = "0102";
               sys.Parent_ID = "01";
               sys.CAPTION_VN = "Danh sách mẫu tem";
               sys.RunForm = "PTInTem.Form.FrmTemplate";
               sys.TypeShow = true;
               sys.TYPE = 2;
               sys.ICON = "bangke.png";
               sys.STT = 2;
               sys.IsActive = true;
               lis.Add(sys);

               sys = new SYS_MENU_Model();
               sys.ID = "0103";
               sys.Parent_ID = "01";
               sys.CAPTION_VN = "Cài đặt mẫu tem phụ";
               sys.RunForm = "PTInTem.Form.FrmTemplateMenu";
               sys.TypeShow = true;
               sys.TYPE = 2;
               sys.ICON = "bangke.png";
               sys.STT = 3;
               sys.IsActive = true;
               lis.Add(sys);

           sys = new SYS_MENU_Model();
           sys.ID = "02";
           sys.Parent_ID = null;
           sys.CAPTION_VN = "Danh mục";
           sys.RunForm = "";
           sys.TypeShow = true;
           sys.TYPE = 0;
           sys.ICON = "bangke.png";
           sys.STT = 1;
           sys.IsActive = true;
           lis.Add(sys);

               sys = new SYS_MENU_Model();
               sys.ID = "0201";
               sys.Parent_ID = "02";
               sys.CAPTION_VN = "In tem nhãn";
               sys.RunForm = "PTInTem.Form.FrmInTemNhan";
               sys.TypeShow = true;
               sys.TYPE = 2;
               sys.ICON = "chart.png";
               sys.STT = 1;
               sys.IsActive = true;
               lis.Add(sys);

               sys = new SYS_MENU_Model();
               sys.ID = "0202";
               sys.Parent_ID = "02";
               sys.CAPTION_VN = "In tem phụ-Nhựa";
               sys.RunForm = "PTInTem.Form.FrmInTemPhu";
               sys.TypeShow = true;
               sys.TYPE = 2;
               sys.ICON = "chart.png";
               sys.STT = 2;
               sys.IsActive = true;
               lis.Add(sys);

               sys = new SYS_MENU_Model();
               sys.ID = "0203";
               sys.Parent_ID = "02";
               sys.CAPTION_VN = "In tem phụ-Mỹ phẩm";
               sys.RunForm = "PTInTem.Form.FrmInTemPhu_MP";
               sys.TypeShow = true;
               sys.TYPE = 2;
               sys.ICON = "chart.png";
               sys.STT = 3;
               sys.IsActive = true;
               lis.Add(sys);

               sys = new SYS_MENU_Model();
               sys.ID = "02030";
               sys.Parent_ID = "02";
               sys.CAPTION_VN = "In tem phụ-khác";
               sys.RunForm = "PTInTem.Form.FrmInTemPhu_Khac";
               sys.TypeShow = true;
               sys.TYPE = 2;
               sys.ICON = "chart.png";
               sys.STT = 3;
               sys.IsActive = true;
               lis.Add(sys);

               sys = new SYS_MENU_Model();
               sys.ID = "0204";
               sys.Parent_ID = "02";
               sys.CAPTION_VN = "In tem ProductCode";
               sys.RunForm = "PTInTem.Form.FrmInTemProducCode";
               sys.TypeShow = true;
               sys.TYPE = 2;
               sys.ICON = "chart.png";
               sys.STT = 4;
               sys.IsActive = true;
               lis.Add(sys);

           sys = new SYS_MENU_Model();
           sys.ID = "03";
           sys.Parent_ID = null;
           sys.CAPTION_VN = "Trợ giúp";
           sys.RunForm = "";
           sys.TypeShow = true;
           sys.TYPE = 0;
           sys.ICON = "help.png";
           sys.STT = 1;
           sys.IsActive = true;
           lis.Add(sys);

               sys = new SYS_MENU_Model();
               sys.ID = "0301";
               sys.Parent_ID = "03";
               sys.CAPTION_VN = "Thông tin liên hệ";
               sys.RunForm = "";
               sys.TypeShow = true;
               sys.TYPE = 2;
               sys.ICON = "help.png";
               sys.STT = 1;
               sys.IsActive = true;
               lis.Add(sys);
           return lis;
       }
     
    }
}
