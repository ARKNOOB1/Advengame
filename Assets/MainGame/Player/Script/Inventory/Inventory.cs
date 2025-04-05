using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<InventoryItem> item;
    public Dictionary<ItemData, InventoryItem> itemDictionary;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        item = new List<InventoryItem>();
        itemDictionary = new Dictionary<ItemData, InventoryItem>();
    }

    public void AddItem(ItemData _item)
    {
        InventoryItem newItem = new InventoryItem(_item);
        item.Add(newItem);

        UpdateSlotUI();
    }

    public void RemoveItem(ItemData _item)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].data == _item)
            {

                item.RemoveAt(i);
                break;
            }
        }

        UpdateSlotUI();
    }

    public void UpdateSlotUI()
    {
        UIManager ui = UIManager.Instance;

        if (ui.itemSlotParent != null)
        {
            for(int i = 0;i < ui.itemSlot.Length;i++)
            {
                ui.itemSlot[i].CleanUpSlot();
            }

            for(int i = 0; i < item.Count; i++)
            {
                ui.itemSlot[i].UpdataSlot(item[i]);
            }
        }
    }

    public void AddDictionary(ItemData _item)
    {
        if (!itemDictionary.ContainsKey(_item))
        {
            InventoryItem newItem = new InventoryItem(_item);
            itemDictionary.Add(_item, newItem);
            GameManager.instance.coin += _item.itemCoin;
        }
    }


}


