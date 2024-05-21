using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkShop : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;

    [SerializeField] private GameObject NoEnoughMoney;

    public TextMeshProUGUI texteDash;
    private bool takeDash1 = false;
    [SerializeField] private GameObject wayTakeDash1;
    private bool takeDash2 = false;
    [SerializeField] private GameObject wayTakeDash2;
    private bool takeDash3 = false;
    [SerializeField] private GameObject wayTakeDash3;
    public TextMeshProUGUI texteTripleJump;
    private bool tripleJump1 = false;
    [SerializeField] private GameObject wayTripleJump1;
    private bool tripleJump2 = false;
    [SerializeField] private GameObject wayTripleJump2;
    private bool tripleJump3 = false;
    [SerializeField] private GameObject wayTripleJump3;
    public TextMeshProUGUI textehaveDashBas;
    private bool DashBas1 = false;
    [SerializeField] private GameObject wayDashBas1;
    private bool DashBas2 = false;
    [SerializeField] private GameObject wayDashBas2;
    private bool DashBas3 = false;
    [SerializeField] private GameObject wayDashBas3;

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

        if (tripleJump1 && tripleJump2 && tripleJump3)
        {
            texteTripleJump.text = "3/3";
        }
        else if ((tripleJump1 && tripleJump2) || (tripleJump2 && tripleJump3) || (tripleJump1 && tripleJump3))
        {
            texteTripleJump.text = "2/3";
        }
        else if (tripleJump1 || tripleJump2 || tripleJump3)
        {
            texteTripleJump.text = "1/3";
        }
        else
        {
            texteTripleJump.text = "0/3";
        }

        if (DashBas1 && DashBas2 && DashBas3)
        {
            textehaveDashBas.text = "3/3";
        }
        else if ((DashBas1 && DashBas2) || (DashBas2 && DashBas3) || (DashBas1 && DashBas3))
        {
            textehaveDashBas.text = "2/3";
        }
        else if (DashBas1 || DashBas2 || DashBas3)
        {
            textehaveDashBas.text = "1/3";
        }
        else
        {
            textehaveDashBas.text = "0/3";
        }

    }

    public void BuyDashNv1()
    {
        if (takeDash1 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            takeDash1 = true;
            ChangeImageColor changeImageColor = new ChangeImageColor();
            Image myImage = wayTakeDash1.GetComponent<Image>();
            changeImageColor.SetColor(myImage, Color.green);

        }
        else
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
            ChangeImageColor changeImageColor = new ChangeImageColor();
            Image myImage = wayTakeDash2.GetComponent<Image>();
            changeImageColor.SetColor(myImage, Color.green);
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
            ChangeImageColor changeImageColor = new ChangeImageColor();
            Image myImage = wayTakeDash3.GetComponent<Image>();
            changeImageColor.SetColor(myImage, Color.green);
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
            ChangeImageColor changeImageColor = new ChangeImageColor();
            Image myImage = wayTripleJump1.GetComponent<Image>();
            changeImageColor.SetColor(myImage, Color.green);
        }
        else
        {
            NoEnoughMoney.GetComponent<Animator>().SetTrigger("NoEnoughMoney");

        }
    }
    public void tripleJumpNv2()
    {
        if (tripleJump2 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            tripleJump2 = true;
            ChangeImageColor changeImageColor = new ChangeImageColor();
            Image myImage = wayTripleJump2.GetComponent<Image>();
            changeImageColor.SetColor(myImage, Color.green);
        }
        else
        {
            NoEnoughMoney.GetComponent<Animator>().SetTrigger("NoEnoughMoney");

        }
    }
    public void tripleJumpNv3()
    {
        if (tripleJump3 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            tripleJump3 = true;
            ChangeImageColor changeImageColor = new ChangeImageColor();
            Image myImage = wayTripleJump3.GetComponent<Image>();
            changeImageColor.SetColor(myImage, Color.green);
        }
        else
        {
            NoEnoughMoney.GetComponent<Animator>().SetTrigger("NoEnoughMoney");

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
            ChangeImageColor changeImageColor = new ChangeImageColor();
            Image myImage = wayDashBas1.GetComponent<Image>();
            changeImageColor.SetColor(myImage, Color.green);
        }
        else
        {
            NoEnoughMoney.GetComponent<Animator>().SetTrigger("NoEnoughMoney");

        }
    }
    public void BuyDashBasNv2()
    {
        if (DashBas2 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            DashBas2 = true;
            ChangeImageColor changeImageColor = new ChangeImageColor();
            Image myImage = wayDashBas2.GetComponent<Image>();
            changeImageColor.SetColor(myImage, Color.green);
        }
        else
        {
            NoEnoughMoney.GetComponent<Animator>().SetTrigger("NoEnoughMoney");

        }
    }
    public void BuyDashBasNv3()
    {
        if (DashBas3 == false && MoneyManager.instance.currentCores >= 1)
        {
            MoneyManager.instance.currentCores -= 1;
            DashBas3 = true;
            ChangeImageColor changeImageColor = new ChangeImageColor();
            Image myImage = wayDashBas3.GetComponent<Image>();
            changeImageColor.SetColor(myImage, Color.green);
        }
        else
        {
            NoEnoughMoney.GetComponent<Animator>().SetTrigger("NoEnoughMoney");

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
