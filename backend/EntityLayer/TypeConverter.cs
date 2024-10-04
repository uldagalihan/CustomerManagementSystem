using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace EntityLayer
{
    public static class TypeConverter
    {

       public static T Convert<T>(object input, T nullValue) {
            if (input == DBNull.Value || input == null || string.IsNullOrWhiteSpace(input.ToString()))
            {
                return nullValue;
            }
            try
            {
                return input.ChangeType<T>();
            }
            catch (InvalidCastException)
            {
                return nullValue;
            }


        }
        public static T Convert<T>(object input) {

            if (input == DBNull.Value || input == null || string.IsNullOrWhiteSpace(input.ToString())){


                return default(T);
            
            }
            return input.ChangeType<T>();
        
        }

        public static T ChangeType<T>(this object value) {
            ;
            Type typeFromHandle = typeof(T);
            typeFromHandle = Nullable.GetUnderlyingType(typeFromHandle) ?? typeFromHandle;
            if (value != null && !DBNull.Value.Equals(value)) {

                return (T)System.Convert.ChangeType(value, typeFromHandle);
            }

            return (T)value;
        }

    }
}
