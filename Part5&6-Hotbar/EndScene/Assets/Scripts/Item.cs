using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName ="Item/baseItem")]
public class Item : ScriptableObject
{
    new public string name = "Defulat Item";
    public Sprite icon = null;
    public string itemDescription = "Used for crafting";

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

    public virtual string GetItemDescription()
    {
        return itemDescription;
    }
}
