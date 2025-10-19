using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{


    int Health = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(-0.01f, 0, 0));
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        TakeDamage(1);
    }

    void TakeDamage(int dmg)
    {
        Health -= dmg;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
