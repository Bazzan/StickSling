
using UnityEngine;

public class Hook : MonoBehaviour
{


    Rigidbody2D hookBody;
    DistanceJoint2D distanceJoint;
    SpringJoint2D springJoint;

    Vector2 hitPosition;
    bool hit = false;

    private void Awake()
    {
        hookBody = GetComponent<Rigidbody2D>();
        distanceJoint = GetComponent<DistanceJoint2D>();
        springJoint = GetComponent<SpringJoint2D>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Box")){
            Debug.Log("hook connected");
            //hookBody.simulated = false;
            hit = true;
            hitPosition = transform.position;
            hookBody.velocity = Vector2.zero;
            hookBody.constraints = RigidbodyConstraints2D.FreezeAll;
            springJoint.enabled = true;
            springJoint.anchor = transform.position;
            springJoint.distance = 20;

            //distanceJoint.enabled = true;
            //distanceJoint.anchor = transform.position;
            //distanceJoint.distance = 20;
        }
    }

    private void Update()
    {
        if (!hit) return;
        springJoint.distance -= 3 * Time.deltaTime;
        //distanceJoint.distance -= 3 * Time.deltaTime;
    }
    




}
