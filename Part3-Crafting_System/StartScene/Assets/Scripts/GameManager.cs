using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Inventory.instance.AddItem(itemList[Random.Range(0, itemList.Count)]);
        }
    }

}
