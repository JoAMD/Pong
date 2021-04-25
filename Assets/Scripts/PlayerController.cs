using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerBase
{
    [SerializeField] private float stepIncrement = 0.01f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 endValue = transform.position + stepIncrement * Vector3.up;
            if(endValue.y <= 4)
            {
                //go up
                transform.DOMove(endValue, Time.deltaTime);
            }
        }
        else
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 endValue = transform.position + stepIncrement * -Vector3.up;
            if(endValue.y >= -4)
            {
                //go up
                transform.DOMove(endValue, Time.deltaTime);
            }
        }
    }
}
