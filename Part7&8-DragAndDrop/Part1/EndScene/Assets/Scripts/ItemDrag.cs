using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private ItemSlot itemSlot;
    private Transform baseParent;
    private RectTransform hotbarRect;
    private int siblingIdx;

    void Start()
    {
        itemSlot = GetComponent<ItemSlot>();
        baseParent = transform.parent;
        hotbarRect = GameManager.instance.hotbarTransform as RectTransform;
        siblingIdx = transform.GetSiblingIndex();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(GameManager.instance.mainCanvas);
        itemSlot.OnCursorExit();
        itemSlot.isBeingDraged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(baseParent);
        transform.SetSiblingIndex(siblingIdx);
        itemSlot.isBeingDraged = false;

        if(RectTransformUtility.RectangleContainsScreenPoint(hotbarRect, Input.mousePosition))
        {
            Inventory.instance.SwitchHotbarInventory(itemSlot.Item);
        }
    }
}
