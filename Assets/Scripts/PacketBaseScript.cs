using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketBaseScript : MonoBehaviour
{


    public Color baseColor;
    public Color glowColor;
    public int TowerValue;
    SpriteRenderer sprite;
    GameObject player;
    


    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    


    private void OnMouseEnter()
    {
        sprite.color = glowColor;
        player.GetComponent<PlayerScript>().targetedPacket = gameObject;

    }

    private void OnMouseExit()
    {
        sprite.color = baseColor;
        player.GetComponent<PlayerScript>().targetedPacket = null;
    }

}
