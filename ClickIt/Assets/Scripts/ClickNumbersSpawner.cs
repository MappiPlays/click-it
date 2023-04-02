using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNumbersSpawner : MonoBehaviour
{
    [SerializeField] private GameObject labelPrefab;

    public void ShowPowerLabel()
    {
        if (labelPrefab != null)
        {
            Instantiate(labelPrefab, gameObject.transform);
        }
    }
}
