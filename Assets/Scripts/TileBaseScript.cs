using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBaseScript : MonoBehaviour
{


    public Color baseColor;
    public Color glowColor;
    SpriteRenderer sprite;
    public bool hasTower;
    GameObject player;
    


    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        sprite.color = baseColor;
        player.GetComponent<PlayerScript>().targetedTile = null;
    }

}
