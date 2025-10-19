using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject targetedTile;
    public GameObject targetedPacket;
    public GameObject[] towers;
    public int ChosenTower;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(targetedPacket != null)
            {
                ChosenTower = targetedPacket.GetComponent<PacketBaseScript>().TowerValue;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (targetedTile != null && ChosenTower >= 0 && targetedTile.GetComponent<TileBaseScript>().hasTower == false)
            {
                Instantiate(towers[ChosenTower], targetedTile.transform);
                targetedTile.GetComponent<TileBaseScript>().hasTower = true;
            }
            ChosenTower = -1;
        }
    }
}
