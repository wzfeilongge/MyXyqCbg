using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xyqcbg.Model;

namespace xyqcbg.core
{
    public class DbTools
    {

        //用户名  密码返回对象
        public static void  QueryUser(string name, string pwd)
        {
            using (var context = new UsersContext())
            {

                User.user = context.Users.SingleOrDefault((u) => u.UserName == name && u.UserPwd == pwd);
                

           }
            
          
        }
        //注册用户
        public static int AddUser(string name, string pwd,string UserName,int state=1)
        {
            using (var context = new UsersContext())
            {

                // User.user = context.Users.SingleOrDefault((u) => u.UserName == name && u.UserPwd == pwd);
                var NewUser = new User
                {
                    Name=name,
                    UserPwd=pwd,
                    UserName=UserName,
                    State=state

                };
                context.Users.Add(NewUser);
             
               
                return context.SaveChanges();
            }


        }

        //更新数据库状态
        public static int UpdateUserState(string username,int state)
        {
            using (var context = new UsersContext())
            {

                //User.user = context.Users.SingleOrDefault((u) => u.UserName == name && u.UserPwd == pwd);
                var user = context.Users.Where(u => u.UserName == username).FirstOrDefault();
                if (user!=null) {
                    user.State = state;
                    return context.SaveChanges();
                }

                return 0;

            }


        }





    }
}
