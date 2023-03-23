using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private CPSUpgrade upgrade;
    [SerializeField] private int upgradeCount;
    [SerializeField] private int upgradeCost;

    private Button button;
    private TextMeshProUGUI[] texts;
    void Start()
    {
        GameManager.OnPointsChanged += EnableIfBuyable;
        upgradeCount = 0;
        upgradeCost = upgrade.basePrice;
        button = GetComponent<Button>();
        texts = GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].SetText(upgrade.upgradeName);
        texts[2].SetText(upgradeCost.ToString());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void OnClick()
    {
        upgradeCount++;
        if (upgradeCount == 1)
            StartCoroutine(WorkCo());
        GameManager.Instance.Points -= upgradeCost;
        upgradeCost = Mathf.RoundToInt(upgradeCost * 1.1f);
        texts[2].SetText(upgradeCost.ToString());
        texts[3].SetText(upgradeCount.ToString());
        EnableIfBuyable(GameManager.Instance.Points);
    }

    IEnumerator WorkCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / (upgrade.cps * upgradeCount));
            GameManager.Instance.Points++;
        }
    }

    private void EnableIfBuyable(float points)
    {
        if(points >= upgradeCost)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
