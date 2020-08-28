using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    Camera mainCamera;
    Vector3 screenPoint;
    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        position = transform.position;
        screenPoint =mainCamera.WorldToViewportPoint(position);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(screenPoint.x >0 && screenPoint.x < 0 && screenPoint.y > 0 && screenPoint.y < 0)
    //    {
    //        transform.position = Screen.
    //    }
    //}
}
