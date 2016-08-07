using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoName
{
    class Program
    {
        public delegate void DelSayHi(string name);
        static void Main(string[] args)
        {
            //方法一
            //SayHi("zhangsan", SayHiChinese);
            //方法二（不用SayHi）
            //DelSayHi del = SayHiChinese;

            //DelSayHi del = delegate(string name) { Console.WriteLine("你好"+name); };  //匿名函数
            DelSayHi del = (string name) => { Console.WriteLine("你好" + name); };//lamba表达式
            del("张三");

            Console.ReadKey();
        }
        public static void SayHi(string name, DelSayHi del)
        {
            del(name);
        }
        public static void SayHiChinese(string name)
        {
            Console.WriteLine("你好" + name);
        }
    }
}
