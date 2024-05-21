using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float damageInterval = 3.0f; // D�lai entre chaque d�g�t
    public int damageAmount = 1; // Quantit� de d�g�ts inflig�s

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CameraTriggerTarget")) // V�rifie si le joueur est entr� dans la zone
        {
            StartCoroutine(DamagePlayer(other.gameObject)); // Commence � infliger des d�g�ts
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CameraTriggerTarget")) // V�rifie si le joueur a quitt� la zone
        {
            StopCoroutine(DamagePlayer(other.gameObject)); // Arr�te d'infliger des d�g�ts
        }
    }

    private IEnumerator DamagePlayer(GameObject player)
    {
        while (true)
        {
            yield return new WaitForSeconds(damageInterval); // Attend l'intervalle de d�g�ts
            player.GetComponent<HeroTakeDamage>().TakeDamage(damageAmount); // Inflige des d�g�ts au joueur
        }
    }
}

