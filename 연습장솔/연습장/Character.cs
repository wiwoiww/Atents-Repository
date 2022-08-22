using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 연습장
{
    public class Character
    {
        // Random random = new Random();
        //     for (int i = 0; i< 100; i++ )
        //     {
        //         int randNum = random.Next();
        // Console.WriteLine($"랜덤 넘버 : {random}");
        //     }
        protected string name;
        protected int hp = 100;
        protected int maxHp = 100;
        protected int strenth = 10;
        protected int dexterity = 5;
        protected int intellegence = 7;

        

        bool isDead = false;

        public bool IsDead => isDead; //간단하게 읽기전용 프로퍼티 만드는 방법
        //{
        //    get
        //    {
        //        return isDead; 
        //    }
        //}

        string[] nameArray = { "너굴맨", "개굴맨", "병조맨", "담당맨", "사기맨" };

        protected Random rand;
        public string Name => name;
        public int HP
        {
            get
            {
                return hp;
            }

            private set
            {
                hp = value;
                if(hp > maxHp)
                {
                    hp = maxHp;
                }
                if (hp <= 0)
                {
                    //사망 처리용 함수 호출
                    Dead();
                }
            }
        }

        private void Dead()
        {
            Console.WriteLine($"{name}이 사망");
            isDead = true;
        }

        public Character()
        {
            //Console.WriteLine("생성자 호출");
            rand = new Random(DateTime.Now.Millisecond);
            int randomNumber = rand.Next();
            randomNumber %= 5;
            name = nameArray[randomNumber];


            GenerateStatus();
            TestPrintStatus();

        }

        public Character(string newName)
        {
            //Console.WriteLine($"생성자 호출 - {newName}");
            rand = new Random(DateTime.Now.Millisecond);
            name = newName;


            GenerateStatus();
            TestPrintStatus();
        }

        public virtual void GenerateStatus()
        {
            maxHp = rand.Next(100, 201);
            hp = maxHp;

            strenth = rand.Next(20) + 1;
            dexterity = rand.Next(20) + 1;
            intellegence = rand.Next(20) + 1;
        }

        public virtual void Attack(Character target)
        {
            int damage = strenth;
            Console.WriteLine($"{name}이 {target.name}에게 공격을 합니다.(공격력 : {damage})");
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            Console.WriteLine($"{name}이 {damage}만큼의 피해를 입었습니다.");
        }

        public virtual void TestPrintStatus()
        {
            Console.WriteLine("┌────────────────┐");
            Console.WriteLine($"│이름\t : {name}");
            Console.WriteLine($"│HP\t : {hp}/{maxHp}");
            Console.WriteLine($"│힘\t : {strenth}");
            Console.WriteLine($"│민첩\t : {dexterity}");
            Console.WriteLine($"│지능\t : {intellegence}");
            Console.WriteLine("└────────────────┘");
        }
    }
}
