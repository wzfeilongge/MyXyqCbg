using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyqcbg.Model
{
     public class ResultCode
    {
        public string equip_name { get; set; }//物品名称
        public string equip_level_desc {get; set; }//物品等级
        public string time_left { get; set; }//剩下时间
        public string area_name { get; set; }//大区
        public string server_id { get; set; }//服务器id
        public string eid { get; set; }//物品的id
        public string server_name { get; set; }//服务器名称
        public string seller_nickname { get; set; }//卖家昵称
        public string seller_roleid { get; set; } //卖家id
        public double price { get; set; } //价格
        public string desc { get; set; }//基本信息
        public int school { get; set; }//门派信息
        public int max_expt_fashu { get; set; }//人物法术修炼上限
        public int max_expt_fangyu { get; set; }//人物防御修炼上限
        public int max_expt_gongji { get; set; } //人物攻击修炼上限
        public int max_expt_kangfa { get; set; }//人物抗法修炼上限
        public int expt_fashu { get; set; }//人物法术修炼
        public int expt_fangyu { get; set; }//人物防御修炼
        public int expt_gongji { get; set; } //人物攻击修炼
        public int expt_kangfa { get; set; }//人物抗法修炼
        public int bb_expt_fashu { get; set; }//宝宝法术修炼
        public int bb_expt_kangfa { get; set; }//宝宝抗法修炼
        public int bb_expt_fangyu { get; set; }//宝宝防御修炼
        public int bb_expt_gongji { get; set; }//宝宝攻击修炼
        public string create_time { get; set; }//创建订单时间

       // public string[] highlights { get; set; }//亮点







    }
}
