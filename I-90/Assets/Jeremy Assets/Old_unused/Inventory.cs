﻿/*
using DapperDino.Events.CustomEvents;
using UnityEngine;
using System;


namespace DapperDino.Items
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Items/Inventory")]


    public class Inventory : ScriptableObject
    {
        [SerializeField] private VoidEvent onInventoryItemsUpdated = null;
        public ItemContainer ItemContainer { get; } = new ItemContainer(20);
        public void OnEnable() => ItemContainer.OnItemsUpdated += onInventoryItemsUpdated.Raise;

        public void OnDisable() => ItemContainer.OnItemsUpdated -= onInventoryItemsUpdated.Raise;

    }

}*/