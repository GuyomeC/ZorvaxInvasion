using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] public int currentCores;
    public TextMeshProUGUI currentMoneyOnUI;

    private void Start()
    {
        currentMoneyOnUI.text = currentCores.ToString();
    }


    void OnTriggerEnter2D(Collider2D truc)
    {
        if (truc.tag == "Coin")
        {
            currentCores ++;
            currentMoneyOnUI.text = currentCores.ToString();
            Destroy(truc.gameObject);
        }
    }


}
