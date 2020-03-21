using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DapperDino.Items;

public class Player_Pickup_item : MonoBehaviour
{
    public IItemContainer iitemconaterin;
    public ItemContainer itemcontainerin;
    public ItemSlot itemslotin;
    public Inventory inventoryin;
    
  
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<string>();
        if(item!=null)
        {


            //itemcontainerin.AddItem;
            
        }
    }
}
