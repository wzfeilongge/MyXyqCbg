using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyqcbg.core;
using System.Threading;


namespace xyqcbg
{
    public partial class Form1 : Form
    {
        #region 默认初始化配置
        ListViewItem lt = null;
        ListViewItem lts = new ListViewItem();
        private Button btn = new Button();
        int page = 1;
        string[] urlArray=new string[15];
        int cont = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
        
        }

        /// <summary>
        /// 初始化程序
        /// </summary>
        /// <param name="pages"></param>
        public void init(int pages)
        {


            Thread t = new Thread(() => {
                ChangeViewList(pages);

            });
            t.IsBackground = true;
            t.Start();
        }
        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        /// <summary>
        /// 单击门派弹出购买的链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                       // string msg = listView1.Items[c[0]].SubItems[13].Text;
                        System.Diagnostics.Process.Start("chrome.exe", urls);
                      

                    }


                }
            }
            catch(Exception ecp){
                MessageBox.Show(ecp.ToString());
                
            }
        }
        
        /// <summary>
        /// 根据页面 委托更新UI
        /// </summary>
        /// <param name="page"></param>
        private void ChangeViewList(int page) {
           
                Action acion = delegate ()
                {
                    if (role.Checked)
                    {   
                        //选中的是角色
                        var xiangruiList = textBox3.Text;
                       listView1.Items.Clear();
                        var JsonMessage = GetJson.GetRoleInOmen(xiangruiList, Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox2.Text),page, IRetrunRole(textBox4.Text).ToString());
                        foreach (var data in JsonMessage)
                        {
                            if (cont == 15)
                            {
                                cont = 0;
                            }

                            
                           
                            lt = new ListViewItem();
                            if (data.school == 0)
                            {
                                //不是角色
                                lt.Text = data.equip_name;//物品信息
                               // lts[cont].Text = data.equip_name;
                            }
                            else {
                                lt.Text = RetrunRole(data.school) + "-" + data.seller_nickname;//门派
                            }
                        lt.SubItems.Add(data.equip_level_desc);//级别
                        lt.SubItems.Add(data.time_left);//剩余时间
                        lt.SubItems.Add(data.area_name + "-" + data.server_name);//大区加名字
                        lt.SubItems.Add(data.price.ToString());//价格
                        lt.SubItems.Add(data.expt_gongji + "/" + data.max_expt_gongji.ToString());    //攻击修炼
                        lt.SubItems.Add(data.expt_fangyu + "/" + data.max_expt_fangyu.ToString());//防御修炼
                        lt.SubItems.Add(data.expt_fashu + "/" + data.max_expt_fashu.ToString());//法术修炼
                        lt.SubItems.Add(data.expt_kangfa + "/" + data.max_expt_kangfa.ToString());//抗法修炼
                         ///////////////////////////////////////////////////////////////////////////////
                        lt.SubItems.Add(data.bb_expt_gongji.ToString());//宝宝攻击修炼
                        lt.SubItems.Add(data.bb_expt_fangyu.ToString());//防御修炼
                        lt.SubItems.Add(data.bb_expt_fashu.ToString());//法术修炼
                        lt.SubItems.Add(data.bb_expt_kangfa.ToString());//抗法修炼
                        var url = "https://xyq.cbg.163.com/" + "/equip?s=" + data.server_id + "&eid=" + data.eid + "&equip_refer=26&view_loc=reco_left";
                        urlArray[cont] = url; //购买链接
                       

                        cont++;
                        listView1.Items.Add(lt);
                     }
                      
                    }
                    else
                    {

                        listView1.Items.Clear();


                    }
               
            };
            if (this.InvokeRequired) {
                ControlExtensions.UIThreadInvoke(this, delegate
                {
                   
                        acion();
                    
              });

            }

           
        }
 
        /// <summary>
        /// 根据ID 判断门派
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        public string RetrunRole(int school)
        {
            string RoleName = "";

            switch (school)
            {
                case 1:
                    RoleName = "大唐官府";
                    break;
                case 2:
                    RoleName = "化生寺";
                    break;
                case 3:
                    RoleName = "女儿村";
                    break;
                case 4:
                    RoleName = "方寸山";
                    break;
                case 5:
                    RoleName = "天宫";
                    break;
                case 6:
                    RoleName = "普陀山";
                    break;
                case 7:
                    RoleName = "龙宫";
                    break;
                case 8:
                    RoleName = "五庄观";
                    break;
                case 9:
                    RoleName = "狮驼岭";
                    break;
                case 10:
                    RoleName = "魔王寨";
                    break;
                case 11:
                    RoleName = "地府";
                    break;
                case 12:
                    RoleName = "盘丝洞";
                    break;
                case 13:
                    RoleName = "神木林";
                    break;
                case 14:
                    RoleName = "凌波城";
                    break;
                case 15:
                    RoleName = "无底洞";
                    break;
                case 16:
                    RoleName = "女魃墓";
                    break;
                case 17:
                    RoleName = "天机城";
                    break;
                case 18:
                    RoleName = "花果山";
                    break;



            }




            return RoleName;

        }
        /// <summary>
        /// 根据门派号 判断是门派Id
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        public int IRetrunRole(string schoolname)
        {
            int RoleName = 0;

            switch (schoolname)
            {
                case "大唐官府":
                    RoleName = 1;
                    break;
                case "化生寺":
                    RoleName =2 ;
                    break;
                case "女儿村":
                    RoleName = 3;
                    break;
                case "方寸山":
                    RoleName = 4;
                    break;
                case "天宫":
                    RoleName = 5;
                    break;
                case "普陀山":
                    RoleName =6;
                    break;
                case "龙宫":
                    RoleName = 7;
                    break;
                case "五庄观":
                    RoleName =8;
                    break;
                case "狮驼岭":
                    RoleName = 9;
                    break;
                case "魔王寨":
                    RoleName =10;
                    break;
                case "地府":
                    RoleName = 11;
                    break;
                case "盘丝洞":
                    RoleName = 12;
                    break;
                case "神木林":
                    RoleName = 13;
                    break;
                case "凌波城":
                    RoleName = 14;
                    break;
                case "无底洞":
                    RoleName =  15;
                    break;
                case "女魃墓":
                    RoleName = 16;
                    break;
                case "天机城":
                    RoleName = 17;
                    break;
                case "花果山":
                    RoleName = 18;
                    break;



            }




            return RoleName;

        }
        /// <summary>
        /// 加载窗体时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //  MessageBox.Show("如果什么都不填，默认会搜索所有的角色 但是那个搜索角色的那个勾一定要选上 异步搜索还没开始做还不能开始自动检索，后续会更新","来自晚芳亭一位玩家的温馨提示");
            //  MessageBox.Show("本次更新了 双击名字 可以弹出购买的链接，需安装谷歌浏览器，推荐下载腾讯软件中心的");
           // MessageBox.Show("取消购买链接,新增单门派搜索");
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
           
                page -= 1;
            if (page == 0)
            {
                MessageBox.Show("已经是第一页");

            }
            else {

                init(page);
            }
               
            

        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            
            page ++;
            init(page);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            init(page);




        }

       
    }
    }
       

    
        


        
    
