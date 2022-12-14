using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1일차_복습
{
    internal class Program
    {
        // 스코프(Scope) : 변수나 함수를 사용할 수 있는 범위. 변수를 선언한 시점에서 해당 변수가 포함된 중괄호가 끝나는 구간까지
        static void Main(string[] args)
        {
            //int sumResult = Sum(10, 20);        // break point (단축키 F9)
            //Console.WriteLine($"sumResult : {sumResult}");
            //Print();
            //Test_Function();
            //Test_GuGudan();

            
            Character human1 = new Character();  // 메모리 할당 완료(Instance화). 객체(Object) 생성완료(객체의 인스턴스를 만들었다.)
            Character human2 = new Character("개굴맨");  // Character 타입으로 하나 더 만든 것. human1 과 human2는 서로 다른 개체이다.

            human1.Attack(human2);
            human2.Attack(human1); 

            //ㅐhuman1.name = "너굴맨";
            //human1.SetName("너굴맨");

            //human1.TestPrintStatus();
            //human2.Attack();

            Console.ReadKey(); //키 입력 대기하는 코드
        } // main 함수의 끝 

        private static void Test_GuGudan()
        {
            // 실습
            // 1, int 타입의 파라메터를 하나 받아서 그 숫자에 해당하는 구구단을 출력해주는 함수 만들기
            // 2, 1번에서 만드는 함수는 2~9까지 입력이 들어오면 해당 구구단 출력, 그 외의 숫자는 "잘못된 입력입니다,"라고 출력
            // 3. 메인 함수에서 숫자를 하나 입력받는 코드가 있어야 한다.

            Console.Write("출력할 구구단을 입력하세요(2~9) : ");
            string temp = Console.ReadLine();
            int dan;
            int.TryParse(temp, out dan);
            GuGuDan(dan);

            bool b1 = true;
            bool b2 = false;
            // 논리 연산자
            // && (and) - 둘 다 참일 때만 참이다. t && t =, t && f = f, f && t = f, f && f = f
            // || (or) - 둘 중 하나만 참이면 참이다. t || t = t, t || f = t, f || t = t, f || f = f 
            // ~ (not) - true는 false. false는 true. ~t = f
        }

        static void GuGuDan(int dan)
        {
            // <= 나 >= 는 두개의 조건이 결합된 것이므로 피하는 것이 좋다.
            //if( 2 <= dan && dan <= 9)  // 2 <= dan    2 < dan && 2 ==dan
            if (1 < dan && dan < 10)
            {
                Console.WriteLine($"구구단 {dan}단 출력");
                // 구구단 출력
                for(int i = 1; i<10; i++)
                {
                    Console.WriteLine($"{dan} * {i} = {dan * i}");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        private static void Test_Function()
        {
            string name2 = "너굴맨";
            int level = 2;
            int hp = 10;
            int maxHp = 20;
            float exp = 0.1f;
            float maxExp = 1.0f;

            PrintCharacter(name2, level, hp, maxHp, exp, maxExp);
        }

        private static void PrintCharacter(string name, int level, int hp, int maxHp, float exp, float maxExp)
        {
            //실습 : 파라메터로 받은 데이터를 적당한 양식으로 출력해주는 함수 완성하기
            Console.WriteLine($"이름\t : {name}");
            Console.WriteLine($"레벨\t : {level}");
            Console.WriteLine($"HP\t : ({hp:d3}/{maxHp,3})");
            Console.WriteLine($"Exp\t : ({exp:F3}/{maxExp:F3})");

        }

        // 함수의 구성요소
        // 이름 : 함수들을 구분하기 위한 이름 (예제의 Sum)
        // 리턴타입 : 함수의 실행 결과로 돌려주는 데이터의 타입 (int, 함수의 이름앞에 반드시 표시된다.)
        // 파라메터(매개변수) : 함수가 실행될 때 외부에서 받는 값 (int a, int b 두개의 파라메터가 있다.함수 이름 뒤에 표시 된다.
        // 함수바디 : 함수가 호출될 때 실행될 코드들 (예제의 222~225라인)

        //함수의 이름, 리턴타입, 파라메터를 합쳐서 함수 프로토타입. 함수의 주민등록번호 절대로 하나의 프로그램에서 겹치지 않는다.
        static int Sum(int a, int b)
        {
            int result = a + b;
            return result;
        }
        static void Print()  //리턴해주는 값이 없고, 파라메터도 없는 경우 
        {
            Console.WriteLine("Print");
        }

        void Test()
        {
            Console.WriteLine("Hello world!"); // "Hello world!"를 출력하는 코드
            Console.WriteLine("고병조");       // 출력
                                            //string str = console.ReadLine(); // 키보드 입력을 받아서 str이라는 string 변수에 저장한다.

            //변수 : 변하는 숫자. 컴퓨터에서 사용할 데이터를 저장할 수 있는 곳.
            //변수의 종류 : 데이터 타입(Data type)
            //int : 인티저. 정수. 소수점 없는 숫자. 32bit
            //float : 플로트. 실수 .소수점 있는 숫자. 32bit
            //string : 스트링. 문자열.글자들을 저장.
            //bool : 불 또는 불리언, true/false를 저장.

            int a = 10; // a라는 인티저 변수에 10이라는 데이터를 넣는다.
            long b = 5000000000;
            //50억은 int에 넣을 수 없다. => int는 32비트이고 32비트로 표현가능한 숫자의 갯수는 2^32개이다
            int c = -100;
            int d = 2000000000;
            int e = 2000000000;
            int f = d + e;
            Console.WriteLine(f);


            //float의 단점 : 태생적으로 오차가 있을 수 밖에 없다.
            float aa = 0.000123f;
            float ab = 0.99999999999f;
            float ac = 0.00000000001f;
            float ad = ab + ac; // 결과가 1이 아닐 수도 있다.
            Console.WriteLine(ad);

            string str1 = "Hello";
            string str2 = "안녕!";
            string str3 = $"Hello {a}"; // "Hello 10"
            Console.WriteLine(str3);
            string str4 = str1 + str2; // "Hello안녕!"
            Console.WriteLine(str4);

            bool b1 = true;
            bool b2 = false;

            //int level = 1;
            //int hp = 10;
            //float exp = 0.9f;
            //string name = "너굴맨";
            ////너굴맨의 레벨은 1이고 HP는 10이고 exp는 0.9다.
            //Console.WriteLine($"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다.");
            //string result = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다.\n";
            //Console.WriteLine(result);

            //Console.WriteLine($"이름 : {name}\n레벨 : {level}\nHP : {hp}\nexp : {exp}\n\n");

            //Console.Write("이름을 입력하세요 : ");
            //name = Console.ReadLine();
            //Console.Write($"{name}의 레벨을 입력하세요 : ");
            //string temp = Console.ReadLine();
            ////level = int.Parse(temp);  // string을 int로 변경해주는 코드(숫자로 바꿀 수 있을 때만 가능)간단하지만 위험함
            ////level = Convert.ToInt32(temp);  // string을 int로 변경해주는 코드(숫자로 바꿀 수 있을 때만 가능)더 세세하게 변경할수있다 그래도 위험함
            //int.TryParse(temp, out level);// string을 int로 변경해주는 코드(숫자로 바꿀 수 없으면 0으로 만듬)  
            //result = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다.\n";
            //Console.WriteLine(result);


            //exp = 0.95959595f;
            ////너굴맨의 레벨은 1이고 HP는 10이고 exp는 90%다.
            //result = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp*100:F2}%다.\n"; // exp*100을 소수점 3자리까지 찍는 코드
            //Console.WriteLine(result);


            //이름, 레벨, hp, 경험치를 각각 입력 받고 출력하는 코드 만들기

            string result;
            string name = "너굴맨";
            int level = 3;
            int hp = 2;
            float exp = 0.5f;

            //Console.Write("이름을 입력하세요 : ");          //내가한거
            //name = Console.ReadLine();

            //string temp;
            //Console.Write($"{name}의 레벨을 입력하세요 : ");
            //temp = Console.ReadLine();
            //int.TryParse(temp, out level);

            //Console.Write($"{name}의 HP를 입력하세요 : ");
            //temp = Console.ReadLine();
            //int.TryParse (temp, out hp);

            //Console.Write($"{name}의 exp를 입력하세요 : ");
            //temp = Console.ReadLine();
            //float.TryParse(temp, out exp); 

            //result = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다.\n";
            //Console.WriteLine(result); 

            // 변수 끝 ------------------------------------------------------

            // 제어문(Control statement) - 조건문(if, switch), 반복문
            // 실행되는 코드 라인을 변경할 수 있는 코드
            hp = 2;
            if (hp < 3)  // hp가 2이기 때문에 참. 따라서 중괄호 사이에 코드가 실행된다.
            {
                Console.WriteLine("HP가 부족합니다."); //( hp < 3 )이 참일 때 실행되는 코드
            }
            else if (hp < 10)
            {
                Console.WriteLine("HP가 적당합니다."); //( hp < 3 )이 거짓이고 ( hp < 10 )이 참일 때 실행되는 코드
            }
            else
            {
                Console.WriteLine("HP가 충분합니다."); //( hp < 3 )와 ( hp < 10 )가 둘다 거짓일 때 실행되는 코드
            }
            switch (hp)
            {
                case 0: // hp가 0일 때
                    Console.WriteLine("HP가 0입니다.");
                    break;
                case 5: // hp가 5일 때
                    Console.WriteLine("HP가 5입니다.");
                    break;
                default: // 위에 설정되지 않은 모든 경우
                    Console.WriteLine("HP가 0과 5가 아닙니다.");
                    break;
            }
            //// 조건문 실습
            //Console.WriteLine("경험치를 추가합니다.");
            //Console.Write("추가할 경험치 : ");
            //string temp = Console.ReadLine();
            //float tempExp;
            //float.TryParse(temp, out tempExp);

            //if ((exp + tempExp) > 1.0f)
            //{
            //    Console.WriteLine("레벨업!");
            //}
            //else
            //{
            //    Console.WriteLine($"현재 경험치 : .{exp + tempExp}");
            //}
            //// 실습: exp의 값과 추가로 입력받은 경험치의 합이 1이상이면 "레벨업"이라고
            ////이라고 출력하고 1미만이면 합계를 출력하는 코드 작성하기

            level = 1;
            while (level < 3)  // 소괄호() 안의 조건이 참이면 중괄호{} 사이의 코드를 실행하는 statement
            {
                Console.WriteLine($"현재 레벨 : {level}");
                level++;       //level = level + 1; // level += 1;(레벨에다 1을 더해서 넣어라 +=) // 셋다같음
                               //level += 2;(level에다 2를 더해서 level에 넣어라)
            }

            // i는 0에서 시작해서 3보다 작으면 계속 {}사이의 코드를 실행한다.i는 {} 사이의 코드를 실행할 때 마다 1씩 증가한다.
            hp = 10;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"현재 HP : {hp}");
                hp += 10;
            }
            Console.WriteLine($"최종 HP : {hp}");
            level = 1;
            do
            {
                Console.WriteLine($"현재 레벨 : {level}");

                if (level == 2)
                {
                    break;
                }

                level++;
            }
            while (level < 10);
            Console.WriteLine($"최종 Level : {level}");

            //실습 : exp가 1을 넘어 레벨업을 할 때까지 계속 추가 경험치를 입력하도록 하는 코드를 작성하기
            //힌트1 : 반복문 안에서 계속 입력을 받아야 한다.
            //힌트2 : 레벨업을 할 수 없으면 반복문이 계속 실행되어야 한다.

            exp = 0.0f;
            Console.WriteLine($"현재 경험치 : {exp}");




            while (exp < 1.0f) //exp값이 1보다 작으면 계속 반복한다.
            {
                Console.WriteLine("경험치를 추가 해야합니다.");
                Console.Write("추가할 경험치 : ");
                string temp = Console.ReadLine();  // 입력 받기 
                float tempExp;
                float.TryParse(temp, out tempExp); // 입력 받은 string을 float으로 변경
                exp += tempExp; // 입력 받은 값을 exp에 추가
                Console.WriteLine($"현재 경험치 : {exp}");
            }
            // while이 끝났다라는 이야기는 exp가 1보다 크거나 같아졌다라는 의미
            Console.WriteLine("레벨업!");
        }
    }
}
