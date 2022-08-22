using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 연습장
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test_Character();
            //Human h1 = new Human();
            //Character c1 = h1; // 상속받은 클래스는 부모 클래스 타입으로 저장할 수 있다.
            //c1.TestPrintStatus(); // Character 의 TestPrintStatus 호출이 된다. (가상함수가 아니라서)
            //c1.GenerateStatus();  //Human의 GenerateStatus가 호출이 된다. (가상함수이기 때문에)

            // 1. Human의 TestPrintStatus 함수를 오버라이드(원래 함수의 긴능을 다른 기능으로 변경 하는 것) 하라.(mp출력할 것)
            // 2. Human의 Attack 함수를 오버라이드 하라
            //   2.1. Attack을 할 때 30%의 확률로 치명타가 터지게 만들어라(치명타는 대미지 2배)

            Human human1 = new Human();
            Human human2 = new Human();

            while (!human1.IsDead && !human2.IsDead)//(human2.HP > 0 && human1.HP > 0)
            {
                human1.Attack(human2);
                human1.TestPrintStatus();
                human2.TestPrintStatus();
                if (human2.IsDead)
                {
                    break;
                }
                human2.Attack(human1);
                human1.TestPrintStatus();
                human2.TestPrintStatus();

            }
            Console.WriteLine("벌레새끼 사망\n 전투종료");


            Console.ReadKey();
        }

        private static void Test_Character()
        {
            Character human1 = new Character();
            Character human2 = new Character("개굴맨맨");

            //(human1.IsDead != true && human2.IsDead != true)
            while (!human1.IsDead && !human2.IsDead)//(human2.HP > 0 && human1.HP > 0)
            {
                human1.Attack(human2);
                human1.TestPrintStatus();
                human2.TestPrintStatus();
                if (human2.IsDead)
                {
                    break;
                }
                human2.Attack(human1);
                human1.TestPrintStatus();
                human2.TestPrintStatus();

            }
            Console.WriteLine("벌레새끼 사망\n 전투종료");
        }
    }
}
