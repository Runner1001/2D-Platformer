using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 


public class InventoryPanelSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public static InventoryPanelSlot focused;

    [SerializeField] private Image draggingItemImage;
    [SerializeField] private Outline outline;
    [SerializeField] private Color draggingColor = Color.grey;
    [SerializeField] private Image itemIcon; 

    private ItemSlot itemSlot; 

    public void Bind(ItemSlot itemSlot) 
    {
        this.itemSlot = itemSlot;
        itemSlot.OnChange += UpdateIcon; 
        UpdateIcon(); 
    }

    private void UpdateIcon()
    {
        if (itemSlot.Item != null) 
        {
            itemIcon.sprite = itemSlot.Item.Icon; 
            itemIcon.enabled = true;
        }
        else
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        if (itemSlot.IsEmpty) 
            return;

        itemIcon.color = draggingColor; 
        draggingItemImage.sprite = itemIcon.sprite; 
        draggingItemImage.enabled = true; 
    }

    public void OnDrag(PointerEventData eventData) 
    {
        draggingItemImage.transform.position = eventData.position; 
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        if (focused == null && Input.GetKey(KeyCode.LeftControl)) 
            itemSlot.RemoveItem();

        if(itemSlot.IsEmpty == false && focused != null) 
        {
            Inventory.Instance.Swap(itemSlot, focused.itemSlot); 
        }                                                        

        itemIcon.color = Color.white; 

        draggingItemImage.sprite = null; 
        draggingItemImage.enabled = false; 
    }                                       

    public void OnPointerClick(PointerEventData eventData) 
    {
        Debug.Log("Click");
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        focused = this; 
        outline.enabled = true; 
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        if (focused == this) 
            focused = null;

        outline.enabled = false; 
    }

    
}
