using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducerTowerScript : MonoBehaviour
{

    public GameObject GrudgePrefab;
    public int ProduceTimerMax;
    private int ProduceTimerCurrent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProduceTimerCurrent += 1;
        if(ProduceTimerCurrent >= ProduceTimerMax)
        {
            //SpawnGrudge
            Instantiate(GrudgePrefab, new Vector3((transform.position.x + Random.Range(-.2f, .3f)),gameObject.transform.position.y), Quaternion.identity);
            ProduceTimerCurrent = 0;
        }
    }
}
