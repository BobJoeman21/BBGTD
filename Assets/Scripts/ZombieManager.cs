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
        for(int i = 0; i < ZombieList.Length; i++)
        {
            if(Random0to1 <= ZombieList[i].SpawnChance)
            {
                Instantiate<GameObject>(ZombieList[i].ZombieToSpawn, spawnLocs[Random.Range(0, 5)], Quaternion.identity);
                if(DifficultyLevel > 0)
                ZombieList[0].SpawnChance = Mathf.Clamp((ZombieList[0].SpawnChance - 0.05f),0.1f,1f);
                if(DifficultyLevel >=1)
                ZombieList[1].SpawnChance = Mathf.Clamp((ZombieList[1].SpawnChance - 0.01f),.5f,1f);
                if(DifficultyLevel >= 2)
                ZombieList[2].SpawnChance = Mathf.Clamp((ZombieList[2].SpawnChance + 0.015f),.0f,1f);
                return;
            }

        }


    }
    public void SpawnHorde()
    {
        if(DifficultyLevel > 4)
        ZombieList[0].SpawnChance += .25f;
        ZombieList[1].SpawnChance += .08f;
        StartCoroutine(HordeSpawnLoop());
        
        timerMax -= 50;
        Debug.Log("SPAWNEDHORDE");
    }

    private void FixedUpdate()
    {
        timerCurrent += 1;
        hordeTimerCurrent += 1;
        if(timerCurrent >= firstSpawnMax)
        {
            if (DifficultyLevel <= 1)
            {
                SpawnZombie(Random.value);
            }
            else
            {
                for (int i = 0; i <= DifficultyLevel; i++)
                {
                    SpawnZombie(Random.value);
                }
            }
            firstSpawnMax = timerMax;
            timerCurrent = 0;
        }
        if(hordeTimerCurrent >= hordeTimerMax)
        {
            hordeTimerCurrent = 0;
            SpawnHorde();
            hordeTimerCurrent = 0;
        }
    }

    private void Update()
    {
        TotalTime += Time.deltaTime;
    }



    IEnumerator HordeSpawnLoop()
    {
        for (int i = 1; i <= 5 + (1 * DifficultyLevel); i++)
        {
            SpawnZombie(Random.value);
            yield return new WaitForSeconds(0.1f);
        }
        DifficultyLevel += 1;

    }




}
