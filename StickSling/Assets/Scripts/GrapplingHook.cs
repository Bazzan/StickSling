using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    public GameObject Hook;
    public Transform ArmTransform;
    public float force;
    public bool isShooting = false;
    public Transform Hand;


    Vector3 shootDirection;
    
    Camera mainCamera;
    Vector3 mouseVector;
    float degrees;
    Quaternion armQuaternion;

    Transform playerTransform;

    Rigidbody2D hookBody;
    Transform hookTransform;

    // Start is called before the first frame update
    void Start()
    {

        hookBody = Hook.GetComponent<Rigidbody2D>();
        hookTransform = hookBody.transform;
        mainCamera = Camera.main;
        playerTransform = GetComponent<Transform>();
        Debug.Log(mainCamera.name);
        hookBody.isKinematic = false;
        

    }   

    // Update is called once per frame
    void Update()
    {

        mouseVector = Input.mousePosition - mainCamera.WorldToScreenPoint(ArmTransform.position);
        degrees = Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg;
        armQuaternion = Quaternion.AngleAxis(degrees, Vector3.forward);
        ArmTransform.rotation = armQuaternion;
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isShooting = true;

            hookTransform.position = Hand.position;
            hookTransform.rotation = armQuaternion;
            



            hookBody.velocity = Vector2.zero;
            hookBody.AddForce(mouseVector.normalized * force, ForceMode2D.Impulse);
            //hookBody.AddForce(new Vector2(force, 0),ForceMode2D.Impulse);

        }



        if (!isShooting)
        {
            hookTransform.position = Hand.position;
        }

        //transform.LookAt(mouseVector,Vector3.up);
    }

    
}
