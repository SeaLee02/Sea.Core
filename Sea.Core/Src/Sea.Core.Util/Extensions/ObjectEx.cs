using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util.Extensions
{
    public static class ObjectEx
    {
        public static TOut ObjectMapTo<TOut>(this object tIn, TOut tOut = null) where TOut : class
        {
            tOut = (tOut ?? Activator.CreateInstance<TOut>());
            PropertyInfo[] properties = tOut.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                PropertyInfo[] properties2 = tIn.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo2 in properties2)
                {
                    if (propertyInfo.Name.ToLower().Equals(propertyInfo2.Name.ToLower(), StringComparison.Ordinal))
                    {
                        object value = propertyInfo2.GetValue(tIn);
                        if (value == null)
                        {
                            break;
                        }
                        if (value != null && (string.IsNullOrEmpty(value.ToString()) || value.ToString() == "00000000-0000-0000-0000-000000000000"))
                        {
                            propertyInfo.SetValue(tOut, null);
                        }
                        else
                        {
                            propertyInfo.SetValue(tOut, value);
                        }
                    }
                }
            }
            FieldInfo[] fields = tOut.GetType().GetFields();
            foreach (FieldInfo fieldInfo in fields)
            {
                FieldInfo[] fields2 = tIn.GetType().GetFields();
                foreach (FieldInfo fieldInfo2 in fields2)
                {
                    if (fieldInfo.Name.ToLower().Equals(fieldInfo2.Name.ToLower(), StringComparison.Ordinal))
                    {
                        object value2 = fieldInfo2.GetValue(tIn);
                        if (value2 != null)
                        {
                            fieldInfo.SetValue(tOut, value2);
                        }
                        break;
                    }
                }
            }
            return tOut;
        }
    }
}