using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndLogic : MonoBehaviour
{
    public GameObject MainCam;
    public UIScript UIRef;
    private Vector3 camstartPoint;
    private Vector3 camEndPoint = new Vector3(-4, 0, 0);
    bool GameRunning = true;


    private void Start()
    {
        camstartPoint = MainCam.transform.position;
    }


    IEnumerator MoveCam()
    {
        while((MainCam.transform.position - camEndPoint).magnitude > .3f)
        {
            MainCam.transform.Translate((camEndPoint - camstartPoint).normalized * Time.deltaTime * .5f * (MainCam.transform.position - camEndPoint).magnitude);
            yield return null;
        }
        UIRef.StartCoroutine(UIRef.FadeToBlack(this));
    }


    public IEnumerator EndAfterSeconds(double time)
    {
        yield return new WaitForSeconds(((float)time));
        SceneManager.LoadScene("MainMenu");
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            if (GameRunning)
            {
                GameRunning = false;
                GetComponent<AudioSource>().Play();
                StartCoroutine(MoveCam());
            }

        }
    }
}
