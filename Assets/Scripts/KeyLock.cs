using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class KeyLock : MonoBehaviour
{
    [SerializeField] private UnityEvent onUnlock;
    [SerializeField] private KeyColor keyType;

    private bool playerInRange;

    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.F)) 
        {
            
            //var slot = Inventory.Instance.InventorySlots.Where(t => t.IsEmpty == false).FirstOrDefault(t => t.Item.KeyType == keyType);
            //var slot = Inventory.Instance.InventorySlots;
            var firstSlot = Inventory.Instance.InventorySlots[0];

            if(firstSlot.Item != null && firstSlot.Item.KeyType == keyType)
            {
                firstSlot.RemoveItem();
                onUnlock.Invoke();
                //Destroy(this.gameObject);
            }

            //if(slot != null) 
            //{
            //    slot.RemoveItem(); 
            //    Destroy(this.gameObject); 
            //}
            //else
            //{
            //    Debug.Log("Non hai la chiave rossa");
            //}
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; //controllo che il player sia vicino al gameObect e setto la variabile a true
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; //controllo che il player non sia più vicino al gameObject e di conseguenza sia uscito dal trigger e setto la variabile a false
        } 
    }
}
