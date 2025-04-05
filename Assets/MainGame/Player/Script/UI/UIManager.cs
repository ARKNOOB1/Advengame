using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Inventory UI")]
    [SerializeField] public Transform[] itemSlotParent;

    public UI_ItemSlot[] itemSlot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        if (itemSlotParent[GameManager.instance.bagIndex].gameObject != null)
        {
            itemSlotParent[GameManager.instance.bagIndex].gameObject.SetActive(true);
            itemSlot = itemSlotParent[GameManager.instance.bagIndex].GetComponentsInChildren<UI_ItemSlot>();
        }

        Inventory.Instance.UpdateSlotUI();
    }
}
