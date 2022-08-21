using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3일차_복습
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int sumResult = Sum(10, 20);
            //Console.WriteLine($"SumResult : {sumResult}");
            //Print();
            //Test_Function();
            //Test_GuGudan();



            Character human1 = new Character(); // 메모리 할당 완료(Instance화). 객체(Object) 생성 완료(객체의 인스턴스를 만들었다.)
            Character human2 = new Character("개굴맨맨"); // Character 타입으로 하나 더 만든것. human1과 human2는 서로 다른 개체이다.

            human1.Attack(human2);
            human1.TestPrintStatus();
            human2.TestPrintStatus();
            human2.Attack(human1);
            human1.TestPrintStatus();
            human2.TestPrintStatus();

            //Console.WriteLine($"{human1.HP}");
            //human1.TestPrintStatus();
            

            //human1.TestPrintStatus();
            //human1.Attack();

            Console.ReadLine();                // 키 입력 대기하는 코드
        }   //main 함수의 끝

        private static void Test_GuGudan()
        {
            Console.Write("출력할 구구단을 입력하세요(2~9) :");
            string temp = Console.ReadLine();
            int dan;
            int.TryParse(temp, out dan);
            GuGuDan(dan);

            bool b1 = true;
            bool b2 = false;
            // 논리 연산자
            // && (and) - t && t = t, t && f = f, f && t = f, f && f = f   // 둘 다 참일 때만 참이다.
            // || (or)  - t || t = t, t || f = t, f || t = t, f || f = f   // 둘 중 하나만 참이면 참이다. 
            // ~  (not) - ~t = f               //ture는 false. false는 true
        }

        static void GuGuDan(int dan)
        {
            if( 1 < dan && dan < 10)
            {
                Console.WriteLine($"구구단 {dan}단 출력");
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
            string name = "너굴맨";
            int level = 2;
            int hp = 10;
            int maxHP = 20;
            float exp = 0.1f;
            float maxExp = 1.0f;

            PrintCharacter(name, level, hp, maxHP, exp, maxExp);
            PrintCharacter("dkdk", 12, 34, 44, 0.2f, 2.0f);
        }

        private static void PrintCharacter(string name, int level, int hp, int maxHP, float exp, float maxExp)
        {
            Console.WriteLine($"이름 : {name}\n레벨 : {level}\nHP : ({hp}/{maxHP})\nexp : ({exp}/{maxExp})\n");
        }

        // 함수의 구성요소
        // 이름 : 함수들을 구분하기 위한 이름
        // 리턴타입 : 함수의 실행 결과로  돌려주는 데이터의 타입
        // 파라메터(매개변수) : 함수가 실행될 때 외부에서 받는 값
        // 함수바디 : 함수가 호출될 때 실행될 코드들

        // 함수의 이름, 리턴타입, 파라메터를 합쳐서 함수 프로토타입.함수의 주민등록번호.절대로 하나의 프로그램안에서 겹치지않는다.

        static int Sum(int a, int b)
        {
            int result = a + b;
            return result;
        }

        static void Print()   // 리턴해주는 값이 없고, 파라메터도 없는 경우
        {
            Console.WriteLine("Print");
        }


    }
}




//Console.WriteLine("Hello world!");  //"Hello world!"를 출력하는 코드
//Console.WriteLine("고병조");       // 출력
//                                //string str = Console.ReadLIne(); // 키ㅗ드 입력을 받아서 str이라는 string 변수에 저장한다.

//// 변수 : 변하는 숫자. 컴퓨터에서 사용할 데이터를 저장할 수 있는 곳.
//// 변수의 종류 : 데이터 타입(Data type)
//// int : 인티저. 정수. 소수점 없는 숫자. 32bit
//// float : 플로트. 실수. 소수점 있는 숫자. 32bit
//// string : 스트링. 문자열. 글자들을 저장.
//// bool : 불 또는 불리언. true/false를 저장.

//int a = 10; // a라는 인티저 변수에 10이라는 데이터를 넣는다.
//long b = 5000000000;     // 50억은 int에 넣을 수 없다. => int는 32비트이고 32비트로 표현가능한 숫자의 갯수는 2^32개이다.
//int c = -100;
//int d = 2000000000;
//int e = 2000000000;
//int f = d + e;
//Console.WriteLine(f);


//// float의 단점 : 태생적으로 오차가 있을 수 밖에 없다.
//float aa = 0.000123f;
//float ab = 0.999999999999f;
//float ac = 0.000000000001f;
//float ad = ab + ac; // 결과가 1이 아닐 수도 있다.
//Console.WriteLine(ad);

//string str1 = "Hello";
//string str2 = "안녕!";
//string str3 = $"Hello {a}"; //"Hello 10"
//Console.WriteLine(str3);
//string str4 = str1 + str2;  //"Hello안녕!"
//Console.WriteLine(str4);

//bool b1 = true;
//bool b2 = false;

////int level = 1;
////int hp = 10;
////float exp = 0.9f;
////string name = "너굴맨";
//////너굴맨의 레벨은 1이고 HP는 10이고 exp는 0.9다.

////string result = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다.\n";
////Console.WriteLine(result);

////Console.Write ($"이름 : {name}\n레벨 : {level}\nHP : {hp}\nexp : {exp}\n\n");

////Console.Write("이름을 입력하세요 : ");
////name =Console.ReadLine();
////Console.Write($"{name}의 레벨을 입력하세요 : ");
////string temp = Console.ReadLine();
//////level = int.Parse(temp);  //string을 int로 변경해주는 코드(숫자로 바꿀 수 있을 때만 가능).간단하지만 위험함
//////level = Convert.ToInt32 (temp);//string을 int로 변경해주는 코드(숫자로 바꿀 수 있을 때만 가능).더 세세하게 변경할 수 있다. 그래도 위험.
////int.TryParse(temp, out level); // string을 int로 변경해주는 코드(숫자로 바꿀 수 없으면 0으로 만든다.)
////result = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다.\n";
////Console.WriteLine(result);


////exp = 0.95959595f;
////result = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp*100:F3}%다.\n"; //exp*100을 소수점 3자리까지 찍는 코드
////Console.WriteLine(result);


////이름, 레벨, hp, 경험치를 각각 입력 받고 출력하는 코드 만들기

//string result;
//string name = "너굴맨";
//int level = 1;
//int hp = 3;
//float exp = 0.1f;
//string temp;

////Console.Write("이름을 입력하세요 : ");
////name = Console.ReadLine();

////Console.Write($"{name}의 레벨을 입력하세요 : ");
////temp = Console.ReadLine();
////int.TryParse (temp, out level);

////Console.Write($"{name}의 hp를 입력하세요 : ");
////temp = Console.ReadLine ();
////int.TryParse (temp, out hp);

////Console.Write($"{name}의 exp를 입력하세요 : ");
////temp = Console.ReadLine ();
////float.TryParse(temp, out exp);

////result = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}이다.\n";
////Console.WriteLine(result);

//// 변수 끝 ------------------------------------------------------------------------------------------------------

//// 제어문(control statement) - 조건문(if, switch), 반복문
//// 실행되는 코드 라인을 변경할 수 있는 코드
//hp = 5;
//if (hp < 3)  //hp가 2이기 때문에 참이다. 따라서 중괄호 사이에 코드가 실행된다.
//{
//    Console.WriteLine("HP가 부족합니다.");  // hp < 3 참일 때 실행되는 코드
//}
//else if (hp < 10)
//{
//    Console.WriteLine("HP가 적당합니다.");  // (hp <3)은 거짓이고  (hp < 10)는 참일 때 실행되는 코드
//}
//else
//{
//    Console.WriteLine("HP가 충분합니다.");  // (hp <3)와 (hp < 10)가  거짓일 때 실행되는 코드
//}

////switch(hp)
////{
////    case 0: // hp가 0 일 때
////        Console.WriteLine("HP가 0입니다.");
////        break;
////    case 5:// hp가 5일 때
////        Console.WriteLine("HP가 5입니다.");
////        break;
////    default: // 위에 설정되지 않은 모든 경우
////        Console.WriteLine("HP가 0과 5가 아닙니다.");
////        break ;
////}

////Console.WriteLine("경험치를 추가합니다.");
////Console.Write("추가할 경험치 : ");
////temp = Console.ReadLine();
////float tempExp;
////float.TryParse(temp, out tempExp);

////if ((exp + tempExp) < 1.0f)
////{

////    Console.WriteLine($"현재 경험치 : {exp + tempExp}");
////}
////else
////{
////    Console.WriteLine("레벨업 !");
////}
////// 실습

//while (level < 3)  //소괄호() 안의 조건이 참이면 중괄호{} 사이의 코드를 실행하는 statement
//{
//    Console.WriteLine($"현재 레벨 : {level}");
//    level++;     //level = level + 1;  // level += 1; // 셋 다 같은 코드
//                 //level += 2; // 레벨에다 2를 더해서 레벨에 넣어라
//}
//hp = 10;
//// i는 0에서 시작해서 3보다 작으면 계속 {}사이의 코드를실행한다. {}사이의 코드를 실행할 때마다 1씩 증가한다.
//for (int i = 0; i < 3; i++)
//{
//    Console.WriteLine($"현재 HP : {hp}");
//    hp += 10;
//}
//Console.WriteLine($"최종 HP : {hp}");

//level = 1;
//do
//{
//    Console.WriteLine($"현재 레벨 : {level}");
//    level++;

//    if (level == 2)
//    {
//        break;
//    }
//}
//while (level < 10);
//Console.WriteLine($"최종 Level : {level}");

////실습 : exp가 1을 넘어 레벨업을 할 때까지 계속 추가 경험치를 입력하도록 하는 코드를 작성하기
//exp = 0.0f;
//float tempExp = 0.0f;
//Console.WriteLine($"현재 경험치 : {exp}");

//while (exp < 1.0f)
//{
//    Console.WriteLine($"경험치를 추가합니다. 현재 경험치 : {exp}");
//    Console.Write("추가할 경험치 : ");
//    temp = Console.ReadLine();
//    float.TryParse(temp, out tempExp);
//    exp += tempExp;
//}
//Console.WriteLine("레벨업!");