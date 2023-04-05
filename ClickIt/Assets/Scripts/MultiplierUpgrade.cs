using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Multiplier Upgrade")]
public class MultiplierUpgrade : ScriptableObject
{
    public string upgradeName;
    public Sprite artwork;
    public int price;
    public float clickPowerMultiplier;
    public MPSUpgrade[] effectedMPSUpgrades;
    public float[] mpsUpgradeMultipliers;
}
