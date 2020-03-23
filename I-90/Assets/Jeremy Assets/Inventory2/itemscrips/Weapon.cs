using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory System/Items/Weapon")]
public class Weaponobject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Weapon; }
 
}