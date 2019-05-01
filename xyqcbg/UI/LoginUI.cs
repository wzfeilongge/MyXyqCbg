using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyqcbg.core;
using xyqcbg.Model;

namespace xyqcbg.UI
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
           
        }
        public static int state ;

           //登陆按钮
        private void Button1_Click(object sender, EventArgs e)
        {

            var UserName = textBox1.Text.Trim();
            var UserPwd = textBox2.Text.Trim();
          
           
           
            try
            {
                if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPwd))
                {

                    MessageBox.Show("用户名或者密码不能为空", "来自上海一区晚芳亭的某位梦幻玩家提示");
                    return;
                }
                DbTools.QueryUser(UserName, UserPwd);//变更常量
            }
            catch {
               
                MessageBox.Show("数据库异常 连接失败", "来自上海一区晚芳亭的某位梦幻玩家提示");

            }
            if (User.user != null)
            {
                if (User.user.State < 9)
                {
                    state = User.user.State;
                }
                else {
                    textBox2.Text = "";
                    textBox1.Text = "";
                    MessageBox.Show("设备已上线 请先下线");
                    return;

                }

                MessageBox.Show($"尊敬的用户欢迎您{User.user.Name}", "来自上海一区晚芳亭的某位梦幻玩家提示");
               

                
                //改变状态
                if (User.user.State == 3)
                {
                    DbTools.UpdateUserState(User.user.UserName, 30);
                    choose c = new choose();
                    c.Show();
                    this.Hide();
                    return;
                }
                else if(User.user.State==1)
                {
                    DbTools.UpdateUserState(User.user.UserName, 10);
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                    return;
                }
                else if (User.user.State == 2)
                {
                    DbTools.UpdateUserState(User.user.UserName, 20);
                    prop p = new prop();
                    p.Show();
                    this.Hide();
                    return;
                }
               
           }
            else {
                textBox2.Text = "";
                MessageBox.Show("用户名或者密码输入错误","来自上海一区晚芳亭的某位梦幻玩家提示");
                return;
            }

                 
          }

        //退出按钮
        private void Button2_Click(object sender, EventArgs e)
        {
            if (User.user!=null) {

                DbTools.UpdateUserState(User.user.UserName, state);
            }
           
            Environment.Exit(0);
        }

        //注册按钮
        private void Button3_Click(object sender, EventArgs e)
        {
            //注册功能暂时关闭
            MessageBox.Show("注册功能暂时关闭");
            return;
            //Register r = new Register();
            //r.Show();
           // this.Hide();
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {

        }

      
    }





    }


