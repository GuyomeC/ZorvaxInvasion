using UnityEngine;
using UnityEngine.UI;

public class ChangeImageColor : MonoBehaviour
{
    // Fonction pour changer la couleur
    public void SetColor(Image image, Color color)
    {
        if (image != null)
        {
            image.color = color;
        }
        else
        {
            Debug.LogError("Le composant Image passé en paramètre est null.");
        }
    }
}

