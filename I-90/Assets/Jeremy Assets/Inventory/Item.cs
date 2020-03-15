using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NewItem",menuName = "Items/item")]

public class Item : ScriptableObject
{
    public Sprite icon;
    public string itemName = "New Item";
    public string itemDescription = "New Description";
    public int price = 0;
    public enum Type { Default,Consumable,Weapon,Ammunition,Shield,Armor}
    public Type type = Type.Default;
    public int Attack = 0;
    public int Defence = 0;
    public int Health = 0;
    public int Accuracy = 0;

    
}
