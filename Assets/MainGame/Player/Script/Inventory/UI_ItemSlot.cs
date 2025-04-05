using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemSlot : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] private Image itemImage;

    public InventoryItem item;


    public void UpdataSlot(InventoryItem _newItem)
    {
        item = _newItem;

        itemImage.color = Color.white;

        if (item != null)
        {
            itemImage.sprite = item.data.ItemIcon;
        }
    }

    public void CleanUpSlot()
    {
        item = null;
        itemImage.sprite = null;
        itemImage.color = Color.white;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (item?.data == null)
            return;

        if(item.data.ItemType == ItemType.Effact)
        {
            Debug.Log("∏‘¿Ω");
        }
    }
}
