using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "item", menuName = "ScriptableObject/Item", order = 1)]
public class Item : ScriptableObject
{
    public string title;
    public string description;
    public Sprite icon;
    public int amount = 0;
    public int goldToGive, amountToHeal, maxAmount, nbrStack;
    public bool isStackable;

    [System.Serializable]
    public enum Type
    {
        Quest, Consommable, Commun
    }

    public Type type;

}
