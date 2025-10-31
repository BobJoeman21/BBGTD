using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class UIScript : MonoBehaviour
{


    public TMP_Text grudgesCounter;
    public Image blackFadeimg;
    private bool grudgesChanged;
    private int GrudgesGoal = 0;
    private int currentGrudges = 0;
    private float AlphaGoal = 0;
    private int timeOnEndScreen = 0;
    private AudioSource bgmusic;

    

    private void Start()
    {
        bgmusic = GetComponent<AudioSource>();
    }
    public void UpdateGrudges(int TotalGrudges)
    {
        GrudgesGoal = TotalGrudges;
        grudgesChanged = true;

    }


    public IEnumerator FadeToBlack(GameEndLogic Trigger)
    {
        while(blackFadeimg.color.a < 1)
        {
            bgmusic.volume -= 0.05f;
            if(bgmusic.volume <= 0)
            {
                bgmusic.Stop();
            }
            AlphaGoal += 0.003f;
            blackFadeimg.color = new Color(1, 1, 1, AlphaGoal);
            yield return null;
        }
        while(timeOnEndScreen < 500)
        {
            timeOnEndScreen += 1;
            yield return null;
        }
        Debug.Log("JUMPSCARE");
        blackFadeimg.color = new Color(1, 1, 1, 0);
        gameObject.GetComponent<VideoPlayer>().Play();
        Trigger.StartCoroutine(Trigger.EndAfterSeconds(gameObject.GetComponent<VideoPlayer>().length));
        

    }

    void FixedUpdate()
    {
        if (grudgesChanged)
        {
            if (currentGrudges < GrudgesGoal)
            {
                currentGrudges += 1;
                grudgesCounter.text = currentGrudges.ToString();
            }else if(currentGrudges > GrudgesGoal)
            {
                currentGrudges -= 1;
                grudgesCounter.text = currentGrudges.ToString();
            }
            else
            {
                grudgesChanged = false;
            }
        }
    }
}
