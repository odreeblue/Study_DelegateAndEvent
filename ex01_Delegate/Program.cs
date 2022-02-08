using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01_Delegate
{
    // delegate 반환형 델리게이트명(매개변수..);
    delegate int PDelegate(int a, int b);

    internal class Program
    {
        static int Plus(int a, int b)
        {
            return a + b;
        }
        static int Dot(int a, int b)
        {
            return a * b;
        }
        static void Main(string[] args)
        {
            PDelegate pd1 = Plus;
            PDelegate pd2 = Dot;
            PDelegate pd3 = delegate (int a, int b) 
            {
                return a / b;
            };
            Console.WriteLine(pd1(5, 10));
            Console.WriteLine(pd2(5, 10));
            Console.WriteLine(pd3(10, 5));
            Console.ReadKey();
        }
    }
}
