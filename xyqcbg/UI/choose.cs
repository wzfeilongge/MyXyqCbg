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
using xyqcbg.Model;

namespace xyqcbg.UI
{
    public partial class choose : Form
    {
        public choose()
        {
            
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            prop p = new prop();
            p.Show();
            this.Close();
        }

        private void Choose_Load(object sender, EventArgs e)
        {
            this.Text = "尊敬的"+User.user.Name+"请选择";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (User.user != null)
            {

                DbTools.UpdateUserState(User.user.UserName, LoginUI.state);
            }

            Environment.Exit(0);
        }
    }
}
