using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{

    internal static class Dungeon
    {
        static int easy = 5;
        static int normal = 11;
        static int hard = 17;

        public static void EnterDungeon(Player player)
        {
            bool state = true;

            while (state)
            {
                Random random = new Random();
                int fail = random.Next(1, 11);

                Console.WriteLine("던전입장");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

                Console.WriteLine("1. 쉬운 던전\t | 방어력 {0} 이상 권장",easy);
                Console.WriteLine("2. 일반 던전\t | 방어력 {0} 이상 권장",normal);
                Console.WriteLine("3. 어려운 던전\t | 방어력 {0} 이상 권장",hard);
                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    switch (input)
                    {
                        case 0:
                            state = false;
                            Console.Clear();
                            break;
                        case 1:
                            if(player.Hp == 0)
                            {
                                Console.Clear();
                                DugneonFail(player);
                            }
                            else if (player.TotalDef() < easy && fail < 5)
                            {
                                Console.Clear();
                                DugneonFail(player);
                            }
                            else
                            {
                                Console.Clear();
                                DungeonClear(input, player);
                            }
                            break;
                        case 2:
                            if (player.Hp == 0)
                            {
                                Console.Clear();
                                DugneonFail(player);
                            }
                            else if (player.TotalDef() < normal && fail < 5 )
                            {
                                Console.Clear();
                                DugneonFail(player);
                            }
                            else 
                            {
                                Console.Clear();
                                DungeonClear(input, player);
                            }
                            break;
                        case 3:
                            if (player.Hp == 0)
                            {
                                Console.Clear();
                                DugneonFail(player);
                            }
                            else if (player.TotalDef() < hard && fail < 5 )
                            {
                                Console.Clear();
                                DugneonFail(player);
                            }
                            else
                            {
                                Console.Clear();
                                DungeonClear(input, player);
                            }
                            break;
                        default:
                            Menu.WrongInput();
                            break;
                    }//switch
                }
                else
                    Menu.WrongInput();
            }//while
        }//Enter Dungeon Method

        public static int CalcDef(int playerDef,int difficulty)
        {
            int result = playerDef - difficulty;
            return -result ;
        }

        public static void DungeonClear(int _input,Player player)
        {
            bool state = true;
            while (state)
            {
                Random randomHp = new Random();
                Random randomReward = new Random();

                int reward = randomReward.Next(player.TotalAtt(), player.TotalAtt()*2 + 1);
                int randomDecrease = 0;
                int gold = 0;

                Console.WriteLine("던전 클리어");
                Console.WriteLine("축하합니다!!\n");
                switch (_input)
                {
                    case 1:
                        Console.WriteLine("쉬운 던전을 클리어 하였습니다.\n");
                        randomDecrease = randomHp.Next(20 + CalcDef(player.TotalDef(), easy), 36 + CalcDef(player.TotalDef(), easy));
                        gold = 1000 + (1000 /100) * reward;
                        Console.WriteLine("[탐험 결과]");
                        Console.WriteLine($"체력 {player.Hp} -> {player.ReduceHp(randomDecrease)}");
                        Console.WriteLine($"골드 {player.Gold} G -> {player.AddGold(gold)} G");
                        player.LevelUp();
                        break;
                    case 2:
                        Console.WriteLine("일반 던전을 클리어 하였습니다.\n");
                        randomDecrease = randomHp.Next(20 + CalcDef(player.TotalDef(), normal), 36 + CalcDef(player.TotalDef(), normal));
                        gold = 1700 + (1700 / 100) * reward;
                        Console.WriteLine("[탐험 결과]");
                        Console.WriteLine($"체력 {player.Hp} -> {player.ReduceHp(randomDecrease)}");
                        Console.WriteLine($"골드 {player.Gold} G -> {player.AddGold(gold)} G");
                        player.LevelUp();
                        break;
                    case 3:
                        Console.WriteLine("어려운 던전을 클리어 하였습니다.\n");
                        randomDecrease = randomHp.Next(20 + CalcDef(player.TotalDef(), hard), 36 + CalcDef(player.TotalDef(), hard));
                        gold = 2500 + (2500 / 100) * reward;
                        Console.WriteLine("[탐험 결과]");
                        Console.WriteLine($"체력 {player.Hp} -> {player.ReduceHp(randomDecrease)}");
                        Console.WriteLine($"골드 {player.Gold} G -> {player.AddGold(gold)} G");
                        player.LevelUp();
                        break;
                    default:
                        Menu.WrongInput();
                        break;
                }
                //탐험결과
                //체력,골드 .레벨업

                Console.WriteLine("\n0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 0)
                    {
                        state = false;
                        Console.Clear();
                    }
                    else
                    {
                        state = false;
                        Menu.WrongInput();
                    }
                }
                else
                    Menu.WrongInput();
            }//while
        }//dungeonClear Method

        public static void DugneonFail(Player player)
        {
            bool state = true;
            while (state)
            {
                Console.WriteLine("던전 실패");
                Console.WriteLine("권장 방어력을 높여오세요!\n");
                Console.WriteLine("[탐험결과]");
                Console.WriteLine($"체력 {player.Hp} -> {player.DevideHp()}\n");

                if(player.Hp ==0)
                {
                    Console.WriteLine("Hp를 회복하세요\n");
                }

                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 0)
                    {
                        state = false;
                        Console.Clear();
                    }
                    else
                        Menu.WrongInput();
                }
                else
                    Menu.WrongInput();
            }//while
        }//DugneonFail Method
    }
}
