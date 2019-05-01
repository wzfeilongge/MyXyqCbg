using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyqcbg.Model
{
    //登陆的角色
    public  class User
    {
        public int id { get; set; }//主键Id
        public string UserName { get; set; } //用户名
       
        public string UserPwd { get; set; } // 用户密码

         public int State { get; set; } //那种类型

        public string Name { get; set; }//用户实际信息

        public static User user=null;




       
      

    }
}
