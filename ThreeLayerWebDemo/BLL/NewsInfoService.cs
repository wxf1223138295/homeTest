using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsInfoService
    {
        private NewsInfoDal newsInfoDal = new NewsInfoDal();
        public List<NewsInfo> GetAllNews()
        {
            return newsInfoDal.GetAllNews();
        }
    }
}
