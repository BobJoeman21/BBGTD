using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [Header("Zombie Spawn Info")]
    public zombieType[] ZombieList;
    public Vector3[] spawnLocs;
    [Header("Spawn Timer")]
    public int firstSpawnMax;
    public int timerMax;
    public int hordeTimerMax;
    private int timerCurrent;
    private int hordeTimerCurrent;
    private int DifficultyLevel = 0;
    [HideInInspector] public float TotalTime; //Use this as Dificulty


    [System.Serializable]
    public class zombieType
    {
        public GameObject ZombieToSpawn;
        [Range(0f,1f)]
        public float SpawnChance;
    }


    public void SpawnZombie(float Random0to1)
    {
        Debug.Log(Random0to1);
        for(int i = 0; i < ZombieList.Length; i++)
        {
            if(Random0to1 <= ZombieList[i].SpawnChance)
            {
                Instantiate<GameObject>(ZombieList[i].ZombieToSpawn, spawnLocs[Random.Range(0, 5)], Quaternion.identity);
                ZombieList[0].SpawnChance = Mathf.Clamp((ZombieList[0].SpawnChance - 0.05f),0.1f,1f);
                ZombieList[1].SpawnChance = Mathf.Clamp((ZombieList[1].SpawnChance - 0.01f),.5f,1f);
                ZombieList[2].SpawnChance = Mathf.Clamp((ZombieList[2].SpawnChance + 0.05f),.0f,1f);
                return;
            }

        }


    }
    public void SpawnHorde()
    {
        ZombieList[0].SpawnChance += .25f;
        ZombieList[1].SpawnChance += .25f;

        for (int i = 0; i <= 5 + (2 * DifficultyLevel); i++)
        {
            SpawnZombie(Random.value);
        }
    }

    private void FixedUpdate()
    {
        timerCurrent += 1;
        hordeTimerCurrent += 1;
        if(timerCurrent >= firstSpawnMax)
        {
            SpawnZombie(Random.value);
            firstSpawnMax = timerMax;
            timerCurrent = 0;
        }
        if(hordeTimerCurrent >= hordeTimerMax)
        {
            SpawnHorde();
            hordeTimerCurrent = 0;
        }
    }

    private void Update()
    {
        TotalTime += Time.deltaTime;
    }








}
