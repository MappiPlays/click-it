using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerNumberLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.SetText(GameManager.Instance.ClickPower.ToString());
        StartCoroutine(DestroyAfterOneSec());
    }

    IEnumerator DestroyAfterOneSec()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
