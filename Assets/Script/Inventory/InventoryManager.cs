using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager: MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;
    [SerializeField] private HeroController _heroController;

    public List<Item> inventory;
    public int inventoryLenght = 24;
    public GameObject inventoryPanel, holderSlot;
    private GameObject slot;
    public GameObject prefabs;

    public TextMeshProUGUI title, descriptionObject;
    public Image iconDescription;

    [Header ("Description")]
    public GameObject holderDescription;
    private int amountToUse;
    [SerializeField] private TextMeshProUGUI valueToUse;
    [SerializeField] private Button plusBoutton, moinsBoutton;
    [SerializeField] private GameObject useBouton;
    [SerializeField] private GameObject removeBouton;
    [SerializeField] private GameObject amountToRemove;


    public static InventoryManager instance;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !inventoryPanel.activeInHierarchy)
        {
            inventoryPanel.SetActive(true);
            RefreshInventaire();
            _heroController.CanMove = false;

        }
        else if (Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy)
        {
            inventoryPanel.SetActive(false);
            _heroController.CanMove = true;

        }
    }

    private void RefreshInventaire()
    {
        if (holderSlot.transform.childCount > 0)
        {
            foreach (Transform item in holderSlot.transform)
            {
                Destroy(item.gameObject);
            }
        }

        for (int i = 0; i < inventoryLenght; i++)
        {
            if (i <= inventory.Count - 1)
            {
                slot = Instantiate(prefabs, transform.position, transform.rotation);
                slot.transform.SetParent(holderSlot.transform);

                TextMeshProUGUI amount = slot.transform.Find("Amount").GetComponent<TextMeshProUGUI>();
                Image img = slot.transform.Find("Icon").GetComponent<Image>();
                slot.GetComponent<SlotItem>().itemSlot = i;

                amount.text = inventory[i].amount.ToString();
                img.sprite = inventory[i].icon;
            }
            else if (i > inventory.Count - 1)
            {
                slot = Instantiate(prefabs, transform.position, transform.rotation);
                slot.transform.SetParent(holderSlot.transform);
                TextMeshProUGUI amount = slot.transform.Find("Amount").GetComponent<TextMeshProUGUI>();
                Button img = slot.transform.Find("Icon").GetComponent<Button>();
                img.enabled = false;
                amount.gameObject.SetActive(false);
            }

        }
    }

    public void ChargeItem(int i)
    {
        amountToUse = 0;
        valueToUse.text = amountToUse + "/" + inventory[i].maxAmount;
        if (inventory[i].type == Item.Type.Consommable)
        {
            useBouton.SetActive(true);
            removeBouton.SetActive(true);
            amountToRemove.SetActive(true);
        }
        else if (inventory[i].type == Item.Type.Quest)
        {
            useBouton.SetActive(false);
            removeBouton.SetActive(false);
            amountToRemove.SetActive(false);
        }
        if (inventory[i].type == Item.Type.Commun)
        {
            useBouton.SetActive(false);
            removeBouton.SetActive(true);
            amountToRemove.SetActive(true);
        }
        holderDescription.SetActive(true);
        title.text = inventory[i].title;
        descriptionObject.text = inventory[i].description;
        iconDescription.sprite = inventory[i].icon;

        plusBoutton.GetComponent<Button>().onClick.RemoveAllListeners();
        plusBoutton.GetComponent <Button>().onClick.AddListener(delegate { PlusButton(i); });

        moinsBoutton.GetComponent<Button>().onClick.RemoveAllListeners();
        moinsBoutton.GetComponent<Button>().onClick.AddListener(delegate { MoinsButton(i); });

        useBouton.GetComponent<Button>().onClick.RemoveAllListeners();
        useBouton.GetComponent<Button>().onClick.AddListener(delegate { UseItem(i); });

        removeBouton.GetComponent<Button>().onClick.RemoveAllListeners();
        removeBouton.GetComponent<Button>().onClick.AddListener(delegate { RemoveItem(i); });
    }

    public void UseItem(int i)
    {
        for(int x = 0; x < amountToUse; x++)
        {
            if (inventory[i].title == "Coeur" && HeroController.instance.currentHealth < 3)
                HeroController.instance.currentHealth += inventory[i].amountToHeal;
            if(inventory[i].title == "Cores")
                HeroController.instance.currentCores += inventory[i].amountToHeal;
            if (inventory[i].amount == 1)
            {
                inventory.Remove(inventory[i]);
                holderDescription.SetActive(false);
                amountToUse = 0;
                break;
            }
            else
            {
                inventory[i].amount--;
            }
        }
        RefreshInventaire();
        if (i < inventory.Count)
        {
            valueToUse.text = amountToUse + "/" + inventory[i].maxAmount;
        }
    }

    public void RemoveItem(int i)
    {
        for (int x = 0; x < amountToUse; x++)
        {
            if (inventory[i].amount <= 1)
            {
                inventory.Remove(inventory[i]);
                holderDescription.SetActive(false);
                amountToUse = 0;
                break;
            }
            else
            {
                inventory[i].amount--;
            }
        }
        RefreshInventaire();
        if (i < inventory.Count)
        {
            valueToUse.text = amountToUse + "/" + inventory[i].maxAmount;
        }

    }

    public void PlusButton(int i)
    {
        if(amountToUse <= inventory[i].amount - 1)
            amountToUse++;
        valueToUse.text = amountToUse + "/" + inventory[i].maxAmount;
    }

    public void MoinsButton(int i)
    {
        if (amountToUse > 0)
            amountToUse--;
        valueToUse.text = amountToUse + "/" + inventory[i].maxAmount;
    }
}
