using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTInTem.ClassT
{
    public class SYS_MENU_Model
    {
        public string ID { get; set; }
        public string Parent_ID { get; set; }
        public string CAPTION_VN { get; set; }
        public string RunForm { get; set; }
        public int TYPE { get; set; }
        public bool TypeShow { get; set; }
        public string ICON { get; set; }
        public int STT { get; set; }
        public bool IsActive { get; set; }
    }

    public class TbTemplate
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }

    public class FunctionTypeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }

    public class TemplateMenuModel
    {
        public int ID { get; set; }
        public string Menu { get; set; }

        public int TemplateID { get; set; }
        public string Size { get; set; }
        public string Font { get; set; }

        public string NameTem { get; set; }
        public string NameMenu { get; set; }
    }
}
