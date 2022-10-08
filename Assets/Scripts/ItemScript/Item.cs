using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type
    {
        Exp,
        Gold,
        Food,
        Weapon,
        Accessory,
        Box
    };
    public Type type;
    public int value;
    public Sprite itemImage;
}
