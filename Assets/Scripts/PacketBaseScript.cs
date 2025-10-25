using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketBaseScript : MonoBehaviour
{

    [Header("Sprite Info")]
    public Color baseColor;
    public Color glowColor;
    public Color CDColor;

    [Header("Stats")]
    public int CooldownMax;
    private int CooldownCurrent;
    public bool OnCooldown;
    public int TowerValue;
    SpriteRenderer sprite;
    GameObject player;



    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void FixedUpdate()
    {
        if (OnCooldown)
        {
            CooldownCurrent += 1;
            if (CooldownCurrent >= CooldownMax)
            {
                CooldownCurrent = 0;
                EndCooldown();
            }
        }

    }

    private void OnMouseEnter()
    {
        if (!OnCooldown)
        {
            sprite.color = glowColor;
            player.GetComponent<PlayerScript>().targetedPacket = gameObject;
        }

    }

    private void OnMouseExit()
    {
        if (!OnCooldown)
        {
            sprite.color = baseColor;
            player.GetComponent<PlayerScript>().targetedPacket = null;
        }

    }

    public void Cooldown()
    {
        OnCooldown = true;
        sprite.color = CDColor;
    }
    private void EndCooldown()
    {
        OnCooldown = false;
        sprite.color = baseColor;
    }


}
