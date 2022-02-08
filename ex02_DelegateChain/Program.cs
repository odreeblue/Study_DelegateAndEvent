using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02_DelegateChain
{
    delegate void PDelegate(int a, int b);
    internal class Program
    {
        static void Plus(int a, int b) { Console.WriteLine("{0}+{1} = {2}", a, b, a + b); }
        static void Minus(int a, int b) { Console.WriteLine("{0}-{1} = {2}", a, b, a - b); }
        static void Division(int a, int b) { Console.WriteLine("{0}/{1} = {2}", a, b, a / b); }
        static void Multiplication(int a, int b) { Console.WriteLine("{0}*{1} = {2}", a, b, a * b); }
        static void Main(string[] args)
        {
            PDelegate pd = (PDelegate)Delegate.Combine(new PDelegate(Plus), new PDelegate(Minus),
                                                       new PDelegate(Division),
                                                       new PDelegate(Multiplication));
            pd(20, 10);
            Console.ReadKey();
        }
    }
}
