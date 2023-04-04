using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MoveOverSeconds());
    }

    public IEnumerator MoveOverSeconds()
    {
        //float elapsedTime;
        Vector3 endPos;
        while (true)
        {
            //elapsedTime = 0;
            endPos = transform.position + Vector3.left * GameManager.Instance.MPS;
            //while (elapsedTime < 1)
            //{
            //    transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime);
            //    elapsedTime += Time.deltaTime;
            //    yield return new WaitForEndOfFrame();
            //}
            //transform.position = endPos;
            transform.position = Vector3.MoveTowards(transform.position, endPos, GameManager.Instance.MPS * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
