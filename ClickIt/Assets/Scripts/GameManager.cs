using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static event Action<float> OnPointsChanged;

    [SerializeField] private float points;
    public float Points
    {
        get { return points; }
        set 
        { 
            points = value;
            OnPointsChanged?.Invoke(points);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

}
