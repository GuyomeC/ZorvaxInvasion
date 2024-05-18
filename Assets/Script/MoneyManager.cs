using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MoneyManager : MonoBehaviour
{

    [SerializeField] private HeroController _heroController;
    public TextMeshProUGUI currentMoneyOnUI;

    void Update()
    {
        currentMoneyOnUI.text = _heroController.currentMoney.ToString();
    }


}
