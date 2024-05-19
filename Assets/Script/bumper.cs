using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumper : MonoBehaviour
{

    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;
    // Mettre ce script sur un Object avec un Trigger (collider sur lequel on coche la case trigger)
    // On a besoin de 2 variables : La puissance du bumper, et le rigidbody qu'on va vouloir bumper
    public float puissance = 20f;
    public float bumpTime;

    // Quand un Collider rentrera dans le trigger de notre bumper, on récupère son rigidbody et on le bump vers le haut (en Y)
    void OnTriggerEnter2D(Collider2D truc) {
        if (truc.tag == "CameraTriggerTarget") {
            Debug.Log("tes bumper");
            _entity._verticalSpeed += puissance;
            StartCoroutine(bumping(truc.gameObject));
        }        
    }

    IEnumerator bumping(GameObject player) {
        yield return new WaitForSeconds(bumpTime);
        Debug.Log("tes plus bumper");

    }
}
