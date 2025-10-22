using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{


    int Health = 10;
    private bool eating = false;
    public int AttackDmg;
    public int attackTimerMax;
    public LayerMask plantLayer;
    private int attackTimerCurrent;
    private Collider2D plantTarget;



    // Update is called once per frame
    void FixedUpdate()
    {
        if (!eating)
        {
            transform.Translate(new Vector3(-0.01f, 0, 0));
            if (Physics2D.OverlapCircle(transform.position, .2f, plantLayer))
            {
                //EatPlant
                plantTarget = Physics2D.OverlapCircle(transform.position, .2f, plantLayer);
                eating = true;
            }
        }//Walk If Not Eating
        
        
        //StopEatingPlantIfCheckIsNull
        /*else
        {
            if (eating)
            {
                eating = false;
                attackTimerCurrent = 0;
            }
            
        }
        */
        if (eating)
        {
            attackTimerCurrent += 1;
            if(plantTarget == null)
            {
                attackTimerCurrent = 0;
                eating = false;
            }
            if (attackTimerCurrent >= attackTimerMax)
            {   
                attackTimerCurrent = 0;
                if(plantTarget == null)
                {
                    eating = false;
                }
                int TargetHP = plantTarget.GetComponent<TowerBase>().DmgPlant(AttackDmg);
                if(TargetHP <= 0)
                {
                    plantTarget.GetComponent<TowerBase>().KillPlant();
                    plantTarget = null;
                    eating = false;
                }
            }
        }
        
        
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
