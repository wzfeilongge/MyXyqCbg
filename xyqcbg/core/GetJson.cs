using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xyqcbg.Model;
using xyqcbg.HttpHelper;
namespace xyqcbg.core
{
  public  class GetJson
    {
        /// <summary>
        /// 查询最新上架的所有物品
        /// </summary>
        /// <returns></returns>
        public  ResultCode[] GetMessage()
        {

            RequestCode req = RequestCode.req(10);
            var url = "https://recommd.xyq.cbg.163.com/cgi-bin/recommend.py";
           var result = HttpHelper.HttpHelper.GetAsync<RequestCode, ResultData<ResultCode[]>>(url, req);
            if (result.status == "1")
            {
                ResultCode[] data = result.equips;
                return data;

            };
            return null;
        }
        /// <summary>
       /// 根据等级搜索角色
       /// </summary>
       /// <param name="min">最小等级</param>
       /// <param name="max">最大等级</param>
       /// <returns></returns>
        public static ResultCode[] GetRole(int min,int max)
        {

            RequestCode req = RequestCode.req(15,min,max);
            var url = "https://recommd.xyq.cbg.163.com/cgi-bin/recommend.py";
            var result = HttpHelper.HttpHelper.GetAsync<RequestCode, ResultData<ResultCode[]>>(url, req);
            if (result.status == "1")
            {
                ResultCode[] data = result.equips;
                return data;

            };
            return null;
        }
        /// <summary>
        /// 搜索角色特殊祥瑞
        /// </summary>
        /// <returns></returns>
        public static ResultCode[] GetRoleInOmen(string xiangruiList,int min,int max,int page,string school=null)
        {
            //%E5%86%B0%E6%99%B6%E9%AD%85%E7%81%B5%2C%E9%A3%9E%E5%A4%A9%E7%8C%AA%E7%8C%AA%2C%E4%B9%9D%E5%B0%BE%E5%86%B0%E7%8B%90%2C%E4%B9%9D%E5%B9%BD%E7%81%B5%E8%99%8E%2C%E8%90%8C%E5%8A%A8%E7%8C%AA%E7%8C%AA%2C%E8%90%8C%E8%90%8C%E5%B0%8F%E7%8B%97%2C%E7%A5%9E%E8%A1%8C%E5%B0%8F%E9%A9%B4%2C%E5%A4%A9%E4%BD%BF%E7%8C%AA%E7%8C%AA%2C%E7%94%9C%E8%9C%9C%E7%8C%AA%E7%8C%AA%2C%E7%8E%84%E5%86%B0%E7%81%B5%E8%99%8E%2C%E7%8E%89%E7%93%B7%E8%91%AB%E8%8A%A6%2C%E6%88%98%E7%81%AB%E7%A9%B7%E5%A5%87%2C%E7%86%8A%E7%8C%AB%E5%9B%A2%E5%AD%90%2C%E9%9C%9C%E9%9B%AA%E9%BE%99%E5%AE%9D%2C%E8%B4%A2%E6%BA%90%E6%BB%9A%E6%BB%9A
            RequestCode req = RequestCode.reqRoleInxiangrui(min,max, xiangruiList,
                "3", "12512%2C12513%2C12514%2C12646%2C12647%2C12648%2C12652%2C12653%2C12654%2C40023%2C40025%2C12765%2C12767%2C12498%2C13790%2C40013%2C12750%2C40108%2C12850%2C12434%2C13726%2C12247%2C13984%2C13513%2C12246%2C13512%2C13983%2C40124%2C12873%2C40126%2C12875%2C40128%2C12877%2C40244%2C12993%2C40246%2C12995",
                "or", "recommd_by_role", page,15, "overall_search_role", "overall_search",school);
            var url = "https://recommd.xyq.cbg.163.com/cgi-bin/recommend.py";
           
            var result = HttpHelper.HttpHelper.GetAsync<RequestCode, ResultData<ResultCode[]>>(url, req);
            if (result.status == "1")
            {
                ResultCode[] data = result.equips;
                return data;

            };
            return null;
        }
        /// <summary>
        /// 根据指定条件搜索159的角色
        /// </summary>
        /// <returns></returns>
         public static ResultCode[] GetRoleIn159()
        {

            RequestCode req = RequestCode.reqSerach(); //搜索159角色
            var url = "https://recommd.xyq.cbg.163.com/cgi-bin/recommend.py";
            var result = HttpHelper.HttpHelper.GetAsync<RequestCode, ResultData<ResultCode[]>>(url, req);
            if (result.status == "1")
            {
                ResultCode[] data = result.equips;
                return data;

            };
            return null;
        }


    }
}
