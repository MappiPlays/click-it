using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MPS Upgrade")]
public class MPSUpgrade : ScriptableObject
{
    public string upgradeName;
    public Sprite artwork;
    public int basePrice;
    public float metersPerSecond;
    public float multiplier;
}
