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

    public float MPS
    {
        get { return MPSFromUpgrades + (ClicksPerSecond * ClickPower); }
    }

    [SerializeField] private float mpsFromUpgrades;
    public float MPSFromUpgrades
    {
        get { return mpsFromUpgrades; }
        set { mpsFromUpgrades = value; }
    }

    [SerializeField] private float clicksPerSecond;
    public float ClicksPerSecond
    {
        get { return clicksPerSecond; }
        set { clicksPerSecond = value; }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(AddPointsPerSecond());
        MPSUpgradeButton.OnUpgradeBougth += HandleUpgradeBougth;
    }

    private void OnDestroy()
    {
        MPSUpgradeButton.OnUpgradeBougth -= HandleUpgradeBougth;
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

    private void HandleUpgradeBougth(MPSUpgradeButton upgradeButton)
    {
        MPSFromUpgrades += upgradeButton.upgrade.metersPerSecond;
    }

}
