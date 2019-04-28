using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace xyqcbg.core
{
     public class Tools
    {
                     

        //返回总经验
        public  static string DescReturn(string desc) {
           
            if (string.IsNullOrEmpty(desc.ToString())) {

                return null;
            }
            var newDesc = desc;
            int index = newDesc.IndexOf("sum_exp");
            newDesc = newDesc.Substring(index+9,3);
            //int sum_exp = Convert.ToInt16(newDesc);
            if (newDesc.Contains(",")){

                newDesc = newDesc.Replace(",", "");
            }
            if (newDesc.Contains("\"")){

                newDesc = newDesc.Replace("\"", "");
            }







            return newDesc; 

           }



       

    }
}
