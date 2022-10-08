using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UsableItems
{
    LaserBlast
}
public abstract class ActiveItem : MonoBehaviour
{
    [SerializeField] float DMG;
}
