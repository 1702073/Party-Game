using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Shop Data", menuName = "Scriptable Objects/Shop Data")]
public class ShopData : ScriptableObject
{
    public Sprite skin;
    public int cost;
}
