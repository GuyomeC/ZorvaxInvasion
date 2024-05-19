using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkShop : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;

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


}
