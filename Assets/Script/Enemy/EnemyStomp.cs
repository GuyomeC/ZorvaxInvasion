using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision collision)
    {
        if(collision.gameObject.tag == "Ennemi")
        {
            Destroy(collision.gameObject);
        }
    }
}
