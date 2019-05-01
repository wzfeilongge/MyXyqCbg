using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyqcbg.core;
using xyqcbg.Model;

namespace xyqcbg.UI
{
    public partial class prop : Form
    {
        public prop()
        {
            InitializeComponent();
            
        }
        ListViewItem lt;
        string[] urlArray = new string[15];
        int cont = 0;
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lt != null)
                {
                    //lts = lt;
                    int selectCount = listView1.SelectedItems.Count; ;
                    if (selectCount > 0)//选中某行
                    {
                        ListView.SelectedIndexCollection c = listView1.SelectedIndices;
                        var urls = urlArray[c[0]];
                        System.Diagnostics.Process.Start("chrome.exe", urls);


                    }


                }
            }
            catch (Exception ecp)
            {
                MessageBox.Show(ecp.ToString());

            }
        }

        //搜索物品
        private void Button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => {
                Init();

            });
            t.IsBackground = true;
            t.Start();
            
            
               
            
           
        }

        //初始化数据
        private void Init() {

            Action acion = delegate ()
            {
                if (cont == 15)
                {
                    cont = 0;
                }
                var minLever = textBox1.Text.Trim(); //物品最低等级
                var maxLever = textBox3.Text.Trim(); //物品最高等级
                int isTrue = 1;//是否是公示期物品
                if (!checkBox1.Checked)
                {

                    isTrue = 0;
                }


                //搜索的是物品
                listView1.Items.Clear();
                var JsonMessage = GetJson.GetProp(Convert.ToInt16(minLever), Convert.ToInt16(maxLever), isTrue, 1);
                foreach (var data in JsonMessage)
                {
                    lt = new ListViewItem();

                    lt.Text = data.area_name + "-" + data.server_name;//大区加名字
                    lt.SubItems.Add(data.equip_name);//物品信息
                    lt.SubItems.Add(Tools.Descprop(data.desc));//详细
                    lt.SubItems.Add(data.price.ToString());//价格
                    lt.SubItems.Add(data.time_left);
                    var url = "https://xyq.cbg.163.com/" + "equip?s=" + data.server_id + "&eid=" + data.eid + "&equip_refer=1&view_loc=reco_left";
                    urlArray[cont] = url;
                    cont++;
                    listView1.Items.Add(lt);
                }
            };

            if (this.InvokeRequired)
            {
                ControlExtensions.UIThreadInvoke(this, delegate
                {

                    acion();

                });

            }
        }
        private void Prop_closeing(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (User.user != null)
            {

                DbTools.UpdateUserState(User.user.UserName, LoginUI.state);
            }
            Environment.Exit(0);
        }

        private void Prop_Load(object sender, EventArgs e)
        {

        }
    }
}
