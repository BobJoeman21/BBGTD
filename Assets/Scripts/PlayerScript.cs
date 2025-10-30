using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [HideInInspector] public GameObject targetedTile;
    [HideInInspector] public GameObject targetedPacket;
    public GameObject[] towers;
    public int ChosenTower;
    public PacketBaseScript ClickedPacket;
    public int grudges;
    public LayerMask GrudgeMask;
    public UIScript UIReference;

    //Audio
    public AudioClip[] souds;
    private AudioSource AudioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
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
                ClickedPacket = targetedPacket.GetComponent<PacketBaseScript>();
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
            //TowerSpawn
            if (targetedTile != null && ChosenTower >= 0 && targetedTile.GetComponent<TileBaseScript>().hasTower == false)
            {
                //PriceCheck
                if(grudges >= towers[ChosenTower].GetComponent<TowerBase>().TowerPrice)
                {
                    Instantiate(towers[ChosenTower], targetedTile.transform).GetComponent<TowerBase>();
                    targetedTile.GetComponent<TileBaseScript>().hasTower = true;
                    grudges -= towers[ChosenTower].GetComponent<TowerBase>().TowerPrice;
                    UIReference.UpdateGrudges(grudges);
                    ClickedPacket.Cooldown();
                    AudioPlayer.clip = souds[0];
                    AudioPlayer.Play();
                }
                
            }
            ChosenTower = -1;
            ClickedPacket = null;
        }
    }


    private void CollectGrudge(Collider2D collectedGrudge)
    {
        collectedGrudge.gameObject.GetComponentInParent<GrudgeScript>().collect();
        grudges += 25;
        UIReference.UpdateGrudges(grudges);
    }
}
