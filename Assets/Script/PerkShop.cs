using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerkShop : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;

    [SerializeField] private GameObject NoEnoughMoney;

    public TextMeshProUGUI texteDash;
    public string takeDash = "Dash";
    private bool takeDash1 = false;
    private bool takeDash2 = false;
    private bool takeDash3 = false;
    public TextMeshProUGUI texteTripleJump;
    public string tripleJump = "Triple Jump";
    private bool tripleJump1 = false;
    private bool tripleJump2 = false;
    private bool tripleJump3 = false;
    public TextMeshProUGUI textehaveDashBas;
    public string DashBasTexte = "Dash Bas";
    private bool DashBas1 = false;
    private bool DashBas2 = false;
    private bool DashBas3 = false;


    private void Update()
    {

        if (takeDash1 && takeDash2 && takeDash3)
        {
            texteDash.text = "3/3";
        }
        else if ((takeDash1 && takeDash2) || (takeDash2 && takeDash3) || (takeDash1 && takeDash3))
        {
            texteDash.text = "2/3";
        } else if (takeDash1 || takeDash2 || takeDash3)
        {
            texteDash.text = "1/3";
        } else
        {
            texteDash.text = "0/3";
        }

    }

    public void BuyDashNv1()
    {
        if (takeDash1 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            takeDash1 = true;
        } else
        {
            NoEnoughMoney.GetComponent<Animator>().SetTrigger("NoEnoughMoney");
        }
    }
    public void BuyDashNv2()
    {
        if (takeDash2 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            takeDash2 = true;
        }
        else
        {
            NoEnoughMoney.GetComponent<Animator>().SetTrigger("NoEnoughMoney");
        }
    }
    public void BuyDashNv3()
    {
        if (takeDash3 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            takeDash3 = true;
        }
        else
        {
            NoEnoughMoney.GetComponent<Animator>().SetTrigger("NoEnoughMoney");
        }
    }

    public void BuyDash()
    {
        if (_entity.haveDash == false && takeDash1 && takeDash2 && takeDash3)
        {
            _entity.haveDash = true;
        } else
        {
            return;
        }
    }

    public void tripleJumpNv1()
    {
        if (tripleJump1 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            tripleJump1 = true;
        }
        else
        {
            return;
        }
    }
    public void tripleJumpNv2()
    {
        if (tripleJump2 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            tripleJump2 = true;
        }
        else
        {
            return;
        }
    }
    public void tripleJumpNv3()
    {
        if (tripleJump3 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            tripleJump3 = true;
        }
        else
        {
            return;
        }
    }

    public void BuyJump()
    {
        if (!HeroController.instance.haveTripleJump && tripleJump1 && tripleJump2 && tripleJump3)
        {
            HeroController.instance.haveTripleJump = true;
            _entity.maxJumpUse++;
        }
        else
        {
            return;
        }
    }

    public void BuyDashBasNv1()
    {
        if (DashBas1 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            DashBas1 = true;
        }
        else
        {
            return;
        }
    }
    public void BuyDashBasNv2()
    {
        if (DashBas2 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            DashBas2 = true;
        }
        else
        {
            return;
        }
    }
    public void BuyDashBasNv3()
    {
        if (DashBas3 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            DashBas3 = true;
        }
        else
        {
            return;
        }
    }

    public void BuyDashBas()
    {
        if (_entity.haveDashBas == false && DashBas1 && DashBas2 && DashBas3)
        {
            _entity.haveDashBas = true;
        }
        else
        {
            return;
        }
    }

}
