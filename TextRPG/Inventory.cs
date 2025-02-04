using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Inventory
    {
        private List<Item> ItemList = new List<Item>();

        public void AddItem(Item item)
        {
            ItemList.Add(item);
        }

        public List<Item> GetItem()
        {
            return ItemList;
        }

    }
    class Item
    {
        public string Name { get; set; }
        public int Ability { get; }
        public string AbilityType { get; }
        public string Description { get; }
        public int Gold{ get; }
        public string Paid { get;  set; }

        public Item(string name, string abilitiyType, int ability ,string desc,int gold, string paid = "")
        {
            Name = name;
            AbilityType = abilitiyType;
            Ability = ability;
            Description = desc;
            Gold = gold;
            Paid = paid;
        }

    }


}
