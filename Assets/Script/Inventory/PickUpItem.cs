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
            InventoryManager.instance.inventory.Add(item);
            Debug.Log("j'ai ajouté " + item.title + " dans l'inventaire");
            Destroy(gameObject);
        }
    }
}
