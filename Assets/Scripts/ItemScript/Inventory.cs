using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //[SerializeField] private GameObject InventoryPanel;

    public ItemSlot[] Slots;

    public void GetItem(Item item)
    {
        if (gameObject.name == "WeaponSlotsPanel" && item.type == Item.Type.Weapon)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].name == item.name)
                {
                    return;
                }
                if (Slots[i].item == null)
                {
                    Slots[i].AddItem(item);
                    return;
                }
            }
        }
        else if (gameObject.name == "AccessorySlotsPanel" && item.type == Item.Type.Accessory)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].name == item.name)
                {
                    return;
                }
                if (Slots[i].item == null)
                {
                    Slots[i].AddItem(item);
                    return;
                }
            }
        }
    }
}
