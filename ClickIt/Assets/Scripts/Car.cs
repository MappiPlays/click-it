using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Animator anim;
    private bool isMoving = false;

    void Start()
    {
        GameManager.OnPointsChanged += Drive;
        anim = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        GameManager.OnPointsChanged -= Drive;
    }

    public void Drive(float points)
    {
        if(!isMoving)
            StartCoroutine(AnimateCO());
    }

    IEnumerator AnimateCO()
    {
        isMoving = true;
        anim.SetBool("isMoving", true);
        yield return new WaitForSeconds(.333f);
        anim.SetBool("isMoving", false);
        isMoving = false;
    }
}
