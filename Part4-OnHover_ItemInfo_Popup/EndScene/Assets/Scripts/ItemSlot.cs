using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    private Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }   
    
    public void DestroySlot()
    {
        Destroy(gameObject);
    }

    public void OnRemoveButtonClicked()
    {
        if(item != null)
        {
            Inventory.instance.RemoveItem(item);
        }
    }

    
    public void OnCursorEnter()
    {
        //display item info
        GameManager.instance.DisplayItemInfo(item.name, item.GetItemDescription(), transform.position);
    }

    public void OnCursorExit()
    {
        GameManager.instance.DestroyItemInfo();
    }
}
