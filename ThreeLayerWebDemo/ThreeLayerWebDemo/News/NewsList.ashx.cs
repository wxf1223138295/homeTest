using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ThreeLayerWebDemo.News
{
    /// <summary>
    /// NewsList 的摘要说明
    /// </summary>
    public class NewsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
          
            context.Response.ContentType = "text/html";
            NewsInfoService newsInfoservice = new NewsInfoService();
            List<NewsInfo> newList= newsInfoservice.GetAllNews();
            StringBuilder sb = new StringBuilder();
              //<th>编号</th><th>标题</th><th>日期</th><th>创建人</th><th>操作</th>
            foreach(var newsInfo in newList)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a href='{0}'>详情</a></td></tr>", newsInfo.ID, newsInfo.Title, newsInfo.Date, newsInfo.People);
            }
            string tempString= File.ReadAllText(context.Request.MapPath("NewsListTemp.html"));
            string result = tempString.Replace("@trbody", sb.ToString());
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}