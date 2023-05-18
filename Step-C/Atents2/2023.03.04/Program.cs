using System;

namespace _2023._03._04

{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new System.Random();    // 난수 발생용 객체 생성

            int randValue = random.Next();  // 난수 발생

            Console.WriteLine("randValue = {0}", randValue);

            // % 나머지 연산자: 임의의 값을 의미있는 범위의 숫자를 만들때 사용

            // 0: runAway 도망
            // 1: Attack 공격
            // 2: Defense 방어

            int actionValue = randValue % 3;

            switch (actionValue)
            {
                case 0:
                    Console.WriteLine("Run Away");
                    break;

                case 1:
                    Console.WriteLine("Attack");
                    break;

                case 2:
                    Console.WriteLine("Defense");
                    break;
            }
        }
    }
}