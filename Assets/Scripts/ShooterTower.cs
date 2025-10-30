using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTower : MonoBehaviour
{

    float timerCurrent = 0f;
    public float timerMax = 125f;
    public GameObject projectile;
    public AudioSource AudioPlayer;
    [SerializeField] private LayerMask zombieLayer;


    // Update is called once per frame
    void FixedUpdate()
    {
        timerCurrent += 1f;
        if(timerCurrent >= timerMax && Physics2D.Raycast(new Vector3(12, transform.position.y, 0), Vector3.left, (12 - transform.position.x), zombieLayer))
        {
            GetComponent<Animator>().SetTrigger("Throw");
            timerCurrent = 0f;
        }
    }


    void Shoot()
    {
        AudioPlayer.Play();
        Instantiate(projectile, gameObject.transform);
        
        
    }


    
}
