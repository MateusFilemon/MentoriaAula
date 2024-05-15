using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parallaxEffect;
    private void Start()
    {
        startPos = transform.position.x;
      
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(dist + startPos, transform.position.y, transform.position.z);
    }
}
