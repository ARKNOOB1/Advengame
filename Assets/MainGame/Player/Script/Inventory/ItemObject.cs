using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemObject : MonoBehaviour
{
    [SerializeField] public ItemData itemData;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.ItemIcon;
    }
}
