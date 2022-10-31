using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int INVENTORY_SIZE = 4; 

    public ItemSlot[] InventorySlots = new ItemSlot[INVENTORY_SIZE]; 

    public static Inventory Instance { get; private set; } 

    void Awake()
    {
        Instance = this; 

        for (int i = 0; i < INVENTORY_SIZE; i++)
        {
            InventorySlots[i] = new ItemSlot(); 
        }
    }

    public void AddItem(Item item) 
    {
        AddItemToSlot(item, InventorySlots);
    }

    private void AddItemToSlot(Item item, ItemSlot[] inventorySlots)
    {
        var slot = inventorySlots.FirstOrDefault(t => t.IsEmpty); 
        if(slot != null)
        {
            slot.SetItem(item); 
        }
    }

    public void Swap(ItemSlot sourceSlot, ItemSlot targetSlot) 
    {
        if (targetSlot != null && targetSlot.IsEmpty && Input.GetKey(KeyCode.LeftShift)) 
        {
            targetSlot.SetItem(sourceSlot.Item);
        }
        else
        {
            sourceSlot.Swap(targetSlot); 
        }
    }
}