using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScrpt : MonoBehaviour
{



    public float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed, 0f, 0f));
    }
}
