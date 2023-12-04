using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PTInTem.ClassT
{
    // Hoangdt thêm mới để config số dòng của excell import
    public enum EnumRowExcell
    {
        Intem = 14,
        intemphu_MP = 20,
        intemphu_N = 15,
        intemphu_K = 17,
        intem_ProductCode = 5
    }


    // Hoangdt thêm mới để config size ảnh 
    public enum TypeSize
    {
        Default = 1,
        Small = 2,
    }

    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            try
            {

                // Get the type
                Type type = value.GetType();

                // Get fieldinfo for this type
                FieldInfo fieldInfo = type.GetField(value.ToString());

                //// Get the stringvalue attributes
                DescriptionAttribute[] attribs = fieldInfo.GetCustomAttributes(
                    typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                //// Return the first if there was a match.
                return attribs.Length > 0 ? attribs[0].Description : value.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
   
}
