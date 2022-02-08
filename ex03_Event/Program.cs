using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex03_Event
{
    // 한정자 event 델리게이트 이름;

    public delegate void MyEventHandler(string name);

    class Publisher
    {
        public event MyEventHandler Active;
        public void DoActive(int number)
        {
            if (number % 10 == 0)
                Active("Active!" + number);
            else
                Console.WriteLine(number);
        }
    }
    internal class Program
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            publisher.Active += new MyEventHandler(MyHandler);
            for (int i=0; i< 50; i++)
            {
                publisher.DoActive(i);
            }
            Console.ReadKey();
        }
    }
}
