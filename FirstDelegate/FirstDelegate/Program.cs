using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDelegate
{
    //申明一个委托指向一个函数，有无返回值看函数。
    public delegate void DelSayHi(string name);
    class Program
    {
        static void Main(string[] args)
        {
            //DelSayHi del = SayHiChinese;  反编译还是会自动new一个对象//new DelSayHi(SayHiChinese);
            //del("张三");
            //Console.ReadKey();
            //Test("张三", SayHiChinese);
            Test("zhangs", (string name) => { Console.WriteLine("吃了吗" + name); });
            Console.ReadKey();
        }
        public static void Test(string name,DelSayHi del)
        {
            //调用
            del(name);
        }
        public static void SayHiChinese(string name)
        {
            Console.WriteLine("吃了吗"+name);
        }
        public static void SayHiEnglish(string name)
        {
            Console.WriteLine("nice to meet" + name);
        }
    }
}
