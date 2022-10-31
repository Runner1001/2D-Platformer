using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Item item; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var slot = Inventory.Instance.InventorySlots.FirstOrDefault(t => t.IsEmpty == true);
            if (slot != null)
            {
                Inventory.Instance.AddItem(item); 
                Destroy(this.gameObject);
            }
        }
    }
}
