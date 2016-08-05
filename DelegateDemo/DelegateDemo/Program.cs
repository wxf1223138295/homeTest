using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public delegate int Call(int num1, int num2);
    class SimpleMath
    {
        //乘法
        public int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        // 除法方法
        public int Divide(int num1, int num2)
        {
            return num1 / num2;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Call objCall;//声明委托对象

            SimpleMath objMath = new SimpleMath();

            //创建委托对象，将方法与委托关联起来
            objCall = new Call(objMath.Multiply);

            Call objcal2 = new Call(objMath.Divide);

            objCall += objCall;

            int result = objCall(5, 2);
            Console.WriteLine("结果是 {0}",result);
            Console.ReadKey();


        }
    }
}
