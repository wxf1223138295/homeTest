using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxObject
{
    public delegate int DelCompare(object o1,object o2);
    class Program
    {
        static void Main(string[] args)
        {
            object[] a={1,2,3,4,7,10,6,5,9};

            Console.WriteLine(GetMax(a,Compare));

            Console.WriteLine(GetMax(a, (object o1, object o2) => { 
                int n1 = (int)o1;
                int n2 = (int)o2;
                return n1 - n2;
            }));
            Console.ReadKey();
        }
        public static object GetMax(object[] nums,DelCompare del)
        {
            object max = nums[0];
            for(int i=0;i<nums.Length;i++)
            {
                //要传比较方法
                //if(max<nums[i])
                if(del(max,nums[i])<0)
                {
                    max = nums[i];
                }              
            }
            return max;
        }

        public static int Compare(object o1,object o2)
        {
            int n1 = (int)o1;
            int n2 = (int)o2;
            return n1 - n2;
        }

        //public static object GetMax(string[] names)
        //{
        //    string max = names[0];
        //    for(int i=0;i<names.Length;i++)
        //    {
        //        if(max.Length<names.Length)
        //        {
        //            max = names[i];
        //        }
        //    }
        //    return max;
        //}
    }
}
