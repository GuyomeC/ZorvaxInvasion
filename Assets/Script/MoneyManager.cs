using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI currentMoneyOnUI;

    void Update()
    {
        currentMoneyOnUI = transform.Find("CurrentMoney").GetComponent<TextMeshProUGUI>();
    }


}
