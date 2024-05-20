using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegatAttaque : MonoBehaviour
{
    public void consoleDeOuf()
    {
        HeroController.instance.OnAttack();
    }
}
