using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Player
    {
        public int Level { get; }
        public string Name { get; }
        public string CharacterClass { get; }
        public int Att  { get; }
        public int Def { get; }
        public int Hp { get; private set; }
        public int Gold { get; private set; }

        public Player(int level, string name, string characterClass, int att, int def, int hp, int gold)
        {
            this.Level = level;
            this.Name = name;
            this.CharacterClass = characterClass;
            this.Att = att;
            this.Def = def;
            this.Hp = hp;
            this.Gold = gold;
        }

        public int BuyItem(int gold)
        {
            return Gold -= gold;
        }

        public void HpRecovery()
        {
            Hp = 100;
        }
    }
}
