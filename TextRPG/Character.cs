using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Player
    {
        public int Level { get; private set; }
        public string Name { get; }
        public string CharacterClass { get; }
        public float Att  { get; private set; }
        public int Def { get; private set; }
        public int Hp { get; private set; }
        public int Gold { get; private set; }

        public int ItemAtt { get; set; }
        public int ItemDef { get; set; }

        public Player(int level, string name, string characterClass, float att, int def, int hp, int gold, int itemAtt = 0, int itemDef = 0)
        {
            this.Level = level;
            this.Name = name;
            this.CharacterClass = characterClass;
            this.Att = att;
            this.Def = def;
            this.Hp = hp;
            this.Gold = gold;
            this.ItemAtt = itemAtt;
            this.ItemDef = itemDef;
        }

        public int BuyItem(int gold)
        {
            return Gold -= gold;
        }
        public int SellItem(int gold)
        {
            return Gold += (int)(gold * 0.85f);
        }

        public int AddGold(int gold)
        {
            return Gold += gold;
        }


        public void HpRecovery()
        {
            Hp = 100;
        }
        public int ReduceHp(int i)
        {
            Hp -= i;
            if (Hp < 0)
                Hp = 0;
            return Hp;
        }

        public int DevideHp()
        {
            return Hp /= 2;
        }

        public int TotalDef()
        {
            return ItemDef + Def;
        }
        public int TotalAtt()
        {
            return ItemAtt + (int)Att;
        }
        public void LevelUp()
        {
            Level++;
            Def += 1;
            Att += 0.5f;
        }
    }
}
