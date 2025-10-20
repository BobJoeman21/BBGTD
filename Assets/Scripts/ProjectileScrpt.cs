using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScrpt : MonoBehaviour
{
    public float speed = 0.01f;
    public int lifetimemax;
    private int lifetimecurrent;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0f, 0f));
        lifetimecurrent += 1;
        if(lifetimecurrent>= lifetimemax)
        {
            Destroy(gameObject);
        }
    }
}
