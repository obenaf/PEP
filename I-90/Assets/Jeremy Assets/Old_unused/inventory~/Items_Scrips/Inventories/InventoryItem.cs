using DapperDino.Items.Hotbars;
using UnityEngine;

namespace DapperDino.Items.Inventories
{
    public abstract class InventoryItem : HotbarItem
    {
        [Header("Item Data")]
        [SerializeField] private Rarity rarity = null;
        [SerializeField] [Min(0)] private int sellPrice = 1;
        [SerializeField] [Min(1)] private int maxStack = 1;
        public enum Type { Default, Consumable, Weapon, Ammunition, Shield, Armor }
        public Type type = Type.Default;
        [SerializeField] [Min(1)] private int attackA = 1;

        public int Defence = 0;
        public int Health = 0;
        public int Accuracy = 0;



        public override string ColouredName
        {
            get
            {
                string hexColour = ColorUtility.ToHtmlStringRGB(rarity.TextColour);
                return $"<color=#{hexColour}>{Name}</color>";
            }
        }
        public int SellPrice => sellPrice;
        public int MaxStack => maxStack;
        public Rarity Rarity => rarity;
        public int Attack => attackA;
        
     

        
       


    }
}
