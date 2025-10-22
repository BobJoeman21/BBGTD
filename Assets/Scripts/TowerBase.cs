using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{

    public int TowerPrice;
    public int MaxHP;
    private int CurrentHP;

    private void Start()
    {
        CurrentHP = MaxHP;
    }

    public int DmgPlant(int dmgAmount)
    {
        CurrentHP -= dmgAmount;
        return CurrentHP;
    }

    public void KillPlant()
    {
        GetComponentInParent<TileBaseScript>().hasTower = false;
        Destroy(gameObject);
    }

}
