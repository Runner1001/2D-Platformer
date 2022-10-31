using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : ToggleablePanel
{
    void Start()
    {
        Bind(Inventory.Instance);
    }

    private void Bind(Inventory inventory)
    {
        var panelSlots = GetComponentsInChildren<InventoryPanelSlot>().ToArray(); 

        for (int i = 0; i < panelSlots.Length; i++) 
        {
            panelSlots[i].Bind(inventory.InventorySlots[i]); 
        }
    }
}
