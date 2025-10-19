using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTower : MonoBehaviour
{

    float timerCurrent = 0f;
    public float timerMax = 125f;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timerCurrent += 1f;
        if(timerCurrent >= timerMax && Physics2D.Raycast(transform.position, Vector3.right))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        Instantiate(projectile, gameObject.transform);
        timerCurrent = 0f;
    }
}
