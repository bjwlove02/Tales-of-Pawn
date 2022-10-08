using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Accessory
{
    Heart,
    Sword,
    Lightning,
    Stopwatch,
    Null
}

public class PlayerAccessorys : MonoBehaviour
{
    [SerializeField] private Accessories[] accessorys;

    public void ActiveAccessory(Accessory accName)
    {
        if (accName == Accessory.Heart)
        {
            accessorys[(int)Accessory.Heart].GetAccessory();
        }
        else if (accName == Accessory.Sword)
        {
            accessorys[(int)Accessory.Sword].GetAccessory();
        }
        else if (accName == Accessory.Lightning)
        {
            accessorys[(int)Accessory.Lightning].GetAccessory();
        }
        else if (accName == Accessory.Stopwatch)
        {
            accessorys[(int)Accessory.Stopwatch].GetAccessory();
        }
    }
}