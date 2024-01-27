using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bg : MonoBehaviour
{
    private float lenght , startPos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float temp = cam.transform.position.x*(1-parallaxEffect);

        transform.position = new Vector3(startPos + dist , transform.position.y,transform.position.z); 
        if(temp>startPos+lenght) startPos+=lenght;
        else if (temp<startPos +lenght) startPos-=lenght;
    }

}
