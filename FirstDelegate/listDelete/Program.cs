using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listDelete
{
    class Program
    {
        public delegate int DelCompare<T>(T t1, T t2);
        //public delegate int DelCompare(object o1, object o2);
        static void Main(string[] args)
        {
            //List<int> list = new List<int>();
            int[] nums = { 1, 2, 3, 4, 5 };
            Console.WriteLine( GetMax<int>(nums, (int n1, int n2) =>
            {
                return n1-n2;            
            }));

            Console.ReadKey();
        }
        public static T GetMax<T>(T[] nums, DelCompare<T> del)
        {
            T max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                //要传比较方法
                //if(max<nums[i])
                if (del(max, nums[i]) < 0)
                {
                    max = nums[i];
                }
            }
            return max;
        }
    }
}
