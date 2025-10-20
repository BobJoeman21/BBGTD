using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrudgeScript : MonoBehaviour
{
    public Vector3 targetPos;
    private Vector3 directionToTarget;
    private bool moving;
    public bool fallingGrudge;
    private Vector3 fallingTarget;

    public void collect()
    {
        directionToTarget = (targetPos - transform.position).normalized;
        moving = true;
    }

    private void Start()
    {
        if (fallingGrudge)
        {
            fallingTarget = (new Vector3 (transform.position.x, Random.Range(-4f, 2.3f), 0f));
        }
    }


    private void Update()
    {
        if (moving)
        {
            transform.position += directionToTarget * 20f * Time.deltaTime;
            if ((transform.position - targetPos).magnitude <= 1f){
                Destroy(gameObject);
            }
        }
        if (fallingGrudge)
        {
            transform.position -= new Vector3(0f, 1f, 0) * Time.deltaTime;
            if ((transform.position - fallingTarget).magnitude < 1)
            {
                fallingGrudge = false;
            }
        }
        
    }
}
