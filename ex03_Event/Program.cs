using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex03_Event
{
    public delegate void MyEventHandler(string name,int num);// 델리게이트 원형을 표시
    //public delegate void MyEventHandler(int num); //  delegate 오버로딩은 안됨
    class Publisher
    {
        // 한정자 event 델리게이트 이름;
        public event MyEventHandler Active; // Active라는 event 선언
        public void DoActive(int number)
        {
            if (number % 10 == 0) // 10으로 나누어 떨어졌을 때
                //Active("Active!" + number, number+1); // Active! + number 출력
                Active("Active!" + number,number+2);
            else//아니면
                Console.WriteLine(number); // number만 출력
        }
    }
    internal class Program
    {
        static public void MyHandler(string message,int num) // MyHandler라는 메서드 만들고, Message를 매개변수로 받아서
        {
            Console.WriteLine("받은 string:"+message+"  받은 num:"+num); // Message를 출력해라
        }
        ////static public void MyHandler(string message)
        ////{
        ////    Console.WriteLine("string만 받았다 그 값은" + message);
        ////}
        //static public void MyHandler2(int number)
        //{
        //    Console.WriteLine("int 매개변수 = {0}", number);
        //}
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher(); // Publisher 클래스의 객체를 publisher라는 이름으로 생성
            
            publisher.Active += new MyEventHandler(MyHandler); // event <- delegate <- function
            //publisher.Active += new MyEventHandler(MyHandler2); // 
            for (int i=0; i< 50; i++)
            {
                publisher.DoActive(i);
            }
            Console.ReadKey();
        }
    }
}
//      delegate <- function1
//               <- function2
//               <- .... function3