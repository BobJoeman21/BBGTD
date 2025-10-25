using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBaseScript : MonoBehaviour
{


    public Color baseColor;
    public Color glowColor;
    public Color invisColor;
    SpriteRenderer sprite;
    public bool hasTower;
    GameObject player;
    


    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (player.GetComponent<PlayerScript>().targetedPacket != null)
            {
                sprite.color = baseColor;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            sprite.color = invisColor;
        }
    }



    private void OnMouseEnter()
    {

        if (player.GetComponent<PlayerScript>().ChosenTower >= 0 && !hasTower)
        {

            sprite.color = glowColor;
            player.GetComponent<PlayerScript>().targetedTile = gameObject;
        }
    }

    private void OnMouseExit()
    {
        if (Input.GetMouseButton(0) && player.GetComponent<PlayerScript>().ChosenTower >= 0)
        {
            sprite.color = baseColor;
        }
        else
        {
            sprite.color = invisColor;
        }
            

        player.GetComponent<PlayerScript>().targetedTile = null;
    }

}
