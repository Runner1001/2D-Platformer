using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item", fileName = "Item")]
public class Item : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public KeyColor KeyType;

    [ContextMenu("Aggiungi questo item all'inventario")]
    public void AddItemForDebug()
    {
        Inventory.Instance.AddItem(this);
    }
}

public enum KeyColor
{
    Blue,
    Green,
    Red,
    Yellow
}
