using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;   
public class ItemDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private ItemSlot itemSlot;
    private RectTransform hotbarRect;
    private RectTransform inventoryRect;

    public GameObject previewPrefab;
    private GameObject currentPreview;
    private Image image;
    private Color baseColor;
    private bool isHotbarSlot;

    void Start()
    {
        itemSlot = GetComponent<ItemSlot>();
        hotbarRect = GameManager.instance.hotbarTransform as RectTransform;
        inventoryRect = GameManager.instance.inventoryTransform as RectTransform;

        image = GetComponent<Image>();
        baseColor = image.color;

        isHotbarSlot = RectTransformUtility.RectangleContainsScreenPoint(hotbarRect, transform.position);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemSlot.OnCursorExit();
        itemSlot.isBeingDraged = true;

        //chage alpha
        var tmpColor = baseColor;
        tmpColor.a = 0.6f;
        image.color = tmpColor;

        currentPreview = Instantiate(previewPrefab, GameManager.instance.mainCanvas);
        currentPreview.GetComponent<Image>().sprite = itemSlot.Item.icon;
        currentPreview.transform.position = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentPreview.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemSlot.isBeingDraged = false;
        image.color = baseColor;

        if( (RectTransformUtility.RectangleContainsScreenPoint(hotbarRect, Input.mousePosition) && !isHotbarSlot)
            || (RectTransformUtility.RectangleContainsScreenPoint(inventoryRect, Input.mousePosition) && isHotbarSlot) )
        {
            Inventory.instance.SwitchHotbarInventory(itemSlot.Item);
        }

        Destroy(currentPreview);
    }
}
