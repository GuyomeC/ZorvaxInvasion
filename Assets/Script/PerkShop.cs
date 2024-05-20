using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerkShop : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;

    public TextMeshProUGUI texteDash;
    public string takeDash = "Dash";
    public TextMeshProUGUI texteJumpNiveau1;
    public string jumpNv1 = "Double Jump";


    private void Start()
    {
        texteJumpNiveau1.text = jumpNv1;
        texteDash.text = takeDash;
    }

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
        if (MoneyManager.instance.currentCores >= 3 && !HeroController.instance.haveJumpNv1)
        {
            HeroController.instance.haveJumpNv1 = true;
            _entity.maxJumpUse++;
            MoneyManager.instance.currentCores -= 3;
        }
        else
        {
            return;
        }
    }

}
