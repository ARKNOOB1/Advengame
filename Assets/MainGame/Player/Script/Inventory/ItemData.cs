using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Treasure,
    Effact
}
[CreateAssetMenu(fileName = "new Item Data", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public ItemType ItemType;
    public string ItemName;
    public Sprite ItemIcon;
    public int itemCoin;
    public int itemWeight;
}
