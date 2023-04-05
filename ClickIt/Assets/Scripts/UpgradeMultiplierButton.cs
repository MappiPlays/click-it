using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMultiplierButton : MonoBehaviour
{
    public static event Action<MultiplierUpgrade> OnMultiplierBougth;

    public MultiplierUpgrade multiplierUpgrade;
    private int upgradeCost;

    private Button button;
    private TextMeshProUGUI[] texts;
    
    void Start()
    {
        GameManager.OnPointsChanged += EnableIfBuyable;
        upgradeCost = multiplierUpgrade.price;
        button = GetComponent<Button>();
        texts = GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].SetText(multiplierUpgrade.upgradeName);
        texts[2].SetText(upgradeCost.ToString());
    }

    private void OnDestroy()
    {
        GameManager.OnPointsChanged -= EnableIfBuyable;
    }
    public void OnClick()
    {
        GameManager.Instance.Points -= upgradeCost;
        upgradeCost = Mathf.RoundToInt(upgradeCost * 1.5f);
        texts[2].SetText(upgradeCost.ToString());
        EnableIfBuyable(GameManager.Instance.Points);
        OnMultiplierBougth?.Invoke(multiplierUpgrade);
    }

    private void EnableIfBuyable(float points)
    {
        if (points >= upgradeCost)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
