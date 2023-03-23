using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private int clickPower;
    public void OnClick()
    {
        GameManager.Instance.Points += clickPower;
    }
}
