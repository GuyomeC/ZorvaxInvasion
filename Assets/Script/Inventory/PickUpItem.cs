using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            for(int i =0; i < InventoryManager.instance.inventory.Count; i++)
            {
                if( item.title == InventoryManager.instance.inventory[i].title && item.isStackable && InventoryManager.instance.inventory.Count > 0)
                {
                    item.amount += InventoryManager.instance.inventory[i].amount;
                    InventoryManager.instance.inventory.Remove(InventoryManager.instance.inventory[i]);
                }
            }

            InventoryManager.instance.inventory.Add(item);
            Debug.Log("j'ai ajouté " + item.title + " dans l'inventaire");
            Destroy(gameObject);
        }
    }
}
