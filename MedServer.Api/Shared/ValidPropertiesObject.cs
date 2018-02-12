using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedServer.Api.Shared
{
    public static class ValidPropertiesObject
    {
        public static List<string> ObjIsValid(object obj)
        {
            List<string> list = new List<string>();

            if (obj == null)
                list.Add("Object Null!");
            else
            {
                foreach (var prop in obj.GetType().GetProperties())
                {
                    object value = prop.GetValue(obj, null);

                    if (value == null)
                        list.Add(prop.Name);
                }
            }
            return list;
        }  
        
       
    }
}
