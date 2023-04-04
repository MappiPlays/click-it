using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(MeasureClickPerSecond());
    }

    private IEnumerator MeasureClickPerSecond()
    {
        GameManager.Instance.ClicksPerSecond++;
        float elapsedTime = 0;
        while(elapsedTime < 1)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        GameManager.Instance.ClicksPerSecond--;
    }
}
