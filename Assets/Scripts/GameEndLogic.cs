using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndLogic : MonoBehaviour
{
    public GameObject MainCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            collision.GetComponent<ZombieBase>().EndGame();
        }
    }
}
