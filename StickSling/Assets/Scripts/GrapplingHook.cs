using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GrapplingHook : MonoBehaviour
{

    public GameObject HookGO;
    
    public Transform ArmTransform;
    public float force;
    public bool isShooting = false;
    public Transform Hand;

    private Hook hook;
    private Rope rope;

    Vector3 shootDirection;
    
    Camera mainCamera;
    Vector3 mouseVector;
    float degrees;
    Quaternion armQuaternion;

    Transform playerTransform;

    Rigidbody2D hookBody;
    Transform hookTransform;
    DistanceJoint2D joint;

    private Rigidbody2D playerBody;


    private bool connected = false;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        hookBody = HookGO.GetComponent<Rigidbody2D>();
        hook = HookGO.GetComponent<Hook>();
        rope = GetComponent<Rope>();
        
        hookTransform = hookBody.transform;
        
        mainCamera = Camera.main;
        playerTransform = GetComponent<Transform>();
        Debug.Log(mainCamera.name);
        hookBody.isKinematic = false;
        joint = GetComponent<DistanceJoint2D>();

    }   

    // Update is called once per frame
    void Update()
    {

        mouseVector = Input.mousePosition - mainCamera.WorldToScreenPoint(ArmTransform.position);
        degrees = Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg;
        armQuaternion = Quaternion.AngleAxis(degrees, Vector3.forward);
        ArmTransform.rotation = armQuaternion;
        

        if (Input.GetMouseButtonDown(0))
        {

            connected = false;
            isShooting = true;

            joint.enabled = false;
            
            hook.ResetHook();
            rope.ResetRope();
            hookTransform.position = Hand.position;
            hookTransform.rotation = armQuaternion;
           
            Shoot();
        }

        
        if (Input.GetMouseButtonDown(1))
        {
            joint.enabled = false;
            hook.ResetHook();
            rope.ResetRope();
            isShooting = false;
            connected = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (connected)
            {
                joint.distance -= 10 * Time.deltaTime;
                playerBody.AddForce(Vector2.right * 10, ForceMode2D.Force);

            }
        }
        if (!isShooting)
        {
            hookTransform.position = Hand.position;
        }

        if (Input.GetKey(KeyCode.D))
        {

        }

        if (connected)
        {
            joint.distance -= 1 * Time.deltaTime;
        }

        //transform.LookAt(mouseVector,Vector3.up);
    }


    public void ConnectJoint(Vector2 hitPosition)
    {
        // joint.anchor = transform.position;
        joint.distance = Vector3.Distance(Hand.position, hitPosition);
        joint.enabled = true;
        connected = true;
    }
    
    
    private void Shoot()
    {
        hookBody.velocity = Vector2.zero;
        // hookBody.AddForce(mouseVector.normalized * force, ForceMode2D.Impulse);
        hook.AddBulletForce(mouseVector.normalized * force);
    }
}
