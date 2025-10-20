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
            Instantiate<GameObject>(GrudgePrefab, gameObject.transform);
            ProduceTimerCurrent = 0;
        }
    }
}
