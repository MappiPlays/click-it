using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MoveOverSeconds());
    }

    private void Update()
    {
        if (transform.position.x < -30)
            transform.position += Vector3.right*30;
    }

    public IEnumerator MoveOverSeconds()
    {
        Vector3 endPos;
        while (true)
        {
            endPos = transform.position + Vector3.left * (GameManager.Instance.MPS / 100f);
            transform.position = Vector3.MoveTowards(transform.position, endPos, GameManager.Instance.MPS * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
