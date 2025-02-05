using System.Numerics;

namespace TextRPG
{
    internal class Program
    {
        static Player player = new Player(1, "Ash", "전사", 10, 5, 100, 15000);
        static Inventory inventory = new Inventory();
        static Inventory store = new Inventory();

        static Item item1 = new Item("수련자 갑옷     ", "방어력", 5, "수련에 도움을 주는 갑옷입니다.",1000);
        static Item item2 = new Item("무쇠갑옷        ", "방어력", 9,"무쇠로 만들어져 튼튼한 갑옷입니다.",2000);
        static Item item3 = new Item("스파르타의 갑옷 ", "방어력", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",3500);
        static Item item4 = new Item("드래곤 갑옷     ", "방어력", 30, "드래곤으로 만든 갑옷입니다.",6000);
        static Item item5 = new Item("낡은 검         ", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.",600);
        static Item item6 = new Item("청동 도끼       ", "공격력", 5, "어디선가 사용됐던거 같은 도끼입니다.",1500);
        static Item item7 = new Item("스파르타의 창   ", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.",3500);
        static Item item8 = new Item("엑스칼리버      ", "공격력", 15, "영웅이 사용했다고 전해지는 검입니다.",6000);

        static void Constructor()
        {
            store.AddItem(item1);
            store.AddItem(item2);
            store.AddItem(item3);
            store.AddItem(item4);
            store.AddItem(item5);
            store.AddItem(item6);
            store.AddItem(item7);
            store.AddItem(item8);
        }

        static void Main(string[] args)
        {
            Constructor();
            bool isPlaying = true;

            while(isPlaying)
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전입장");
                Console.WriteLine("5. 휴식하기\n");

                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                if(int.TryParse(Console.ReadLine(),out int input))
                {
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("1");
                            Console.Clear();
                            Menu.PrintState(player, inventory.GetItem());
                            break;
                        case 2:
                            Console.WriteLine("2");
                            Console.Clear();
                            Menu.PrintInvertory(inventory.GetItem(),player);
                            break;
                        case 3:
                            Console.WriteLine("3");
                            Console.Clear();
                            Menu.PrintStore(player,store.GetItem(),inventory.GetItem());
                            break;
                        case 4:
                            Console.WriteLine("4");
                            Console.Clear();
                            Dungeon.EnterDungeon(player);
                            break;
                        case 5:
                            Console.WriteLine("5");
                            Console.Clear();
                            Menu.PrintRest(player);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("잘못된 입력입니다.\n");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.\n");
                }
            }//while
            
        }//main
    }
}
