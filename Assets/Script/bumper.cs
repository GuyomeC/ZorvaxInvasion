using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumper : MonoBehaviour
{

    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;
    // Mettre ce script sur un Object avec un Trigger (collider sur lequel on coche la case trigger)
    // On a besoin de 2 variables : La puissance du bumper, et le rigidbody qu'on va vouloir bumper
    public Vector2 puissance = new Vector2 (0,10f);
    public float bumpTime;

    // Quand un Collider rentrera dans le trigger de notre bumper, on récupère son rigidbody et on le bump vers le haut (en Y)
    void OnTriggerEnter2D(Collider2D truc) {
        if (truc.tag == "Player") {
            _entity._rigidbody.AddForce(puissance);
            truc.GetComponent<HeroEntity>().enabled = false;
            StartCoroutine(bumping(truc.gameObject));
        }        
    }

    IEnumerator bumping(GameObject player) {
        yield return new WaitForSeconds(bumpTime);
        player.GetComponent<HeroEntity>().enabled = true;
    }
}
