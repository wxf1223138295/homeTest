using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsInfoDal
    {

        public List<NewsInfo> GetAllNews()
        {
            DataTable dt=SqlHelper.ExecuteDataTable("SELECT ID, title, content, type, Date, people, picUrl FROM [dbo].[HKSJ]", CommandType.Text);
            List<NewsInfo> list = new List<NewsInfo>();
            for(var i=0;i<dt.Rows.Count;i++)
            {
                NewsInfo news = new NewsInfo();
                news.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                news.Content= dt.Rows[i]["content"] as string;
                news.People = dt.Rows[i]["people"] as string;
                news.Title = dt.Rows[i]["title"] as string;
                news.Date = DateTime.Parse(dt.Rows[i]["Date"].ToString());
                news.PicUrl = dt.Rows[i]["picUrl"] as string;
                list.Add(news);
            }
            return list;
        }
    }
}
