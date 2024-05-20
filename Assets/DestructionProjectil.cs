using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionProjectil : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.x > 100)
        {
            Destroy(gameObject);
        }
    }
}
