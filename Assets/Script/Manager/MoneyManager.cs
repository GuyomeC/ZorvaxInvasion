using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] public int currentCores;
    public TextMeshProUGUI currentMoneyOnUI;

    public static MoneyManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentMoneyOnUI.text = currentCores.ToString();
    }

    private void Update()
    {
        currentMoneyOnUI.text = currentCores.ToString();
    }

    void OnTriggerEnter2D(Collider2D truc)
    {
        if (truc.tag == "Coin")
        {
            currentCores += 5;
            currentMoneyOnUI.text = currentCores.ToString();
            Destroy(truc.gameObject);
        }
    }
}
