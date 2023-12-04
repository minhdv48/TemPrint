using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;

namespace PTInTem.ClassT
{
  public  class FunctionCtrl
    {
      public static string Font_N = "5.25";
      public static string Font_K = "5.25";
      public static string Font_MP = "4.5";
      public void FomartNumNer(params TextEdit[] arrayTextQty)
      {
          foreach (TextEdit txt in arrayTextQty)
          {
              txt.Properties.Mask.EditMask = "n2";
              txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
          }
      }
      public void FormatValueNumber(params TextEdit[] arrayTextNumber)
      {
          foreach (TextEdit txt in arrayTextNumber)
          {
              txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
              txt.Properties.Mask.EditMask = "n2" ;
              txt.EditValueChanged += new EventHandler(txt_EditValueChanged);
          }
      }

      void txt_EditValueChanged(object sender, EventArgs e)
      {
          TextEdit txt = sender as TextEdit;
          txt.Text = string.Format("{0:n2", double.Parse(txt.Text));
      }
    }

}
