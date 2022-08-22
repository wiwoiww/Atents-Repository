using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 연습장
{
    public class Human : Character // Human 클래스는 Character 클래스를 상속 받았다.
    {
        int mp = 100;
        int maxMp = 100;
        public Human() : base() //상속 받은 부모의 생성자도 같이 실행 (base 없어도댐 바낌 )
        {
            //GenerateStatus();

        }
        public override void GenerateStatus()
        {
            base.GenerateStatus(); // Character의 GenerateStatus 함수 실행
            maxMp = rand.Next() % 100; // 추가한 변수만 추가로 처리
            mp = maxMp;
        }

        public override void Attack(Character target)
        {
            int damage = strenth;

            rand.NextDouble(); // 0.0 ~ 1.0
            if(rand.NextDouble() < 0.3f) // 이 조건이 참이면 30% 안쪽으로 들어왔다.
            {
                damage *= 2;   // damage = damage * 2;
                Console.WriteLine("키리티컬 히트!");
            }

            Console.WriteLine($"{name}이 {target.Name}에게 공격을 합니다.(공격력 : {damage})");
            target.TakeDamage(damage);
        }
        public override void TestPrintStatus()
        {
            Console.WriteLine("┌────────────────┐");
            Console.WriteLine($"│이름\t : {name}");
            Console.WriteLine($"│HP\t : ({hp}/{maxHp})");
            Console.WriteLine($"│MP\t : ({mp}/{maxMp})");
            Console.WriteLine($"│힘\t : {strenth}");
            Console.WriteLine($"│민첩\t : {dexterity}");
            Console.WriteLine($"│지능\t : {intellegence}");
            Console.WriteLine("└────────────────┘");
        }
    }
}
