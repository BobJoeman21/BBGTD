using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [Header("Zombie Spawn Info")]
    public GameObject[] ZombieList;
    public Vector3[] spawnLocs;
    [Header("Spawn Timer")]
    public int firstSpawnMax;
    public int timerMax;
    public int hordeTimerMax;
    private int timerCurrent;
    private int hordeTimerCurrent;
    [HideInInspector] public float TotalTime;


    public void SpawnZombie(int ZombieToSpawn)
    {
        Instantiate<GameObject>(ZombieList[ZombieToSpawn], spawnLocs[Random.Range(0,4)], Quaternion.identity);
    }

    public void SpawnHorde()
    {

    }

    private void FixedUpdate()
    {
        timerCurrent += 1;
        hordeTimerCurrent += 1;
        if(timerCurrent >= firstSpawnMax)
        {
            SpawnZombie(0);
            firstSpawnMax = timerMax;
            timerCurrent = 0;
        }
        if(hordeTimerCurrent >= hordeTimerMax)
        {
            SpawnHorde();
        }
    }

    private void Update()
    {
        TotalTime += Time.deltaTime;
    }








}
