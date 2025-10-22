using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [Header("Zombie Spawn Info")]
    public ZombieBase[] ZombieList;
    public Vector3[] spawnLocs;
    [Header("Spawn Timer")]
    public int firstSpawnMax;
    public int timerMax;
    public int hordeTimerMax;
    private int timerCurrent;
    private int hordeTimerCurrent;
    private float DifficultyLevel = 0f;
    [HideInInspector] public float TotalTime; //Use this as Dificulty


    /*public void SpawnZombie(float Random0to1)
    {
        Debug.Log(Random0to1);
        for(int i = 0; i < ZombieList.Length; i++)
        {
            if(Random0to1 <= ZombieList[i].spawnChance)
            {
                Instantiate<GameObject>(ZombieList[i].ZombieObject, spawnLocs[Random.Range(0, 5)], Quaternion.identity);
                return;
            }
        }
        
        ZombieList[0].spawnChance = Mathf.Clamp01(ZombieList[0].spawnChance - 0.05f);
    }
    */
    public void SpawnHorde()
    {
        Debug.Log("HordeTime");
    }

    private void FixedUpdate()
    {
        timerCurrent += 1;
        hordeTimerCurrent += 1;
        if(timerCurrent >= firstSpawnMax)
        {
            //SpawnZombie(Random.value);
            firstSpawnMax = timerMax;
            timerCurrent = 0;
            //Mathf.Clamp((Random.v),0,ZombieList.Length);
        }
        if(hordeTimerCurrent >= hordeTimerMax)
        { 
            SpawnHorde();
            hordeTimerCurrent = 0;
            DifficultyLevel += .1f;
        }
    }

    private void Update()
    {
        TotalTime += Time.deltaTime;
    }








}
