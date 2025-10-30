using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Image blackFade;
    public AudioSource MMMusic;
    bool timerRunning = false;
    int timer = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerRunning)
        {
            timer += 1;
            if(timer > 200)
            {
                StartCoroutine(FadeOut());
            }
        }
    }

    public IEnumerator FadeOut()
    {
        float fadeValue = 0;
        while(blackFade.color.a < 1)
        {

            blackFade.color = new Color(0, 0, 0, fadeValue += 0.01f);
            yield return null;
        }
        //LoadLevel
        SceneManager.LoadScene("SampleScene");

    }
    public void StartGame()
    {
        //Play Cutscene
        MMMusic.Stop();
        gameObject.GetComponent<VideoPlayer>().Play();
        //Start Timer
        timerRunning = true;
    }
}
