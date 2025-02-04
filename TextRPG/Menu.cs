using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal static class Menu
    {
        public static void PrintState(Player player, List<Item>playerItem)
        {
            bool state = true;
            string equipped = "[E]";
            int itemAtt , itemDef;
            itemAtt = itemDef = 0;
            
            while (state)
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

                //아이템의 공격력,방어력 저장받기
                foreach (Item item in playerItem)
                {
                    if(item.Name.Contains(equipped))
                    {
                        if(item.AbilityType =="공격력")
                            itemAtt += item.Ability;
                        else if(item.AbilityType == "방어력")
                            itemDef += item.Ability;
                    }
                }
                Console.WriteLine($"Lv. {player.Level}");
                Console.WriteLine($"{player.Name} ({player.CharacterClass})");
                if (itemAtt > 0) Console.WriteLine($"공격력 : {player.Att} (+{itemAtt})"); else Console.WriteLine($"공격력 : {player.Att}");
                if (itemDef > 0) Console.WriteLine($"방어력 : {player.Def} (+{itemDef})"); else Console.WriteLine($"방어력 : {player.Def}");
                Console.WriteLine($"체 력 : {player.Hp}");
                Console.WriteLine($"Gold : {player.Gold}G\n");
                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(),out int input))
                {
                    if(input == 0)
                    {
                        state = false;
                        Console.Clear();
                    }
                }
            }//while
        }//State method
        public static void PrintInvertory(List<Item> playerItem)
        {
            bool state = true;
            bool equip = false;
            string equipped = "[E]";
            while (state)
            {
                if (equip == false)
                    Console.WriteLine("인벤토리");
                else
                    Console.WriteLine("인벤토리 - 장착 관리");

                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]\n");

                PrintEquipMenu(playerItem,equip);

                if(equip == false)
                    Console.WriteLine("\n1. 장착 관리");

                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (equip == false && input == 1) //인벤토리
                    {
                        equip = true;
                        Console.Clear();
                    }
                    else if (input == 0)//나가기
                    {
                        Console.Clear();
                        state = false;
                    }
                    else if (equip == true)//인벤토리 -장착관리
                    {
                        if (input <= playerItem.Count) // 인벤토리 장비 착용
                        {
                            //착용 미착용 전환 조건
                            if (playerItem[input - 1].Name.Contains(equipped))
                            {
                                playerItem[input - 1].Name = playerItem[input - 1].Name.Replace(equipped, "");
                            }
                            else
                                playerItem[input - 1].Name = playerItem[input - 1].Name.Insert(0, equipped);

                            Console.Clear();
                        }
                        else 
                        {
                            Console.Clear();
                            Console.WriteLine("잘못된 입력입니다.\n");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.\n");
                    }
                }
            }//while
        }//Inventory method

        public static void PrintEquipMenu( List<Item> ItemList,bool equip)
        {
            int i = 1;
            //인벤토리 아이템 리스트 출력
            foreach (Item item in ItemList)
            {
                if (equip)
                    Console.Write($"- {i++} ");
                Console.WriteLine($"{item.Name}\t| {item.AbilityType} +{item.Ability}\t| {item.Description}\t");
            }
        }//Equip Menu method

        public static void PrintStore(Player player, List<Item> storeItem,List<Item>playerItem)
        {
            bool state = true;
            bool buy = false;
            
            while (state)
            {
                if (buy == false)
                    Console.WriteLine("상점");
                else
                    Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Gold} G\n");
                Console.WriteLine("[아이템 목록]");

                PrintStoretItem(buy,storeItem,true);

                if (buy == false)
                    Console.WriteLine("\n1. 아이템 구매");

                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if(buy == false && input ==1) // 1. 상점 - 아이템구매 입장
                    {
                        buy = true;
                        Console.Clear();
                    }
                    else if (input == 0) // 상점에서 나가기
                    {
                        Console.Clear();
                        state = false;
                    }
                    else if (buy == true) // 1.상점 - 아이템구매 화면
                    {
                        if(0 < input && input <= storeItem.Count) // 상점 아이템을 입력했을때
                        {
                            if (storeItem[input-1].Paid.Contains("구매완료"))
                            {
                                //구매완료라면
                                Console.Clear();
                                Console.WriteLine("이미 구매한 아이템입니다.\n");
                            }
                            else
                            {
                                //구매하지 않았는데 보유금액이 충분하면
                                if (player.Gold >= storeItem[input - 1].Gold)
                                {
                                    //구매
                                    player.BuyItem(storeItem[input - 1].Gold); //플레이어 골드차감
                                    playerItem.Add(storeItem[input - 1]);
                                    storeItem[input - 1].Paid = storeItem[input - 1].Paid.Insert(0,"구매완료");
                                    Console.Clear();
                                    Console.WriteLine("구매를 완료했습니다.\n");
                                }
                                else// 보유금액이 부족
                                {
                                    Console.Clear();
                                    Console.WriteLine("Gold가 부족합니다.\n");
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("잘못된 입력입니다.\n");
                        }
                    }
                    else
                    {
                        Console.Clear(); 
                        Console.WriteLine("잘못된 입력입니다.\n");
                    }
                }
            }//while
        }//PrintStore method

        public static void PrintStoretItem(bool detailMenu, List<Item>ItemList, bool isBuy)
        {
            int i = 1;
            foreach (Item item in ItemList)
            {
                if (detailMenu)
                    Console.Write($"- {i++} ");

                Console.Write($"{item.Name}  \t| {item.AbilityType} +{item.Ability}\t| {item.Description}\t| ");

                if(item.Paid.Contains("구매완료"))
                    Console.WriteLine(item.Paid);
                else
                    Console.WriteLine("{0} G",item.Gold);
            }
        }//PCurrentItem Method

        public static void PrintRest(Player player)
        {
            bool state = true;
            while (state)
            {
                Console.WriteLine("휴식하기.");
                Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)", player.Gold);
                Console.WriteLine($"체 력 : {player.Hp}\n");

                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 0)
                    {
                        state = false;
                        Console.Clear();
                    }
                    else if (input == 1)
                    {
                        if (player.Gold < 500)
                        {
                            Console.Clear();
                            Console.WriteLine("Gold가 부족합니다.\n");
                        }
                        else
                        {
                            player.HpRecovery();
                            player.BuyItem(500);
                            Console.Clear();
                            Console.WriteLine("휴식을 완료했습니다.\n");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.\n");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.\n");
                }
            }
        }

    }//MenuClass
}
