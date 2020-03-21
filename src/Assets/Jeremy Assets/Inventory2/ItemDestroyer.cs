using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;

//namespace DapperDino.Items
{
    public class ItemDestroyer : Inventory, InventorySlot
    {
    public Inventory inventory;
    void Start()
    {
       

    }
    [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI areYouSureText = null;

        private int slotIndex = 0;

        private void OnDisable() => slotIndex = -1;

        public void Activate(ItemSlot itemSlot, int slotIndex)
        {
            this.slotIndex = slotIndex;

            areYouSureText.text = $"Are you sure you wish to destroy {itemSlot.quantity}x {itemSlot.item.ColouredName}?";

            gameObject.SetActive(true);
        }

        public void Destroy()
        {
            inventory.ItemContainer.RemoveAt(slotIndex);

            gameObject.SetActive(false);
        }
    }
}
