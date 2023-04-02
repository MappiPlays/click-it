using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.Points += GameManager.Instance.ClickPower;
    }
}
