using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float damageInterval = 3.0f; // Délai entre chaque dégât
    public int damageAmount = 1; // Quantité de dégâts infligés

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CameraTriggerTarget")) // Vérifie si le joueur est entré dans la zone
        {
            StartCoroutine(DamagePlayer(other.gameObject)); // Commence à infliger des dégâts
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CameraTriggerTarget")) // Vérifie si le joueur a quitté la zone
        {
            StopCoroutine(DamagePlayer(other.gameObject)); // Arrête d'infliger des dégâts
        }
    }

    private IEnumerator DamagePlayer(GameObject player)
    {
        while (true)
        {
            yield return new WaitForSeconds(damageInterval); // Attend l'intervalle de dégâts
            player.GetComponent<HeroTakeDamage>().TakeDamage(damageAmount); // Inflige des dégâts au joueur
        }
    }
}

