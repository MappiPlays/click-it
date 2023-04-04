using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Autoclick Upgrade")]
public class CPSUpgrade : ScriptableObject
{
    public string upgradeName;
    public Sprite artwork;
    public int basePrice;
    public float cps;
}
