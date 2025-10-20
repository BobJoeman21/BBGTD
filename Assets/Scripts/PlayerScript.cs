using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [HideInInspector] public GameObject targetedTile;
    [HideInInspector] public GameObject targetedPacket;
    public GameObject[] towers;
    public int ChosenTower;
    public int grudges;
    public LayerMask GrudgeMask;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 144;
    }

    // Update is called once per frame
    void Update()
    {

        //Everytime Player Left Clicks
        if (Input.GetMouseButtonDown(0))
        {
            if(targetedPacket != null)
            {
                ChosenTower = targetedPacket.GetComponent<PacketBaseScript>().TowerValue;
            }
            //Check Circle Around Mouse
            Collider2D hitObject = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), .2f,GrudgeMask);
            if (hitObject != null)
            {
                CollectGrudge(hitObject);
                hitObject = null;
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


    private void CollectGrudge(Collider2D collectedGrudge)
    {
        collectedGrudge.gameObject.GetComponentInParent<GrudgeScript>().collect();
        grudges += 25;
        Debug.Log(grudges);
    }
}
