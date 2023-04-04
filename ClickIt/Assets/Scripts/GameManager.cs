using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static event Action<float> OnPointsChanged;
    public static event Action<float> OnPointsChangedByAmount;

    [SerializeField] private float points;
    public float Points
    {
        get { return points; }
        set 
        { 
            points = value;
            OnPointsChanged?.Invoke(points);
            OnPointsChangedByAmount?.Invoke(value);
        }
    }

    [SerializeField] private float clickPower;
    public float ClickPower
    {
        get { return clickPower; }
        set { clickPower = value; }
    }

    [SerializeField] private float mps;
    public float MPS
    {
        get { return mps; }
        set { mps = value; }
    }

    private void Awake()
    {
        Instance = this;
        UpgradeButton.OnUpgradeBougth += HandleUpgradeBougth;
    }

    private void Start()
    {
        StartCoroutine(AddPointsPerSecond());
    }

    private void OnDestroy()
    {
        UpgradeButton.OnUpgradeBougth -= HandleUpgradeBougth;
    }

    private IEnumerator AddPointsPerSecond()
    {
        while (true)
        {
            if(MPS != 0f)
                Points += MPS/10;
            yield return new WaitForSeconds(1f / 10f);
        }
    }

    private void HandleUpgradeBougth(UpgradeButton upgradeButton)
    {
        MPS += upgradeButton.upgrade.cps;
    }

}
