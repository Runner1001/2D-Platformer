using System;

[Serializable]
public class ItemSlot
{
    public event Action OnChange; 

    public Item Item;

    public bool IsEmpty => Item == null; 

    public void SetItem(Item item) 
    {
        Item = item;
        OnChange?.Invoke(); 
    }

    public void RemoveItem() 
    {
        SetItem(null);
    }

    public void Swap(ItemSlot itemSlotToSwap)
    {
        var itemInOtherSlot = itemSlotToSwap.Item; 
        itemSlotToSwap.SetItem(Item); 
        SetItem(itemInOtherSlot); 
    }
}
