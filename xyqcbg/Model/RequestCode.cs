using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyqcbg.Model
{
    public class RequestCode
    {
        public string act { get; set; }
        public string highlights{get;set;}
        public  int server_id { get; set; }
        public  int areaid { get; set; }
        public  string server_name { get; set; }
        public  int page { get; set; }
        public  string query_order { get; set; }
        public  string view_loc { get; set; }
        public  int count { get; set; }
        public  int kindid { get; set; }
        public  string xiangrui_list { get; set; }//祥瑞参数
        public  string search_type { get; set; } //筛选类型 默认为角色
        public string server_type { get; set; } //服务器年份 3=3年外 默认3年外
        public int level_min { get; set; } //设置条件的最低等级
        public int level_max { get; set; } //设置条件的最高等级
        public int child_skill_num_min { get; set;}//技能数量
        public int child_skill_num_max { get; set; } //技能等级       
        public string limit_clothes { get; set; } //锦衣
        public string limit_clothes_logic { get; set; }// 全部满足还是单个满足
        public int expt_total { get; set; }//宝宝修总和
        public int qian_yuan_dan { get; set; }//乾元丹
        public int price_min { get; set; }//最小价格
        public int price_max { get; set; }//最大价格
        public string pet_type_list { get; set; }//召唤兽类型集合
        public string equip_duanzao_attrlv_8 { get; set; } //锻造等级高于8的装备
        public string school { get; set; }

        /// <summary>
        /// 查询175所有的账号
        /// </summary>
        /// <param name="act"></param>
        /// <param name="server_id"></param>
        /// <param name="areaid"></param>
        /// <param name="server_name"></param>
        /// <param name="page"></param>
        /// <param name="query_order"></param>
        /// <param name="view_loc"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static RequestCode req(int count,  int level_min = 175, int level_max = 175, int child_skill_num_min = 0, int child_skill_num_max = 10,string act = "recommd_by_role", int page = 1 ,string search_type= "overall_search_role",string view_loc= "overall_search" ) {
            RequestCode requests = new RequestCode();
            requests.search_type = search_type;
            requests.act = act;
            requests.level_min = level_min;
            requests.level_max = level_max;
            requests.child_skill_num_max = child_skill_num_max;
            requests.child_skill_num_min = child_skill_num_min;
            requests.page = page;
            requests.view_loc = view_loc;
            requests.count = count;
            
            return requests;
        }
        /// <summary>
       /// 筛选晚芳亭内所有的角色
       /// </summary>
       /// <param name="act"></param>
       /// <param name="server_id"></param>
       /// <param name="areaid"></param>
       /// <param name="server_name"></param>
       /// <param name="page"></param>
       /// <param name="view_loc"></param>
       /// <param name="count"></param>
       /// <param name="kindid"></param>
       /// <returns></returns>
        public static RequestCode reqRole(string act, int server_id, int areaid, string server_name, int page, string view_loc, int count,int kindid=27)
        {
            RequestCode requests = new RequestCode();
            requests.act = act;
          //  requests.server_id = server_id;
           // requests.areaid = areaid;
           // requests.server_name = server_name;
            requests.page = page;
            requests.view_loc = view_loc;
            requests.count = count;
           // requests.kindid = kindid; // 27是角色

            return requests;



        }
        /// <summary>
        /// 根据祥瑞筛选
        /// </summary>
        /// <param name="act"></param>
        /// <param name="server_id"></param>
        /// <param name="areaid"></param>
        /// <param name="server_name"></param>
        /// <param name="page"></param>
        /// <param name="view_loc"></param>
        /// <param name="count"></param>
        /// <param name="kindid"></param>
        /// <returns></returns>
        public static RequestCode reqRoleInxiangrui(int level_min ,int level_max, string xiangrui_list, string server_type,string limit_clothes,string limit_clothes_logic,string act,int page, int count,string search_type,string view_loc,string school= null) {
            RequestCode requests = new RequestCode();
            requests.level_min = level_min;
            requests.level_max = level_max;
            requests.search_type = search_type;
            requests.limit_clothes = limit_clothes;
            requests.limit_clothes_logic = limit_clothes_logic;
            requests.server_type = server_type;
            requests.xiangrui_list = xiangrui_list;
            requests.act = act;
            requests.page = page;
            requests.view_loc = view_loc;
            requests.count = count;
            requests.school = school;
            

            return requests;



        }

        /// <summary>
        /// 搜索159角色
        /// </summary>
        /// <param name="count"></param>
        /// <param name="level_min"></param>
        /// <param name="level_max"></param>
        /// <param name="expt_total"></param>
        /// <param name="qian_yuan_dan"></param>
        /// <param name="price_min"></param>
        /// <param name="price_max"></param>
        /// <param name="pet_type_list"></param>
        /// <param name="art"></param>
        /// <param name="page"></param>
        /// <param name="search_type"></param>
        /// <param name="view_loc"></param>
        /// <returns></returns>
        public static RequestCode reqSerach(int count=15, int level_min = 159, int level_max = 159, int expt_total = 65, int qian_yuan_dan = 7, int price_min = 100, int price_max = 1500000, string pet_type_list = "1%2C2%2C3%2C6%2C7%2C8%2C102110%2C102008%2C102132%2C102035%2C102051%2C102049%2C102005%2C102108%2C102016%2C102050%2C102031%2C102101%2C102032%2C102131%2C102018%2C102100%2C102020%2C102109%2C102021%2C102019%2C102060%2C102250%2C102249%2C102311%2C102313%2C102317%2C102325%2C102827%2C102315%2C102341%2C102343", string act = "recommd_by_role", int page = 1, string search_type = "overall_search_role", string view_loc = "overall_search" , int child_skill_num_min = 0, int child_skill_num_max = 10, string server_type = "1%2C2%2C3", string equip_duanzao_attrlv_8 = "1")
        {
            RequestCode requests = new RequestCode();
            requests.page = page;
            requests.server_type = server_type;
            requests.search_type = search_type;
            requests.act = act;
            requests.level_min = level_min;
            requests.equip_duanzao_attrlv_8 = equip_duanzao_attrlv_8;
            requests.level_max = level_max;
            requests.qian_yuan_dan = qian_yuan_dan;
            requests.price_min = price_min;
            requests.price_max = price_max;
            requests.pet_type_list = pet_type_list;
            requests.child_skill_num_max = child_skill_num_max;
            requests.child_skill_num_min = child_skill_num_min;
            requests.page = page;
            requests.view_loc = view_loc;
            requests.count = count;
            return requests;
        }


    }
}
