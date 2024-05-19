using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerkShop : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;

    public TextMeshProUGUI texteDash;
    public TextMeshProUGUI texteJumpNiveau1;
    public string jumpNv1 = "Double Jump";
    public TextMeshProUGUI texteJumpNiveau2;
    public string jumpNv2 = "Triple Jump";


    public void BuyDash()
    {
        if (_entity.haveDash == false && MoneyManager.instance.currentCores >= 3)
        {
            _entity.haveDash = true;
            MoneyManager.instance.currentCores -= 3;
        } else
        {
            return;
        }
    }

    public void BuyJumpNv1()
    {
        if (_entity.haveDash == false && MoneyManager.instance.currentCores >= 3)
        {
            HeroController.instance.haveJumpNv1 = true;
            MoneyManager.instance.currentCores -= 3;
            texteJumpNiveau1.text = jumpNv1;
        }
        else
        {
            return;
        }
    }

    public void BuyJumpNv2()
    {
        if (_entity.haveDash == false && MoneyManager.instance.currentCores >= 3 && HeroController.instance.haveJumpNv1 == true)
        {
            HeroController.instance.haveJumpNv2 = true;
            MoneyManager.instance.currentCores -= 3;
            texteJumpNiveau2.text = jumpNv2;
        }
        else
        {
            return;
        }
    }
}
