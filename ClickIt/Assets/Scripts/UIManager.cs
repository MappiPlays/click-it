using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPointsValue;
    [SerializeField] private TextMeshProUGUI textMPSValue;

    private void Start()
    {
        GameManager.OnPointsChanged += UpdatePointsDisplay;
        GameManager.OnMPSChanged += UpdateMPSDisplay;
    }

    private void OnDestroy()
    {
        GameManager.OnPointsChanged -= UpdatePointsDisplay;
        GameManager.OnMPSChanged -= UpdateMPSDisplay;
    }

    private void UpdatePointsDisplay(float points)
    {
        textPointsValue.SetText(Mathf.FloorToInt(points).ToString());
    }

    private void UpdateMPSDisplay(float mps)
    {
        textMPSValue.SetText(mps.ToString("0.#"));
    }
}
