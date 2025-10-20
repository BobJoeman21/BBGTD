using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrudgeScript : MonoBehaviour
{
    public Vector3 targetPos;
    private Vector3 directionToTarget;
    private bool moving;

    public void collect()
    {
        directionToTarget = (targetPos - transform.position).normalized;
        moving = true;
    }

    private void Update()
    {
        if (moving)
        {
            transform.position += directionToTarget * 20f * Time.deltaTime;
        }
    }
}
