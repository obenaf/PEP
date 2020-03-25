using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupitem : MonoBehaviour
{
   
        public InventoryObject inventory; 
        // Start is called before the first frame update

        public void OnTriggerEnter(Collider other)
        {
            var item = other.GetComponent<GroundItem>();
            if (item)
            {
                Item _item = new Item(item.item);
                Debug.Log(_item.Id);
                inventory.AddItem(_item, 1);
                Destroy(other.gameObject);
            }
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            var item = collision.GetComponent<GroundItem>();
            if (item)
            {
                Item _item = new Item(item.item);
                Debug.Log(_item.Id);
            if(inventory.Inventoryfull()==true)//checks to see if inventory is full
            { inventory.AddItem(_item, 1);
               Destroy(collision.gameObject);
            }
    
            }
        }

    
}
