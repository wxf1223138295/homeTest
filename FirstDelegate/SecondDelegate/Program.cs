using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondDelegate
{
    class Program
    {
        //和函数的签名一样有返回值和参数
        public delegate string DelProStr(string name);
        static void Main(string[] args)
        {
            string[] names={"ssSFwwSFw","HSJhJSJSj","SDJNxSNSasjd"};
            //方法一
            //prostr的重载是一个string数组和委托，由于strtolower的签名和委托一样，可以直接把函数名传给委托，反编译时会自动DelProStr del=new DelProStr(StrToLower);
            //ProStr(names, StrToLower);
            //方法二
            //使用匿名委托
            ProStr(names, delegate(string name) { return name.ToUpper(); });


            for(int i=0;i<names.Length;i++)
            {
                Console.WriteLine(names[i]);
            }
            Console.ReadKey();
        }

        public static void ProStr(string[] name, DelProStr del)
        {
            for (int i = 0; i < name.Length; i++)
            {
                name[i] = del(name[i]);
            }
        }

        #region 方法一       
        //public static string StrToUpper(string name)
        //{
        //    return name.ToUpper();
        //}
        //public static string  StrToLower(string name)
        //{
        //    return name.ToLower();
        //}
        #endregion
    }
}
