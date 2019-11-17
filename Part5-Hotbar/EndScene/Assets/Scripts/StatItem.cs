using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "StatItem", menuName = "Item/StatItem")]
public class StatItem : Item
{

    public StatItemType itemType;
    public int amount;

    public override void Use()
    {
        base.Use();
        //add something to it
        GameManager.instance.OnStatItemuUse(itemType, amount);
        Inventory.instance.RemoveItem(this);
    }
}


public enum StatItemType
{
    HealthItem,
    ThirstItem,
    FoodItem
}