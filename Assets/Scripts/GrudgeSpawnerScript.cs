using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrudgeSpawnerScript : MonoBehaviour
{
    public GameObject FallingGrudgePrefab;
    public int timerMax;
    private int timerCurrent;


    void SpawnGrudge()
    {
        //Pick Random Spot from -7 to +7 on X, spawn falling grudge
        Instantiate(FallingGrudgePrefab, new Vector3(Random.Range(-7f, 7.2f), transform.position.y, transform.position.z), Quaternion.identity);
    }

    private void FixedUpdate()
    {
        timerCurrent += 1;
        if(timerCurrent >= timerMax)
        {
            SpawnGrudge();
            timerCurrent = 0;
            timerMax += 50;
        }
    }

}
