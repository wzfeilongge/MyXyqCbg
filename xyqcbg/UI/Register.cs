using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyqcbg.core;

namespace xyqcbg.UI
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                var UserName = textBox3.Text;
                var UserPwd = textBox2.Text;
                var Name = textBox1.Text;
                if (string.IsNullOrEmpty(UserName)|| string.IsNullOrEmpty(UserPwd) || string.IsNullOrEmpty(Name)) {

                    MessageBox.Show("必须都要填写");
                    return;

                }
                int flag = DbTools.AddUser(UserName, UserPwd, Name);
                if (flag != 1)
                {

                    MessageBox.Show("注册失败");
                    textBox3.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                }
                else
                {


                    MessageBox.Show("注册成功");
                    textBox3.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                }

            }
            catch(Exception exce) {
                string ExcepStr = exce.ToString();

                if (ExcepStr.IndexOf("重复")!=-1) {

                    MessageBox.Show("用户名已经有人抢占拉");
                }

            }



        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginUI loginUI = new LoginUI();
            loginUI.Show();
        }
    }
}
