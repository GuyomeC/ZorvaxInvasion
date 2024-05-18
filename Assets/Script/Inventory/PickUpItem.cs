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
            bool itemFound = false;
            for (int i = 0; i < InventoryManager.instance.inventory.Count; i++)
            {
                if (item.title == InventoryManager.instance.inventory[i].title && item.isStackable)
                {
                    InventoryManager.instance.inventory[i].amount += item.nbrStack;
                    itemFound = true;
                    break;
                }
            }

            if (!itemFound)
            {
                InventoryManager.instance.inventory.Add(item);
                item.amount = item.nbrStack;
            }

            Debug.Log("j'ai ajouté " + item.nbrStack + " " + item.title + " dans l'inventaire");
            Destroy(gameObject);
        }
    }
}
