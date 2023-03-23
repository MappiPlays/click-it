using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPointsValue;

    private void Start()
    {
        GameManager.OnPointsChanged += UpdatePointsDisplay;
    }

    private void OnDestroy()
    {
        GameManager.OnPointsChanged -= UpdatePointsDisplay;
    }

    private void UpdatePointsDisplay(float points)
    {
        textPointsValue.SetText(points.ToString());
    }
}
